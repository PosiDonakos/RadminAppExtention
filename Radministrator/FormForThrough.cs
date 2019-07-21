using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radministrator
{
    public partial class FormForThrough : Form
    {
        public FormForThrough()
        {
            InitializeComponent();
            this.Location = new Point(AppMethods.xCord- this.Size.Width, AppMethods.yCord - this.Size.Height);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AppMethods.throughIP = txtBxIP.Text.Trim();
            AppMethods.throughPort = txtBxPort.Text.Trim();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormForThrough_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
