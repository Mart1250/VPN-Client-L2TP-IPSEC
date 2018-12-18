namespace VPNConfigerC
{
    partial class f_Vpnconfiger
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
            this.bConnect = new System.Windows.Forms.Button();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.lStatusstate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LSleutel = new System.Windows.Forms.Label();
            this.LWachtwoord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Enabled = false;
            this.bConnect.Location = new System.Drawing.Point(148, 212);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(124, 23);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bDisconnect
            // 
            this.bDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bDisconnect.Enabled = false;
            this.bDisconnect.Location = new System.Drawing.Point(12, 212);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(124, 23);
            this.bDisconnect.TabIndex = 1;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(12, 183);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(40, 13);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "Status:";
            // 
            // lStatusstate
            // 
            this.lStatusstate.AutoSize = true;
            this.lStatusstate.Location = new System.Drawing.Point(58, 183);
            this.lStatusstate.Name = "lStatusstate";
            this.lStatusstate.Size = new System.Drawing.Size(73, 13);
            this.lStatusstate.TabIndex = 3;
            this.lStatusstate.Text = "Disconnected";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(260, 20);
            this.textBox2.TabIndex = 6;
            // 
            // LSleutel
            // 
            this.LSleutel.AutoSize = true;
            this.LSleutel.Location = new System.Drawing.Point(17, 9);
            this.LSleutel.Name = "LSleutel";
            this.LSleutel.Size = new System.Drawing.Size(42, 13);
            this.LSleutel.TabIndex = 8;
            this.LSleutel.Text = "Sleutel:";
            // 
            // LWachtwoord
            // 
            this.LWachtwoord.AutoSize = true;
            this.LWachtwoord.Location = new System.Drawing.Point(17, 48);
            this.LWachtwoord.Name = "LWachtwoord";
            this.LWachtwoord.Size = new System.Drawing.Size(71, 13);
            this.LWachtwoord.TabIndex = 9;
            this.LWachtwoord.Text = "Wachtwoord:";
            // 
            // f_Vpnconfiger
            // 
            this.AcceptButton = this.bConnect;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bDisconnect;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LWachtwoord);
            this.Controls.Add(this.LSleutel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lStatusstate);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bDisconnect);
            this.Controls.Add(this.bConnect);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_Vpnconfiger";
            this.Text = "VPNConfiger";
            this.Load += new System.EventHandler(this.f_Vpnconfiger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bConnect;
        public System.Windows.Forms.Button bDisconnect;
        public System.Windows.Forms.Label lStatus;
        public System.Windows.Forms.Label lStatusstate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LSleutel;
        private System.Windows.Forms.Label LWachtwoord;
    }
}

