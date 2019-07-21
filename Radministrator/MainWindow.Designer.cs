namespace Radministrator
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.trViewDB = new System.Windows.Forms.TreeView();
            this.btnCon = new System.Windows.Forms.Button();
            this.btnFt = new System.Windows.Forms.Button();
            this.btnTln = new System.Windows.Forms.Button();
            this.btnThr = new System.Windows.Forms.Button();
            this.btnRef = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTSOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTSAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTSExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTSAddIP = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTlnShut = new System.Windows.Forms.Button();
            this.lstVEq = new System.Windows.Forms.ListView();
            this.NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PORT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATUS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntxMnStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trViewDB
            // 
            this.trViewDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trViewDB.HideSelection = false;
            this.trViewDB.Location = new System.Drawing.Point(13, 35);
            this.trViewDB.Name = "trViewDB";
            this.trViewDB.Size = new System.Drawing.Size(252, 414);
            this.trViewDB.TabIndex = 0;
            this.trViewDB.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trViewDB_AfterSelectAsync);
            // 
            // btnCon
            // 
            this.btnCon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCon.Location = new System.Drawing.Point(692, 134);
            this.btnCon.Name = "BtnCon";
            this.btnCon.Size = new System.Drawing.Size(71, 58);
            this.btnCon.TabIndex = 2;
            this.btnCon.Text = "Connect";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.BtnCon_ClickAsync);
            // 
            // btnFt
            // 
            this.btnFt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFt.Location = new System.Drawing.Point(692, 198);
            this.btnFt.Name = "btnFt";
            this.btnFt.Size = new System.Drawing.Size(71, 58);
            this.btnFt.TabIndex = 3;
            this.btnFt.Text = "File Transfer";
            this.btnFt.UseVisualStyleBackColor = true;
            this.btnFt.Click += new System.EventHandler(this.btnFt_Click);
            // 
            // btnTln
            // 
            this.btnTln.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTln.Location = new System.Drawing.Point(692, 262);
            this.btnTln.Name = "btnTln";
            this.btnTln.Size = new System.Drawing.Size(71, 58);
            this.btnTln.TabIndex = 4;
            this.btnTln.Text = "Telnet";
            this.btnTln.UseVisualStyleBackColor = true;
            this.btnTln.Click += new System.EventHandler(this.btnTln_Click);
            // 
            // btnThr
            // 
            this.btnThr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThr.Location = new System.Drawing.Point(692, 390);
            this.btnThr.Name = "btnThr";
            this.btnThr.Size = new System.Drawing.Size(71, 58);
            this.btnThr.TabIndex = 6;
            this.btnThr.Text = "Through";
            this.btnThr.UseVisualStyleBackColor = true;
            this.btnThr.Click += new System.EventHandler(this.btnThr_Click);
            // 
            // btnRef
            // 
            this.btnRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRef.Location = new System.Drawing.Point(707, 35);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(56, 36);
            this.btnRef.TabIndex = 7;
            this.btnRef.Text = "Refresh List";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTSMenu,
            this.menuTSAddIP});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(774, 24);
            this.menu.TabIndex = 18;
            this.menu.Text = "Menu";
            // 
            // menuTSMenu
            // 
            this.menuTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTSOptions,
            this.menuTSAbout,
            this.menuTSExit});
            this.menuTSMenu.Name = "menuTSMenu";
            this.menuTSMenu.Size = new System.Drawing.Size(50, 20);
            this.menuTSMenu.Text = "Menu";
            // 
            // menuTSOptions
            // 
            this.menuTSOptions.Name = "menuTSOptions";
            this.menuTSOptions.Size = new System.Drawing.Size(116, 22);
            this.menuTSOptions.Text = "Options";
            this.menuTSOptions.Click += new System.EventHandler(this.menuTSOptions_Click);
            // 
            // menuTSAbout
            // 
            this.menuTSAbout.Name = "menuTSAbout";
            this.menuTSAbout.Size = new System.Drawing.Size(116, 22);
            this.menuTSAbout.Text = "About";
            this.menuTSAbout.Click += new System.EventHandler(this.menuTSAbout_Click);
            // 
            // menuTSExit
            // 
            this.menuTSExit.Name = "menuTSExit";
            this.menuTSExit.Size = new System.Drawing.Size(116, 22);
            this.menuTSExit.Text = "Exit";
            this.menuTSExit.Click += new System.EventHandler(this.menuTSExit_Click);
            // 
            // menuTSAddIP
            // 
            this.menuTSAddIP.Name = "menuTSAddIP";
            this.menuTSAddIP.Size = new System.Drawing.Size(54, 20);
            this.menuTSAddIP.Text = "Add IP";
            this.menuTSAddIP.Click += new System.EventHandler(this.menuTSAddIP_Click);
            // 
            // btnTlnShut
            // 
            this.btnTlnShut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTlnShut.Location = new System.Drawing.Point(692, 326);
            this.btnTlnShut.Name = "btnTlnShut";
            this.btnTlnShut.Size = new System.Drawing.Size(71, 58);
            this.btnTlnShut.TabIndex = 5;
            this.btnTlnShut.Text = "Tellnet Shutdown PC";
            this.btnTlnShut.UseVisualStyleBackColor = true;
            this.btnTlnShut.Click += new System.EventHandler(this.btnTlnShut_Click);
            // 
            // lstVEq
            // 
            this.lstVEq.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstVEq.AllowColumnReorder = true;
            this.lstVEq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVEq.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NAME,
            this.IP,
            this.PORT,
            this.STATUS});
            this.lstVEq.FullRowSelect = true;
            this.lstVEq.GridLines = true;
            this.lstVEq.HideSelection = false;
            this.lstVEq.Location = new System.Drawing.Point(271, 35);
            this.lstVEq.Name = "lstVEq";
            this.lstVEq.Size = new System.Drawing.Size(414, 413);
            this.lstVEq.TabIndex = 1;
            this.lstVEq.UseCompatibleStateImageBehavior = false;
            this.lstVEq.View = System.Windows.Forms.View.Details;
            this.lstVEq.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVEq_ColumnClick);
            this.lstVEq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstVEq_MouseClick);
            this.lstVEq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstVEq_MouseDoubleClick);
            // 
            // NAME
            // 
            this.NAME.Text = "NAME";
            this.NAME.Width = 195;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IP.Width = 101;
            // 
            // PORT
            // 
            this.PORT.Text = "PORT";
            this.PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PORT.Width = 52;
            // 
            // STATUS
            // 
            this.STATUS.Text = "STATUS";
            this.STATUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STATUS.Width = 61;
            // 
            // cntxMnStrip
            // 
            this.cntxMnStrip.Name = "cntxMnStrip";
            this.cntxMnStrip.Size = new System.Drawing.Size(61, 4);
            this.cntxMnStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cntxMnStrip_ItemClicked);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnCon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 462);
            this.Controls.Add(this.lstVEq);
            this.Controls.Add(this.btnTlnShut);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.btnThr);
            this.Controls.Add(this.btnTln);
            this.Controls.Add(this.btnFt);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.trViewDB);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 950);
            this.MinimumSize = new System.Drawing.Size(790, 500);
            this.Name = "MainWindow";
            this.Text = "RAuthentication";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trViewDB;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Button btnFt;
        private System.Windows.Forms.Button btnTln;
        private System.Windows.Forms.Button btnThr;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuTSMenu;
        private System.Windows.Forms.ToolStripMenuItem menuTSOptions;
        private System.Windows.Forms.ToolStripMenuItem menuTSExit;
        private System.Windows.Forms.ToolStripMenuItem menuTSAbout;
        private System.Windows.Forms.ToolStripMenuItem menuTSAddIP;
        private System.Windows.Forms.Button btnTlnShut;
        private System.Windows.Forms.ListView lstVEq;
        private System.Windows.Forms.ColumnHeader NAME;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader PORT;
        private System.Windows.Forms.ColumnHeader STATUS;
        private System.Windows.Forms.ContextMenuStrip cntxMnStrip;
    }
}

