namespace HttpRequest_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWorkingkey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIpek = new System.Windows.Forms.TextBox();
            this.txtIKsn = new System.Windows.Forms.TextBox();
            this.numericKsnCount = new System.Windows.Forms.NumericUpDown();
            this.txtWorkingkey = new System.Windows.Forms.TextBox();
            this.txtPan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnc = new System.Windows.Forms.Button();
            this.txtEncPinblock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericKsnCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWorkingkey
            // 
            this.btnWorkingkey.Location = new System.Drawing.Point(285, 114);
            this.btnWorkingkey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWorkingkey.Name = "btnWorkingkey";
            this.btnWorkingkey.Size = new System.Drawing.Size(149, 32);
            this.btnWorkingkey.TabIndex = 0;
            this.btnWorkingkey.Text = "WORKING KEY";
            this.btnWorkingkey.UseVisualStyleBackColor = true;
            this.btnWorkingkey.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPEK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "IKSN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "KSN COUNTER";
            // 
            // txtIpek
            // 
            this.txtIpek.Location = new System.Drawing.Point(68, 11);
            this.txtIpek.Margin = new System.Windows.Forms.Padding(4);
            this.txtIpek.Name = "txtIpek";
            this.txtIpek.Size = new System.Drawing.Size(364, 22);
            this.txtIpek.TabIndex = 4;
            this.txtIpek.Text = "9F8011E7E71E483B";
            // 
            // txtIKsn
            // 
            this.txtIKsn.Location = new System.Drawing.Point(68, 43);
            this.txtIKsn.Margin = new System.Windows.Forms.Padding(4);
            this.txtIKsn.Name = "txtIKsn";
            this.txtIKsn.Size = new System.Drawing.Size(364, 22);
            this.txtIKsn.TabIndex = 5;
            this.txtIKsn.Text = "0000000006DDDDE00000";
            // 
            // numericKsnCount
            // 
            this.numericKsnCount.Location = new System.Drawing.Point(139, 75);
            this.numericKsnCount.Margin = new System.Windows.Forms.Padding(4);
            this.numericKsnCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericKsnCount.Name = "numericKsnCount";
            this.numericKsnCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericKsnCount.Size = new System.Drawing.Size(295, 22);
            this.numericKsnCount.TabIndex = 6;
            this.numericKsnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericKsnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericKsnCount.ValueChanged += new System.EventHandler(this.numericKsnCount_ValueChanged);
            // 
            // txtWorkingkey
            // 
            this.txtWorkingkey.Location = new System.Drawing.Point(139, 153);
            this.txtWorkingkey.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkingkey.Multiline = true;
            this.txtWorkingkey.Name = "txtWorkingkey";
            this.txtWorkingkey.Size = new System.Drawing.Size(293, 24);
            this.txtWorkingkey.TabIndex = 7;
            // 
            // txtPan
            // 
            this.txtPan.Location = new System.Drawing.Point(60, 196);
            this.txtPan.Margin = new System.Windows.Forms.Padding(4);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(211, 22);
            this.txtPan.TabIndex = 9;
            this.txtPan.Text = "5399130000002345";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "PAN";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(328, 196);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(105, 22);
            this.txtPin.TabIndex = 11;
            this.txtPin.Text = "1234";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "PIN";
            // 
            // btnEnc
            // 
            this.btnEnc.Location = new System.Drawing.Point(285, 240);
            this.btnEnc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(149, 32);
            this.btnEnc.TabIndex = 12;
            this.btnEnc.Text = "ENC PINBLOCK";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // txtEncPinblock
            // 
            this.txtEncPinblock.Location = new System.Drawing.Point(139, 278);
            this.txtEncPinblock.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncPinblock.Multiline = true;
            this.txtEncPinblock.Name = "txtEncPinblock";
            this.txtEncPinblock.Size = new System.Drawing.Size(293, 24);
            this.txtEncPinblock.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "WORKING KEY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 282);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "ENC PINBLOCK";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 335);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEncPinblock);
            this.Controls.Add(this.btnEnc);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWorkingkey);
            this.Controls.Add(this.numericKsnCount);
            this.Controls.Add(this.txtIKsn);
            this.Controls.Add(this.txtIpek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWorkingkey);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "DUKPT CALCULATOR (ISW)";
            ((System.ComponentModel.ISupportInitialize)(this.numericKsnCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWorkingkey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIpek;
        private System.Windows.Forms.TextBox txtIKsn;
        private System.Windows.Forms.NumericUpDown numericKsnCount;
        private System.Windows.Forms.TextBox txtWorkingkey;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnc;
        private System.Windows.Forms.TextBox txtEncPinblock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

