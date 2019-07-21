namespace Radministrator
{
    partial class Settings
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
            this.txtBxPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.browser = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBpp = new System.Windows.Forms.Label();
            this.cmbBxBpp = new System.Windows.Forms.ComboBox();
            this.cmbBxUpdt = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtBxDefUsr = new System.Windows.Forms.TextBox();
            this.txtBxDefPas = new System.Windows.Forms.TextBox();
            this.txtBxDefPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBxPath
            // 
            this.txtBxPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBxPath.Location = new System.Drawing.Point(15, 26);
            this.txtBxPath.Name = "txtBxPath";
            this.txtBxPath.Size = new System.Drawing.Size(265, 20);
            this.txtBxPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(302, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 20);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Radmin Installation Folder";
            // 
            // browser
            // 
            this.browser.FileName = "Browser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Update Time for Radmin";
            // 
            // lblBpp
            // 
            this.lblBpp.AutoSize = true;
            this.lblBpp.Location = new System.Drawing.Point(12, 57);
            this.lblBpp.Name = "lblBpp";
            this.lblBpp.Size = new System.Drawing.Size(117, 13);
            this.lblBpp.TabIndex = 13;
            this.lblBpp.Text = "Color Depth for Radmin";
            // 
            // cmbBxBpp
            // 
            this.cmbBxBpp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxBpp.FormattingEnabled = true;
            this.cmbBxBpp.Location = new System.Drawing.Point(15, 77);
            this.cmbBxBpp.Name = "cmbBxBpp";
            this.cmbBxBpp.Size = new System.Drawing.Size(121, 21);
            this.cmbBxBpp.TabIndex = 2;
            // 
            // cmbBxUpdt
            // 
            this.cmbBxUpdt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxUpdt.FormattingEnabled = true;
            this.cmbBxUpdt.Location = new System.Drawing.Point(151, 77);
            this.cmbBxUpdt.Name = "cmbBxUpdt";
            this.cmbBxUpdt.Size = new System.Drawing.Size(121, 21);
            this.cmbBxUpdt.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 117);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 13);
            this.lblUser.TabIndex = 21;
            this.lblUser.Text = "Default Username";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(129, 117);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(90, 13);
            this.lblPass.TabIndex = 22;
            this.lblPass.Text = "Default Password";
            // 
            // txtBxDefUsr
            // 
            this.txtBxDefUsr.Location = new System.Drawing.Point(15, 134);
            this.txtBxDefUsr.Name = "txtBxDefUsr";
            this.txtBxDefUsr.Size = new System.Drawing.Size(100, 20);
            this.txtBxDefUsr.TabIndex = 4;
            // 
            // txtBxDefPas
            // 
            this.txtBxDefPas.Location = new System.Drawing.Point(132, 133);
            this.txtBxDefPas.Name = "txtBxDefPas";
            this.txtBxDefPas.Size = new System.Drawing.Size(100, 20);
            this.txtBxDefPas.TabIndex = 5;
            // 
            // txtBxDefPort
            // 
            this.txtBxDefPort.Location = new System.Drawing.Point(249, 133);
            this.txtBxDefPort.Name = "txtBxDefPort";
            this.txtBxDefPort.Size = new System.Drawing.Size(100, 20);
            this.txtBxDefPort.TabIndex = 6;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(249, 117);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(63, 13);
            this.lblPort.TabIndex = 26;
            this.lblPort.Text = "Default Port";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(376, 244);
            this.ControlBox = false;
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtBxDefPort);
            this.Controls.Add(this.txtBxDefPas);
            this.Controls.Add(this.txtBxDefUsr);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbBxUpdt);
            this.Controls.Add(this.cmbBxBpp);
            this.Controls.Add(this.lblBpp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog browser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBpp;
        private System.Windows.Forms.ComboBox cmbBxBpp;
        private System.Windows.Forms.ComboBox cmbBxUpdt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtBxDefUsr;
        private System.Windows.Forms.TextBox txtBxDefPas;
        private System.Windows.Forms.TextBox txtBxDefPort;
        private System.Windows.Forms.Label lblPort;
    }
}