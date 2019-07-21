using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radministrator
{
    public partial class Settings : Form
    {
        public Settings()
        {            
            InitializeComponent();
            this.Location = new Point(AppMethods.xCord, AppMethods.yCord);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtBxPath.Text = AppMethods.Browser(browser);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtBxPath.Text = AppMethods.ReturnRegistry("Exe");
            AppMethods.FillComboBoxesOfSettings(cmbBxBpp, cmbBxUpdt);
            if (AppMethods.ReturnRegistry("Bpp") == null)
                cmbBxBpp.SelectedIndex = -1;
            else
                cmbBxBpp.SelectedIndex = cmbBxBpp.FindStringExact(AppMethods.ReturnRegistry("Bpp"));
            if (AppMethods.ReturnRegistry("Update") == null)
                cmbBxUpdt.SelectedIndex = -1;
            else
                cmbBxUpdt.SelectedIndex = cmbBxUpdt.FindStringExact(AppMethods.ReturnRegistry("Update"));
            txtBxDefUsr.Text = AppMethods.ReturnRegistry("Def User");
            txtBxDefPas.Text = AppMethods.ReturnRegistry("Def Pass");
            txtBxDefPort.Text = AppMethods.ReturnRegistry("Def Port");
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppMethods.ReturnRegistry("Exe") == null || AppMethods.ReturnRegistry("Bpp") == null
                || AppMethods.ReturnRegistry("Update") == null || AppMethods.ReturnRegistry("Def User") == null
                || AppMethods.ReturnRegistry("Def Pass") == null || AppMethods.ReturnRegistry("Def Port") == null)
                {
                    throw new System.Exception();
                }
            }
            catch (Exception)
            {
                if (MessageBox.Show("If you wanna close the program press Yes, otherwise you must type the info needed to run", "Close Program?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.None;
            try
            {   if (cmbBxUpdt.SelectedValue.ToString() == null || cmbBxBpp.SelectedValue.ToString() == null || txtBxPath.Text == "" || txtBxDefPas.Text == "" || txtBxDefUsr.Text == "" || txtBxDefPort.Text == "")
                    throw new System.Exception();
                AppMethods.SetRegistry("Exe", txtBxPath.Text);
                AppMethods.SetRegistry("Bpp", cmbBxBpp.SelectedValue.ToString());
                AppMethods.SetRegistry("Update", cmbBxUpdt.SelectedValue.ToString());
                AppMethods.SetRegistry("Def User", txtBxDefUsr.Text);
                AppMethods.SetRegistry("Def Pass", txtBxDefPas.Text);
                AppMethods.SetRegistry("Def Port", txtBxDefPort.Text);
            }
            catch(Exception)
            {
                result = MessageBox.Show("Please select a value for all the text boxes", "Error", MessageBoxButtons.OK);
            }
            finally
            {
                if (result == DialogResult.None)
                    this.Close();                    
            }            
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {        
             
        }
    }
}
