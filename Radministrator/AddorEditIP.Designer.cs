namespace Radministrator
{
    partial class AddorEditIP
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBxDescr = new System.Windows.Forms.TextBox();
            this.txtBxIP = new System.Windows.Forms.TextBox();
            this.txtBxUser = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtBxPass = new System.Windows.Forms.TextBox();
            this.txtBxPort = new System.Windows.Forms.TextBox();
            this.lblDescr = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblLookUP = new System.Windows.Forms.Label();
            this.cmBxLookUP = new System.Windows.Forms.ComboBox();
            this.btnLookUP = new System.Windows.Forms.Button();
            this.txtBxPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(62, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBxDescr
            // 
            this.txtBxDescr.Location = new System.Drawing.Point(80, 57);
            this.txtBxDescr.Name = "txtBxDescr";
            this.txtBxDescr.Size = new System.Drawing.Size(145, 20);
            this.txtBxDescr.TabIndex = 1;
            // 
            // txtBxIP
            // 
            this.txtBxIP.Location = new System.Drawing.Point(80, 31);
            this.txtBxIP.Name = "txtBxIP";
            this.txtBxIP.Size = new System.Drawing.Size(145, 20);
            this.txtBxIP.TabIndex = 0;
            // 
            // txtBxUser
            // 
            this.txtBxUser.Location = new System.Drawing.Point(80, 83);
            this.txtBxUser.Name = "txtBxUser";
            this.txtBxUser.Size = new System.Drawing.Size(145, 20);
            this.txtBxUser.TabIndex = 3;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(16, 34);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 13);
            this.lblIP.TabIndex = 6;
            this.lblIP.Text = "IP";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 138);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Location = new System.Drawing.Point(16, 86);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(57, 13);
            this.lblUsr.TabIndex = 8;
            this.lblUsr.Text = "UserName";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(16, 112);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Password";
            // 
            // txtBxPass
            // 
            this.txtBxPass.Location = new System.Drawing.Point(80, 109);
            this.txtBxPass.Name = "txtBxPass";
            this.txtBxPass.PasswordChar = '•';
            this.txtBxPass.Size = new System.Drawing.Size(145, 20);
            this.txtBxPass.TabIndex = 4;
            this.txtBxPass.Enter += new System.EventHandler(this.txtBxPass_Enter);
            this.txtBxPass.Leave += new System.EventHandler(this.txtBxPass_Leave);
            // 
            // txtBxPort
            // 
            this.txtBxPort.Location = new System.Drawing.Point(80, 135);
            this.txtBxPort.Name = "txtBxPort";
            this.txtBxPort.Size = new System.Drawing.Size(145, 20);
            this.txtBxPort.TabIndex = 5;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Location = new System.Drawing.Point(16, 60);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(60, 13);
            this.lblDescr.TabIndex = 13;
            this.lblDescr.Text = "Description";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(0, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(100, 23);
            this.lblID.TabIndex = 18;
            // 
            // lblLookUP
            // 
            this.lblLookUP.AutoSize = true;
            this.lblLookUP.Location = new System.Drawing.Point(16, 190);
            this.lblLookUP.Name = "lblLookUP";
            this.lblLookUP.Size = new System.Drawing.Size(46, 13);
            this.lblLookUP.TabIndex = 15;
            this.lblLookUP.Text = "LookUP";
            // 
            // cmBxLookUP
            // 
            this.cmBxLookUP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmBxLookUP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxLookUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxLookUP.FormattingEnabled = true;
            this.cmBxLookUP.Location = new System.Drawing.Point(80, 187);
            this.cmBxLookUP.MaxDropDownItems = 5;
            this.cmBxLookUP.Name = "cmBxLookUP";
            this.cmBxLookUP.Size = new System.Drawing.Size(145, 21);
            this.cmBxLookUP.TabIndex = 7;
            // 
            // btnLookUP
            // 
            this.btnLookUP.Location = new System.Drawing.Point(232, 187);
            this.btnLookUP.Name = "btnLookUP";
            this.btnLookUP.Size = new System.Drawing.Size(80, 21);
            this.btnLookUP.TabIndex = 10;
            this.btnLookUP.Text = "Edit LookUp";
            this.btnLookUP.UseVisualStyleBackColor = true;
            this.btnLookUP.Click += new System.EventHandler(this.btnLookUP_Click);
            // 
            // txtBxPhone
            // 
            this.txtBxPhone.Location = new System.Drawing.Point(80, 161);
            this.txtBxPhone.Name = "txtBxPhone";
            this.txtBxPhone.Size = new System.Drawing.Size(145, 20);
            this.txtBxPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(16, 164);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "Phone";
            // 
            // AddorRemoveIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 272);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtBxPhone);
            this.Controls.Add(this.btnLookUP);
            this.Controls.Add(this.cmBxLookUP);
            this.Controls.Add(this.lblLookUP);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.txtBxPort);
            this.Controls.Add(this.txtBxPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtBxUser);
            this.Controls.Add(this.txtBxIP);
            this.Controls.Add(this.txtBxDescr);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.MaximumSize = new System.Drawing.Size(340, 330);
            this.MinimumSize = new System.Drawing.Size(340, 310);
            this.Name = "AddorRemoveIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add or Remove IP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddorRemoveIP_FormClosed);
            this.Load += new System.EventHandler(this.AddorRemoveIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBxDescr;
        private System.Windows.Forms.TextBox txtBxIP;
        private System.Windows.Forms.TextBox txtBxUser;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtBxPass;
        private System.Windows.Forms.TextBox txtBxPort;
        private System.Windows.Forms.Label lblDescr;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLookUP;
        private System.Windows.Forms.Button btnLookUP;
        private System.Windows.Forms.ComboBox cmBxLookUP;
        private System.Windows.Forms.TextBox txtBxPhone;
        private System.Windows.Forms.Label lblPhone;
    }
}