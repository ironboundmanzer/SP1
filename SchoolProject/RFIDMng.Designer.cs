namespace SchoolProject
{
    partial class RFIDMng
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnConnectUSB = new System.Windows.Forms.Button();
            this.btnReturnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.btnConnectUSB_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(95, 146);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(143, 193);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btnConnectUSB
            // 
            this.btnConnectUSB.Location = new System.Drawing.Point(117, 293);
            this.btnConnectUSB.Name = "btnConnectUSB";
            this.btnConnectUSB.Size = new System.Drawing.Size(75, 50);
            this.btnConnectUSB.TabIndex = 4;
            this.btnConnectUSB.Text = "button1";
            this.btnConnectUSB.UseVisualStyleBackColor = true;
            this.btnConnectUSB.Click += new System.EventHandler(this.btnConnectUSB_Click);
            // 
            // btnReturnButton
            // 
            this.btnReturnButton.Location = new System.Drawing.Point(120, 373);
            this.btnReturnButton.Name = "btnReturnButton";
            this.btnReturnButton.Size = new System.Drawing.Size(75, 26);
            this.btnReturnButton.TabIndex = 5;
            this.btnReturnButton.Text = "Return";
            this.btnReturnButton.UseVisualStyleBackColor = true;
            this.btnReturnButton.Visible = false;
            this.btnReturnButton.Click += new System.EventHandler(this.btnReturnButton_Click);
            // 
            // RFIDMng
            // 
            this.ClientSize = new System.Drawing.Size(312, 400);
            this.Controls.Add(this.btnReturnButton);
            this.Controls.Add(this.btnConnectUSB);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "RFIDMng";
            this.Text = " ";
            this.Load += new System.EventHandler(this.RFIDMng_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnConnectUSB;
        private System.Windows.Forms.Button btnReturnButton;
    }
}