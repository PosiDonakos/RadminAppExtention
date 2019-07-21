using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radministrator
{
    public partial class AddorEditIP : Form
    {
        String iD;
        String node;

        public AddorEditIP(String iDValue,String nodeValue)
        {
            InitializeComponent();
            this.Location = new Point(AppMethods.xCord - this.Size.Width, AppMethods.yCord);
            iD = iDValue;
            node = nodeValue;
        }

        private void AddorRemoveIP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void btnLookUP_Click(object sender, EventArgs e)
        {
            AppMethods.SetWindow(this.Location.X, this.Location.Y);
            Form LookUpTable = new LookUp();
            LookUpTable.FormClosed += new FormClosedEventHandler(LookUpTable_FormClosed);
            LookUpTable.ShowDialog(this);   
        }

        private void LookUpTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppMethods.FillComboBoxLookUP(cmBxLookUP);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtBxPort.Text) > 65535)
                MessageBox.Show("ΦΑΣΚΕΛΟ", "Invalid Port", MessageBoxButtons.OK);
            else
            {
                if (AppMethods.CheckForEntry(txtBxIP.Text.Trim(), txtBxPort.Text.Trim(), iD))
                    MessageBox.Show("ΦΑΣΚΕΛΟ", "Duplicate IP and Port Error", MessageBoxButtons.OK);
                else
                {
                    AppMethods.SaveInfoToDB(cmBxLookUP, txtBxDescr.Text.Trim(), txtBxIP.Text.Trim(), txtBxUser.Text.Trim(), txtBxPass.Text.Trim(), txtBxPort.Text.Trim(), txtBxPhone.Text.Trim(), iD);
                    this.Close();
                }
            }            
        }

        private void AddorRemoveIP_Load(object sender, EventArgs e)
        {
            if (iD != null)
                AppMethods.FillAddOrEdit(cmBxLookUP, txtBxDescr, txtBxIP, txtBxUser, txtBxPort, txtBxPass, txtBxPhone, iD);
            else if (iD == null)
                AppMethods.NewAddOrEdit(cmBxLookUP, txtBxUser, txtBxPort, txtBxPass, node);
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
