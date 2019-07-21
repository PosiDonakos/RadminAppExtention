namespace Radministrator
{
    partial class LookUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGrdLU = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLU)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrdLU
            // 
            this.dtGrdLU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrdLU.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGrdLU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGrdLU.ColumnHeadersHeight = 30;
            this.dtGrdLU.Location = new System.Drawing.Point(9, 37);
            this.dtGrdLU.MaximumSize = new System.Drawing.Size(280, 700);
            this.dtGrdLU.MinimumSize = new System.Drawing.Size(280, 490);
            this.dtGrdLU.MultiSelect = false;
            this.dtGrdLU.Name = "dtGrdLU";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdLU.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrdLU.RowHeadersWidth = 25;
            this.dtGrdLU.RowTemplate.Height = 25;
            this.dtGrdLU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdLU.Size = new System.Drawing.Size(280, 490);
            this.dtGrdLU.TabIndex = 0;
            this.dtGrdLU.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtGrdLUTbl_UserDeletingRow);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(301, 31);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Location = new System.Drawing.Point(0, 533);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(301, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 562);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtGrdLU);
            this.Name = "LookUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LookUpTable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LookUp_FormClosed);
            this.Load += new System.EventHandler(this.LookUpTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrdLU;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
    }
}