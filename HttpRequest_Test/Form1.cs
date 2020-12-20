using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HttpRequest_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime dt = new DateTime(2020, 12, 31, 07, 00, 00);

            int expdate = DateTime.Compare(dt, DateTime.Now);
            Debug.WriteLine("The expiration date returned in this format is " + expdate);
            if (expdate < 1)
            {
                MessageBox.Show("Application has expired, Please contact interswitch");
                //Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIKsn.Text.Length != 20)
            {
                MessageBox.Show("IKSN must be 10bytes");
                return;
            }

            if (txtIpek.Text.Length == 16 || txtIpek.Text.Length == 32)
            {
                try
                {
                    string workingkey = Keys.getSessionKey(txtIpek.Text, txtIKsn.Text.Substring(0, (txtIKsn.Text.Length - numericKsnCount.Value.ToString().Length)) + numericKsnCount.Value.ToString());
                    txtWorkingkey.Text = workingkey;
                    
                }
                catch
                {
                    MessageBox.Show("Wrong input data");
                    return;
                }
            }
            else
            {
                MessageBox.Show("IPEK must be 32bytes or 8bytes");
                return;
            }
        }

        private void btnEnc_Click(object sender, EventArgs e)
        {
            string pan = txtPan.Text;
            string pin = txtPin.Text;
            string workingKey = txtWorkingkey.Text;

            if(workingKey == "")
            {
                MessageBox.Show("Please generate working key first");
                return;
            }

            if(pan == "" || pin == "")
            {
                MessageBox.Show("Please input the pan and pin");
                return;
            }

            try
            {
                if(workingKey.Length == 16)
                {
                    string pinblock = Keys.DesEncryptDukpt(workingKey, pan, pin);
                    txtEncPinblock.Text = pinblock;
                }
                else
                {
                    string pinblock = Keys.TrippleDesEncrypt(Keys.encryptPinBlock(pan, pin), workingKey);
                    txtEncPinblock.Text = pinblock;
                }
            }
            catch
            {
                MessageBox.Show("Wrong input data");
                return;
            }
        }

        private void numericKsnCount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
