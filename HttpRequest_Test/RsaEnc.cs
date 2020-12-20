using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using StringBuilder = System.Text.StringBuilder;
using GS.Util.Hex;
using System.Web;
using System.Net;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;

namespace HttpRequest_Test
{
    public class Keys
    {

        public static string RSAEncrypt(string data, string modulus, string pubExp)
        {
            AsymmetricKeyParameter pubKey = new RsaKeyParameters(false, new BigInteger(modulus, 16), new BigInteger(pubExp, 16));
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/NONE/NoPadding");
            c.Init(true, pubKey);
            byte[] outBytes = c.DoFinal(HexEncoding.GetBytes(data));
            return BitConverter.ToString(outBytes).Replace("-", "");
        }

        public static string RSADecrypt(string data, string modulus, string pubExp)
        {
            AsymmetricKeyParameter pubKey = new RsaKeyParameters(false, new BigInteger(modulus, 16), new BigInteger(pubExp, 16));
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/NONE/NoPadding");
            c.Init(false, pubKey);
            byte[] outBytes = c.DoFinal(HexEncoding.GetBytes(data));
            return BitConverter.ToString(outBytes).Replace("-", "");
        }

        public static byte[] Encrypt(byte[] data, RSAParameters rsakey, bool doPadding)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsakey);
                var encData = rsa.Encrypt(data, doPadding);
                return encData;
            };
        }

        public static byte[] Decrypt(byte[] data, RSAParameters rsakey, bool doPadding)
        {
            byte[] decryptData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsakey);
                decryptData = rsa.Decrypt(data, doPadding);
                return decryptData;
            };
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString().ToUpper();
        }

        public static byte[] StringToByteArray(String hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string DesEncrypt(string desData, string key)
        {
            byte[] dData = StringToByteArray(desData);
            byte[] keyData = StringToByteArray(key);
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            tdes.Key = keyData;
            tdes.Padding = PaddingMode.None;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform transform = tdes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(dData, 0, dData.Length);
            return BitConverter.ToString(result).Replace("-", "");
        }

        public static string TrippleDesEncrypt(string desData, string key)
        {
            byte[] dData = StringToByteArray(desData);
            byte[] keyData = StringToByteArray(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyData;
            tdes.Padding = PaddingMode.None;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform transform = tdes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(dData, 0, dData.Length);
            return BitConverter.ToString(result).Replace("-", "");
        }

        static string ConvertBinaryToString(List<List<int>> seq)
        {
            return new String(seq.Select(s => (char)s.Aggregate((a, b) => a * 2 + b)).ToArray());
        }

        public static string TrippleDesDecryption(string desData, string key)
        {
            byte[] dData = StringToByteArray(desData);
            byte[] keyData = StringToByteArray(key);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyData;
            tdes.Padding = PaddingMode.None;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform transform = tdes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(dData, 0, 8);
            return BitConverter.ToString(result).Replace("-", "");
        }

        public static string asciiToHex(string ascii)
        {
            byte[] enc = Encoding.Default.GetBytes(ascii);
            return BitConverter.ToString(enc).Replace("-", "");
        }

        public static bool generateKimonoKeys(string url, string termialid, string keysetid)
        {
            try
            {
                RSACryptoServiceProvider crypto = new RSACryptoServiceProvider();
                //Get some publick keys and private keys
                var privatekey = crypto.ExportParameters(true);
                var publickey = crypto.ExportParameters(false);
                string modulus = Convert.ToBase64String(publickey.Modulus);
                string pubExponent = Convert.ToBase64String(publickey.Exponent);
                string privateExponent = Convert.ToBase64String(privatekey.D);
                modulus = HttpUtility.UrlEncode(modulus);
                pubExponent = HttpUtility.UrlEncode(pubExponent);
                //Generate the ursl using the public key and public exponenet generated
                string req = url + "?cmd=key&terminal_id=" + termialid + "&pkmod=" + modulus + "&pkex=" + pubExponent + "&pkv=1&keyset_id=" + keysetid + "&der_en=1";

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(req);
                Debug.WriteLine(req, "REQUEST");
                request.Method = "GET";
                request.ContentType = "application/xml";
                request.UserAgent = "kimono";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                string responseData = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                Debug.WriteLine(responseData, "RESPONSE");
                modulus = HttpUtility.UrlDecode(modulus);
                string data = asciiToHex(responseData);

                //Decrypt using the private key exponent
                byte[] exp = Convert.FromBase64String(privateExponent);
                byte[] mod = Convert.FromBase64String(modulus);
                string ep = BitConverter.ToString(exp).Replace("-", "");
                string m = BitConverter.ToString(mod).Replace("-", "");
                string d = data.Substring(0, 256);
                string rsaval = "00" + RSADecrypt(d, m, ep);
                string temp = rsaval.Substring(204, 32);
                string checkDigit = TrippleDesEncrypt("0000000000000000", temp);
                Debug.WriteLine(checkDigit, "CHECK DIGIT");
                string ipek = TrippleDesEncrypt("FFFF" + keysetid + "DDDDE0", temp);
                Debug.WriteLine(ipek.Substring(0, 3), "IPEK");
                return true;
            }
            catch
            {
                Debug.WriteLine("8CA64DE9C1B123A7", "CHECK DIGIT");
                return false;
            }
        }

        public static string generateMasterKey()
        {
            string macKey = "0123456789ABCDEFFEDCBA9876543210";
            string pan = "5656781234567891";
            string psn = "01";
            string y = (pan + psn);
            y = y.Substring(y.Length - 16);
            string zl = TrippleDesEncrypt(y, macKey);
            string zr = TrippleDesEncrypt(XORorANDorORfuction(y, "FFFFFFFFFFFFFFFF", "^") , macKey);
            string z = zl + zr;
            System.Windows.Forms.MessageBox.Show(z);
            return "";
        }

        public static string parseXml(string response, string tag)
        {
            string[] resp = response.Split(new string[] { "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < resp.Length; i++)
            {
                if ((resp[i] == tag) && (resp[i] != resp[i + 1]))
                {
                    return resp[i + 1];
                }
            }
            return "";
        }

        public static string getIPEK(string BDK = "0123456789ABCDEFFEDCBA9876543210", string KSN = "FFFF9876543210E00008")
        {
            //Pad the ksn to right with (FFF) 10bytes if it is not 10bytes in lenght;
            string initialBDK = BDK, ksn = KSN.PadLeft(20, 'F'), IPEK = "";
            string bdk = "";
            //if the bdk is not 24byte in length append the first 8 of the BDK to the end of the BDK to give us the 24byte
            if ((initialBDK.Length / 2) < 24)
            {
                string first8 = initialBDK.Substring(0, 16);
                bdk = initialBDK + first8;
                bdk = bdk.Substring(0, 48);
            }
            //Get ksn with a zero counter by ANDing it with FFFFFFFFFFFFFFE00000
            string newKSN = XORorANDorORfuction(ksn, "FFFFFFFFFFFFFFE00000", "&");
            //Get the most significant 8 bytes of the new ksn.
            string last8Byteksn = newKSN.Substring(0, 16);
            //TrippleDES encrypt the last8Byteksn with the 24byte bdk to get the left register of our IPEK
            string leftIPEK = TrippleDesEncrypt(last8Byteksn.Trim(), bdk.Trim());
            //To get the right IPEK, get the original 16byte BDK and XOR it with bdkmask=C0C0C0C000000000C0C0C0C000000000.   
            string bdkinitial2 = XORorANDorORfuction(initialBDK, "C0C0C0C000000000C0C0C0C000000000", "^");
            string bdk2 = "";
            if ((bdkinitial2.Length / 2) < 24)
            {
                string first8 = bdkinitial2.Substring(0, 16);
                bdk2 = bdkinitial2 + first8;
                bdk2 = bdk2.Substring(0, 48);
            }

            string rightIPEK = TrippleDesEncrypt(last8Byteksn.Trim(), bdk2.Trim());
            IPEK = leftIPEK + rightIPEK;
            return IPEK;
        }

        public static string getSessionKey(string IPEK = "6AC292FAA1315B4D858AB3A3D7D5933A", string KSN = "FFFF9876543210E00008")
        {
            string initialIPEK = IPEK, ksn = KSN.PadLeft(20, '0');
            string sessionkey = "";
            //Get ksn with a zero counter by ANDing it with FFFFFFFFFFFFFFE00000
            string newKSN = XORorANDorORfuction(ksn, "0000FFFFFFFFFFE00000", "&");
            string counterKSN = ksn.Substring(ksn.Length - 5).PadLeft(16, '0');
            //get the number of binaray associated with the counterKSN number
            string newKSNtoleft16 = newKSN.Substring(newKSN.Length - 16);
            string counterKSNbin = Convert.ToString(Convert.ToInt32(counterKSN), 2);
            int count = Convert.ToString(Convert.ToInt32(counterKSN), 2).Replace("0", "").Length;
            string binarycount = counterKSNbin;
            for (int i = 0; i < counterKSNbin.Length; i++)
            {
                int len = binarycount.Length; string result = "";
                if (binarycount.Substring(0, 1) == "1")
                {
                    result = "1".PadRight(len, '0');
                    binarycount = binarycount.Substring(1);
                }
                else { binarycount = binarycount.Substring(1); continue; }
                string counterKSN2 = Convert.ToInt32(result, 2).ToString("X2").PadLeft(16, '0');
                string newKSN2 = XORorANDorORfuction(newKSNtoleft16, counterKSN2, "|");
                sessionkey = BlackBoxLogic(newKSN2, initialIPEK);   //Call the blackbox from here to get the session key.
                newKSNtoleft16 = newKSN2;
                initialIPEK = sessionkey;
            }
            //So this will be the working key...which is also the pinblock
            string checkWorkingKey = XORorANDorORfuction(sessionkey, "00000000000000FF00000000000000FF", "^");
            Debug.WriteLine("This is the working key that we're using: " + checkWorkingKey);
            return XORorANDorORfuction(sessionkey, "00000000000000FF00000000000000FF", "^");
        }

        public static string BlackBoxLogic(string ksn, string ipek)
        {
            if (ipek.Length < 32)
            {
                Debug.WriteLine("KSN: " + ksn + "      IPEK: " + ipek);
                string msg = XORorANDorORfuction(ipek, ksn, "^");
                string desreslt = DesEncrypt(msg, ipek);
                string rsesskey = XORorANDorORfuction(desreslt, ipek, "^");
                Debug.WriteLine("The session key is " + rsesskey);
                return rsesskey;
            }
            string current_sk = ipek;
            string ksn_mod = ksn;
            string leftIpek = XORorANDorORfuction(current_sk, "FFFFFFFFFFFFFFFF0000000000000000", "&").Remove(16);
            string rightIpek = XORorANDorORfuction(current_sk, "0000000000000000FFFFFFFFFFFFFFFF", "&").Substring(16);
            string message = XORorANDorORfuction(rightIpek, ksn_mod, "^");
            string desresult = DesEncrypt(message, leftIpek);
            string rightSessionKey = XORorANDorORfuction(desresult, rightIpek, "^");
            string resultCurrent_sk = XORorANDorORfuction(current_sk, "C0C0C0C000000000C0C0C0C000000000", "^");
            string leftIpek2 = XORorANDorORfuction(resultCurrent_sk, "FFFFFFFFFFFFFFFF0000000000000000", "&").Remove(16);
            string rightIpek2 = XORorANDorORfuction(resultCurrent_sk, "0000000000000000FFFFFFFFFFFFFFFF", "&").Substring(16);
            string message2 = XORorANDorORfuction(rightIpek2, ksn_mod, "^");
            string desresult2 = DesEncrypt(message2, leftIpek2);
            string leftSessionKey = XORorANDorORfuction(desresult2, rightIpek2, "^");
            string sessionkey = leftSessionKey + rightSessionKey;
            return sessionkey;
        }

        public static string XORorANDorORfuction(string valueA, string valueB, string symbol = "|")
        {
            char[] a = valueA.ToCharArray();
            char[] b = valueB.ToCharArray();
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (symbol == "|") result += (Convert.ToInt32(a[i].ToString(), 16) | Convert.ToInt32(b[i].ToString(), 16)).ToString("x").ToUpper();
                else if (symbol == "^") result += (Convert.ToInt32(a[i].ToString(), 16) ^ Convert.ToInt32(b[i].ToString(), 16)).ToString("x").ToUpper();
                else result += (Convert.ToInt32(a[i].ToString(), 16) & Convert.ToInt32(b[i].ToString(), 16)).ToString("x").ToUpper();
            }
            return result;
        }

        public static string DesEncryptDukpt(string workingKey, string pan, string clearPin)
        {
            string pinblock = XORorANDorORfuction(workingKey, encryptPinBlock(pan, clearPin), "^");
            byte[] dData = StringToByteArray(pinblock);
            byte[] keyData = StringToByteArray(workingKey);
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            tdes.Key = keyData;
            tdes.Padding = PaddingMode.None;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform transform = tdes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(dData, 0, dData.Length);
            return XORorANDorORfuction(workingKey, BitConverter.ToString(result).Replace("-", ""), "^");
        }

        //This is the part we get the clear pinblock using format 0 of the ISO 9564 standard.
        public static string encryptPinBlock(string pan, string pin)
        {
            pan = pan.Substring(pan.Length - 13, 12).PadLeft(16, '0');
            pin = pin.Length.ToString("X2") + pin.PadRight(16, 'F');
            string clearPinBlock = XORorANDorORfuction(pan, pin, "^");
            Debug.WriteLine("This is the clear pinblock we\'re getting: " + clearPinBlock);
            return XORorANDorORfuction(pan, pin, "^");
        }
    }
}
