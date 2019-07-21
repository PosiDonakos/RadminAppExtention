namespace Radministrator
{
    partial class LookUpTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGrdLUTbl = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLUTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrdLUTbl
            // 
            this.dtGrdLUTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrdLUTbl.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGrdLUTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGrdLUTbl.ColumnHeadersHeight = 30;
            this.dtGrdLUTbl.Location = new System.Drawing.Point(12, 37);
            this.dtGrdLUTbl.MaximumSize = new System.Drawing.Size(230, 700);
            this.dtGrdLUTbl.MinimumSize = new System.Drawing.Size(214, 490);
            this.dtGrdLUTbl.MultiSelect = false;
            this.dtGrdLUTbl.Name = "dtGrdLUTbl";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdLUTbl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdLUTbl.RowHeadersWidth = 25;
            this.dtGrdLUTbl.RowTemplate.Height = 25;
            this.dtGrdLUTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdLUTbl.Size = new System.Drawing.Size(214, 490);
            this.dtGrdLUTbl.TabIndex = 0;
            this.dtGrdLUTbl.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtGrdLUTbl_UserDeletingRow);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(236, 31);
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
            this.btnExit.Size = new System.Drawing.Size(236, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LookUpTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 562);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtGrdLUTbl);
            this.Name = "LookUpTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LookUpTable";
            this.Load += new System.EventHandler(this.LookUpTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLUTbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrdLUTbl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
    }
}