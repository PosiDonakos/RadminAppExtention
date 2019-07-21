using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radministrator
{
    public partial class LookUpTable : Form
    {
        public LookUpTable()
        {
            InitializeComponent();            
            this.Location = new Point(AppMethods.xCord,AppMethods.yCord);
        }

        private void LookUpTable_Load(object sender, EventArgs e)
        {
            AppMethods.FillDataGridforLookUp(dtGrdLUTbl);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AppMethods.UpdateDatabaseLookUP(dtGrdLUTbl);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGrdLUTbl_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Do you want really to delete the selected row", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes; ;
        }

    }
    
}
