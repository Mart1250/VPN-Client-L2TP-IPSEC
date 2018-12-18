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
        /// the contents of f_Vpnconfiger method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            f_Vpnconfiger.bConnect = new System.Windows.Forms.Button();
            f_Vpnconfiger.bDisconnect = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            f_Vpnconfiger.lStatusstate = new System.Windows.Forms.Label();
            this.lLocation = new System.Windows.Forms.Label();
            f_Vpnconfiger.lLocationname = new System.Windows.Forms.Label();
            f_Vpnconfiger.tKey = new System.Windows.Forms.TextBox();
            f_Vpnconfiger.tPassword = new System.Windows.Forms.TextBox();
            this.lSleutel = new System.Windows.Forms.Label();
            this.lWachtwoord = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            f_Vpnconfiger.tUsername = new System.Windows.Forms.TextBox();
            f_Vpnconfiger.bReset = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.lTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            f_Vpnconfiger.bConnect.Enabled = false;
            f_Vpnconfiger.bConnect.Location = new System.Drawing.Point(151, 197);
            f_Vpnconfiger.bConnect.Name = "bConnect";
            f_Vpnconfiger.bConnect.Size = new System.Drawing.Size(124, 23);
            f_Vpnconfiger.bConnect.TabIndex = 0;
            f_Vpnconfiger.bConnect.Text = "Connect";
            f_Vpnconfiger.bConnect.UseVisualStyleBackColor = true;
            f_Vpnconfiger.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bDisconnect
            // 
            f_Vpnconfiger.bDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            f_Vpnconfiger.bDisconnect.Enabled = false;
            f_Vpnconfiger.bDisconnect.Location = new System.Drawing.Point(12, 197);
            f_Vpnconfiger.bDisconnect.Name = "bDisconnect";
            f_Vpnconfiger.bDisconnect.Size = new System.Drawing.Size(124, 23);
            f_Vpnconfiger.bDisconnect.TabIndex = 1;
            f_Vpnconfiger.bDisconnect.Text = "Disconnect";
            f_Vpnconfiger.bDisconnect.UseVisualStyleBackColor = true;
            f_Vpnconfiger.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(16, 163);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(40, 13);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "Status:";
            // 
            // lStatusstate
            // 
            f_Vpnconfiger.lStatusstate.AutoSize = true;
            f_Vpnconfiger.lStatusstate.Location = new System.Drawing.Point(62, 163);
            f_Vpnconfiger.lStatusstate.Name = "lStatusstate";
            f_Vpnconfiger.lStatusstate.Size = new System.Drawing.Size(73, 13);
            f_Vpnconfiger.lStatusstate.TabIndex = 3;
            f_Vpnconfiger.lStatusstate.Text = "Disconnected";
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Location = new System.Drawing.Point(16, 176);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(51, 13);
            this.lLocation.TabIndex = 14;
            this.lLocation.Text = "Location:";
            // 
            // lLocationname
            // 
            f_Vpnconfiger.lLocationname.AutoSize = true;
            f_Vpnconfiger.lLocationname.Location = new System.Drawing.Point(62, 176);
            f_Vpnconfiger.lLocationname.Name = "lLocationname";
            f_Vpnconfiger.lLocationname.Size = new System.Drawing.Size(73, 13);
            f_Vpnconfiger.lLocationname.TabIndex = 3;
            f_Vpnconfiger.lLocationname.Text = "";
            // 
            // tKey
            // 
            f_Vpnconfiger.tKey.Location = new System.Drawing.Point(12, 25);
            f_Vpnconfiger.tKey.Name = "tKey";
            f_Vpnconfiger.tKey.Size = new System.Drawing.Size(260, 20);
            f_Vpnconfiger.tKey.TabIndex = 5;
            // 
            // tPassword
            // 
            f_Vpnconfiger.tPassword.Location = new System.Drawing.Point(12, 121);
            f_Vpnconfiger.tPassword.Name = "tPassword";
            f_Vpnconfiger.tPassword.PasswordChar = '*';
            f_Vpnconfiger.tPassword.Size = new System.Drawing.Size(263, 20);
            f_Vpnconfiger.tPassword.TabIndex = 6;
            // 
            // lSleutel
            // 
            this.lSleutel.AutoSize = true;
            this.lSleutel.Location = new System.Drawing.Point(17, 9);
            this.lSleutel.Name = "lSleutel";
            this.lSleutel.Size = new System.Drawing.Size(42, 13);
            this.lSleutel.TabIndex = 8;
            this.lSleutel.Text = "Presharedkey:";
            // 
            // lWachtwoord
            // 
            this.lWachtwoord.AutoSize = true;
            this.lWachtwoord.Location = new System.Drawing.Point(17, 105);
            this.lWachtwoord.Name = "lWachtwoord";
            this.lWachtwoord.Size = new System.Drawing.Size(71, 13);
            this.lWachtwoord.TabIndex = 9;
            this.lWachtwoord.Text = "Password:";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(17, 57);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(87, 13);
            this.lUsername.TabIndex = 10;
            this.lUsername.Text = "Username:";
            // 
            // tUsername
            // 
            f_Vpnconfiger.tUsername.Location = new System.Drawing.Point(12, 73);
            f_Vpnconfiger.tUsername.Name = "tUsername";
            f_Vpnconfiger.tUsername.Size = new System.Drawing.Size(260, 20);
            f_Vpnconfiger.tUsername.TabIndex = 11;
            // 
            // bReset
            // 
            f_Vpnconfiger.bReset.Location = new System.Drawing.Point(151, 158);
            f_Vpnconfiger.bReset.Name = "bReset";
            f_Vpnconfiger.bReset.Size = new System.Drawing.Size(124, 23);
            f_Vpnconfiger.bReset.TabIndex = 12;
            f_Vpnconfiger.bReset.Text = "Reset";
            f_Vpnconfiger.bReset.UseVisualStyleBackColor = true;
            f_Vpnconfiger.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // notify
            // 
            this.notify.Text = "Vpn Client";
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseClick);
            // 
            // lTip
            // 
            this.lTip.Location = new System.Drawing.Point(12, 232);
            this.lTip.Name = "lTip";
            this.lTip.Size = new System.Drawing.Size(266, 43);
            this.lTip.TabIndex = 13;
            this.lTip.Text = "Hint: Is the connection not established? Try waiting 10 to 15 seconds and then try again";
            // 
            // f_Vpnconfiger
            // 
            this.AcceptButton = f_Vpnconfiger.bConnect;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = f_Vpnconfiger.bDisconnect;
            this.ClientSize = new System.Drawing.Size(284, 278);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(this.lTip);
            this.Controls.Add(f_Vpnconfiger.bReset);
            this.Controls.Add(f_Vpnconfiger.tUsername);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.lWachtwoord);
            this.Controls.Add(this.lSleutel);
            this.Controls.Add(f_Vpnconfiger.tPassword);
            this.Controls.Add(f_Vpnconfiger.tKey);
            this.Controls.Add(f_Vpnconfiger.lStatusstate);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(f_Vpnconfiger.lLocationname);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(f_Vpnconfiger.bDisconnect);
            this.Controls.Add(f_Vpnconfiger.bConnect);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_Vpnconfiger";
            this.Text = "Vpn Client";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Vpnconfiger_FormClosing);
            this.Load += new System.EventHandler(this.f_Vpnconfiger_Load);
            this.Resize += new System.EventHandler(this.f_Vpnconfiger_Resize_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public static System.Windows.Forms.Button bConnect;
        public static System.Windows.Forms.Button bDisconnect;
        public System.Windows.Forms.Label lStatus;
        public static System.Windows.Forms.Label lStatusstate;
        public System.Windows.Forms.Label lLocation;
        public static System.Windows.Forms.Label lLocationname;
        public static System.Windows.Forms.TextBox tKey;
        public static System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label lSleutel;
        private System.Windows.Forms.Label lWachtwoord;
        private System.Windows.Forms.Label lUsername;
        public static System.Windows.Forms.TextBox tUsername;
        public static System.Windows.Forms.Button bReset;
        public System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Label lTip;
    }
}

