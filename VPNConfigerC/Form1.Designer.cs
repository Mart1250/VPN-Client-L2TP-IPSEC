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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Vpnconfiger));
            this.bConnect = new System.Windows.Forms.Button();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.lStatusstate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            resources.ApplyResources(this.bConnect, "bConnect");
            this.bConnect.Name = "bConnect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bDisconnect
            // 
            resources.ApplyResources(this.bDisconnect, "bDisconnect");
            this.bDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // lStatus
            // 
            resources.ApplyResources(this.lStatus, "lStatus");
            this.lStatus.Name = "lStatus";
            // 
            // lStatusstate
            // 
            resources.ApplyResources(this.lStatusstate, "lStatusstate");
            this.lStatusstate.Name = "lStatusstate";
            // 
            // f_Vpnconfiger
            // 
            this.AcceptButton = this.bConnect;
            resources.ApplyResources(this, "$this");
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bDisconnect;
            this.Controls.Add(this.lStatusstate);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bDisconnect);
            this.Controls.Add(this.bConnect);
            this.DoubleBuffered = true;
            this.Name = "f_Vpnconfiger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bConnect;
        public System.Windows.Forms.Button bDisconnect;
        public System.Windows.Forms.Label lStatus;
        public System.Windows.Forms.Label lStatusstate;
    }
}

