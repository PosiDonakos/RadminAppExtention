using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radministrator
{
    public partial class AddorRemoveIP : Form
    {
        String ID;
        public AddorRemoveIP(String value)
        {
            InitializeComponent();
            this.Location = new Point(AppMethods.xCord, AppMethods.yCord);
            ID = value;
        }

        private void AddorRemoveIP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void btnLookUP_Click(object sender, EventArgs e)
        {
            AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
            Form LookUpTable = new LookUpTable();
            LookUpTable.FormClosed += new FormClosedEventHandler(LookUpTable_FormClosed);
            LookUpTable.Show(this);   
        }

        private void LookUpTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppMethods.FillComboBoxLookUP(cmBxLookUP);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AppMethods.CheckForEntry(txtBxIP.Text.Trim(), txtBxPort.Text.Trim(), ID))
                MessageBox.Show("ΦΑΣΚΕΛΟ", "Duplicate IP and Port Error", MessageBoxButtons.OK);
            else
            {
                AppMethods.SaveInfoToDB(cmBxLookUP, txtBxDescr.Text.Trim(), txtBxIP.Text.Trim(), txtBxUser.Text.Trim(), txtBxPass.Text.Trim(), txtBxPort.Text.Trim(), txtBxPhone.Text.Trim(), ID);
                this.Close();
            }
        }

        private void AddorRemoveIP_Load(object sender, EventArgs e)
        {
            if (ID != null)
                AppMethods.FillAddOrRemove(cmBxLookUP, txtBxDescr, txtBxIP, txtBxUser, txtBxPort, txtBxPass, txtBxPhone, ID);
            else if (ID == null)
                AppMethods.NewAddOrRemove(cmBxLookUP, txtBxUser, txtBxPort, txtBxPass);
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBxPass_Enter(object sender, EventArgs e)
        {
            txtBxPass.PasswordChar = '\0';
        }

        private void txtBxPass_Leave(object sender, EventArgs e)
        {
            
            txtBxPass.PasswordChar = '•';
        }
    }
}
