using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;


namespace Radministrator
{
    public partial class MainWindow : Form
    {
        private static ListViewColumnSorter lvwColumnSorter;

        public MainWindow()
        {
            InitializeComponent();            
            lvwColumnSorter = new  ListViewColumnSorter();
            this.lstVEq.ListViewItemSorter = lvwColumnSorter;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (AppMethods.CheckRegistry() == false)
            {
                if (MessageBox.Show("Please enter the settings required in the next form in order for the app to work or press cancel to close the app.", "Missing Radmin executable", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
                    Form Settings = new Settings();
                    Settings.Show(this);
                }
                else
                    this.Close();
            }
            AppMethods.InitRef();
            AppMethods.FillTreeView(trViewDB);
        }

        private async void BtnCon_ClickAsync(object sender, EventArgs e)
        {
            if (!(trViewDB.SelectedNode == null) && (lstVEq.SelectedItems.Count > 0))
            {
                foreach (ListViewItem item in lstVEq.SelectedItems)
                {
                    System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(item.SubItems[4].Text.ToString().Trim());
                    if (dr == null)
                    {
                        MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                        AppMethods.RefreshTreeViewAndListView(trViewDB);
                    }
                    else
                        AppMethods.Connect(1, AppMethods.ReturnRegistry("Exe"), dr);
                }
            }
        }

        private void lstVEq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (lstVEq.SelectedItems.Count == 1))
            {
                System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(lstVEq.SelectedItems[0].SubItems[4].Text.ToString().Trim());
                if (dr == null)
                {
                    MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                    AppMethods.RefreshTreeViewAndListView(trViewDB);
                }
                else
                    AppMethods.Connect(1, AppMethods.ReturnRegistry("Exe"), dr);
            }

        }

        private void btnFt_Click(object sender, EventArgs e)
        {
            if (!(trViewDB.SelectedNode == null) && (lstVEq.SelectedItems.Count > 0))
            {
                foreach (ListViewItem item in lstVEq.SelectedItems)
                {
                    System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(item.SubItems[4].Text.ToString().Trim());
                    if (dr == null)
                    {
                        MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                        AppMethods.RefreshTreeViewAndListView(trViewDB);
                    }
                    else                        
                        AppMethods.Connect(2, AppMethods.ReturnRegistry("Exe"), dr);
                }
            }
        }

        private void btnTln_Click(object sender, EventArgs e)
        {
            if (!(trViewDB.SelectedNode == null) && (lstVEq.SelectedItems.Count > 0))
            {
                foreach (ListViewItem item in lstVEq.SelectedItems)
                {
                    System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(item.SubItems[4].Text.ToString().Trim());
                    if (dr == null)
                    {
                        MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                        AppMethods.RefreshTreeViewAndListView(trViewDB);
                    }
                    else
                        AppMethods.Connect(3, AppMethods.ReturnRegistry("Exe"), dr);
                }                
            }
        }

        private void btnTlnShut_Click(object sender, EventArgs e)
        {
            if (!(trViewDB.SelectedNode == null) && (lstVEq.SelectedItems.Count > 0))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to shutdown "+ trViewDB.SelectedNode.Text + " " + lstVEq.SelectedItems[0].Text, "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lstVEq.SelectedItems)
                    {
                        System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(item.SubItems[4].Text.ToString().Trim());
                        if (dr == null)
                        {
                            MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                            AppMethods.RefreshTreeViewAndListView(trViewDB);
                        }                                                 
                        else                        
                            AppMethods.Connect(4, AppMethods.ReturnRegistry("Exe"), dr);

                    }
                }
            }
        }

        private void btnThr_Click(object sender, EventArgs e)
        {
            if (!(trViewDB.SelectedNode == null) && (lstVEq.SelectedItems.Count > 0))
            {
                System.Data.DataRow dr = AppMethods.RowRetrieverThroughID(lstVEq.SelectedItems[0].SubItems[4].Text.ToString().Trim());
                if (dr == null)
                {
                    MessageBox.Show("The IP you just tried to connect to is no longer valid in the database", "Error in database", MessageBoxButtons.OK);
                    AppMethods.RefreshTreeViewAndListView(trViewDB);
                }
                else
                {
                    AppMethods.throughIP = null;
                    AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y + this.Size.Height);
                    Form FormForThrough = new FormForThrough();                    
                    FormForThrough.ShowDialog();                    
                    if(AppMethods.throughIP != null)                                           
                        AppMethods.Connect(5, AppMethods.ReturnRegistry("Exe"), dr);                                        
                }
            }
        }

        /// <summary>
        /// creation of the right click menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVEq_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lstVEq.FocusedItem.Bounds.Contains(e.Location) && lstVEq.SelectedItems.Count == 1)
            {
                cntxMnStrip.Items.Clear();
                cntxMnStrip.Items.Add("Add New Row");
                cntxMnStrip.Items.Add("Edit Row");
                cntxMnStrip.Items.Add("Delete Row");
                cntxMnStrip.Show(Cursor.Position);
            }
        }

        private async void trViewDB_AfterSelectAsync(object sender, TreeViewEventArgs e)
        {
            AppMethods.CheckIfAnotherSelectionIsRunning(lstVEq, trViewDB);
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            AppMethods.RefreshTreeViewAndListView(trViewDB);
        }

        private void menuTSAbout_Click(object sender, EventArgs e)
        {            
            Form About = new About();
            About.Show(this);
        }

        private void menuTSAddIP_Click(object sender, EventArgs e)
        {
            AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
            Form AddIP = new AddorEditIP(null,trViewDB.SelectedNode.Name);
            AddIP.FormClosed += new FormClosedEventHandler(RefreshLists);
            AddIP.Show(this);
        }

        private void RefreshLists(object sender, EventArgs e)
        {
            AppMethods.RefreshTreeViewAndListView(trViewDB);
        }

        private void menuTSOptions_Click(object sender, EventArgs e)
        {
            AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
            Form Settings = new Settings();
            Settings.Show(this);
        }

        private void menuTSExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Right click menu selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cntxMnStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (cntxMnStrip.Items[0].Selected)
            {
                AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
                Form AddIP = new AddorEditIP(null,trViewDB.SelectedNode.Name);
                AddIP.FormClosed += new FormClosedEventHandler(RefreshLists);
                AddIP.Show(this);

            }
            else if (cntxMnStrip.Items[1].Selected)
            {
                AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
                Form AddIP = new AddorEditIP(lstVEq.SelectedItems[0].SubItems[4].Text.Trim(),null);
                AddIP.FormClosed += new FormClosedEventHandler(RefreshLists);
                AddIP.Show(this);
            }
            else if (cntxMnStrip.Items[2].Selected)
            {
                AppMethods.FindRowToDelete(lstVEq.SelectedItems[0].SubItems[4].Text.Trim());
                AppMethods.RefreshTreeViewAndListView(trViewDB);
            }
        }

        /// <summary>
        /// when f2 is pressed the addoredit form appears
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                AppMethods.SetWindow(this.Location.X + this.Size.Width, this.Location.Y);
                Form AddIP = new AddorEditIP(null,trViewDB.SelectedNode.Name);
                AddIP.FormClosed += new FormClosedEventHandler(RefreshLists);
                AddIP.Show(this);
            }
        }
        
        /// <summary>
        /// method that checks if a column was pressed to get sorted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVEq_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            this.lstVEq.Sort();
        }
    }
}
