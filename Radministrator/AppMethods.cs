
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Net.Sockets;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Linq;

namespace Radministrator
{
    class AppMethods
    {

        [STAThread]

        [DllImport("user32.dll")] static extern int GetClassName();

        [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr WindowHandle);

        [DllImport("user32.dll")] static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern Int32 SendMessage(IntPtr hwnd, int msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll")] static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);

        [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);


        // ----------------------------  INITIALIZATION OF SOME ITEMS ---------------------------------------

        protected static OleDbConnection conn = new OleDbConnection("File Name =" + Application.StartupPath + @"\Connection.udl");
        protected static OleDbCommandBuilder oleDBCommBuilder = new OleDbCommandBuilder();
        protected static OleDbCommand comm = new OleDbCommand();
        protected static OleDbDataAdapter adaIPs, adaLookUp;
        public static CancellationTokenSource cancellTknSrcFromOtherSelection;
        public static int xCord = 0, yCord = 0;
        public static string throughIP = null, throughPort = null;
        public static DataTable dtTableForLookUp = new DataTable(), dtTableForCmBxLU = new DataTable(), dtTableForCmBxBI = new DataTable(),
            dtTableIPs = new DataTable(), dtTableLookUp = new DataTable();
        protected static BindingSource bindingSource = new BindingSource();
        public static Font font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
        protected static ListViewItem item = new ListViewItem();
        protected static List<ListViewItem> itemList = new List<ListViewItem>();
        

        /// <summary>
        /// initialization of the data adapters and the datatables
        /// </summary>
        public static void InitRef()
        {
            adaIPs = GetInfoFromDB("Select ID, IpAddress, Descr, Username, Pass, Port, Phone, [LookUP] from IPsInfo");
            dtTableIPs.Clear();
            adaIPs.Fill(dtTableIPs);

            adaLookUp = GetInfoFromDB("Select ID, Descr, ParentID, IDDescr From vLookUP");
            dtTableLookUp.Clear();
            adaLookUp.Fill(dtTableLookUp);
        }

        /// <summary>
        /// some constants that are needed for the dlls
        /// </summary>
        internal static class DefineConstants
        {
            public const int WM_COMMAND = 273;
            public const int BN_CLICKED = 16;
            public const int ButtonOkId = 120;
            public const int WM_SETTEXT = 12;
        }

        /// <summary>
        /// fills the data adapters with info from the data base
        /// </summary>
        /// <param name="query"> the query that will excecute </param>
        /// <returns> data adapter with data </returns>
        public static OleDbDataAdapter GetInfoFromDB(String query)
        {
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("Please install the Microsoft Access Database Engine 2010 Redistributable x64 version in order to continue since OleDB is not registered in your pc (In case you still have a problem this app needs Access 2010 or newer to run on x64 and it is only for x64 systems)", "OleDB 16 was not found", MessageBoxButtons.OK);
            }
            
            OleDbDataAdapter tmp = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder tmpCmd = new OleDbCommandBuilder(tmp);
            conn.Close();
            return tmp;
        }


        // ---------------------------- HANDLING THE WINDOW OF RADMIN -----------------------------------------

        /// <summary>
        /// method to focus the radmin window prompt
        /// </summary>
        /// <param name="window"> name of the radmin window prompt </param>
        /// <param name="user"> username of the connection </param>
        /// <param name="pass"> password of the connection </param>
        private static void FocusProcess(string window, String user, String pass)
        {
            IntPtr hWnd = IntPtr.Zero;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            do
            {
                hWnd = FindWindow(null, window);
            }
            while ((hWnd == IntPtr.Zero) && (timer.Elapsed.TotalSeconds < 11));
            timer.Stop();
            if (!(hWnd == IntPtr.Zero))
            {
                IntPtr userNameTxt = FindWindowEx(hWnd, IntPtr.Zero, "Edit", null);
                IntPtr passwordTxt = FindWindowEx(hWnd, userNameTxt, "Edit", null);
                IntPtr okButton = FindWindowEx(hWnd, IntPtr.Zero, "Button", "OK");

                SendMessage(userNameTxt, DefineConstants.WM_SETTEXT, IntPtr.Zero, new StringBuilder(user));
                SendMessage(passwordTxt, DefineConstants.WM_SETTEXT, IntPtr.Zero, new StringBuilder(pass));

                IntPtr hWndButton = GetDlgItem(hWnd, DefineConstants.ButtonOkId);
                int wParam = (DefineConstants.BN_CLICKED) | (DefineConstants.ButtonOkId & 0xffff);
                SendMessage(hWnd, DefineConstants.WM_COMMAND, wParam, hWndButton);
            }
        }

        /// <summary>
        /// method to focus the telnet so the shutdown line can be sent
        /// </summary>
        /// <param name="window"> name of the radmin telnet </param>
        public static void FocusTelnet(string window)
        {
            IntPtr hWnd = IntPtr.Zero;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            do
            {
                hWnd = FindWindow(null, window);
            }
            while ((hWnd == IntPtr.Zero) && (timer.Elapsed.TotalSeconds < 6));
            timer.Stop();

            SendKeys.SendWait(@"shutdown /f /r /t 1");
            SendKeys.SendWait("{ENTER}");
        }

        
        public static void FocusRadminWindowToBringItForeground(string window)
        {
            IntPtr hWnd = IntPtr.Zero;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            do
            {
                hWnd = FindWindow(null, window);
            }
            while ((hWnd == IntPtr.Zero) && (timer.Elapsed.TotalSeconds < 6));
            timer.Stop();

        }


        // ---------------------------- FILLING OF LISTS AND COMBOBOXES --------------------------------------

        /// <summary>
        /// refreshes the listview and treeview with data from the database and also selects the treenode that was selected before the refresh method was called
        /// </summary>
        /// <param name="trViewDB"> treeview of the main window </param>
        public static void RefreshTreeViewAndListView(TreeView trViewDB)
        {
            InitRef();
            TreeNode selectedNode = trViewDB.SelectedNode;
            FillTreeView(trViewDB);
            if (selectedNode != null)
            {
                trViewDB.SelectedNode = null;
                foreach (TreeNode tn in trViewDB.Nodes)
                {
                    if (tn.Name == selectedNode.Name)                    
                        trViewDB.SelectedNode = tn;
                    foreach(TreeNode tn2 in tn.Nodes)
                    {
                        if (tn2.Name == selectedNode.Name)
                            trViewDB.SelectedNode = tn2;
                    }
                }
            }
        }

        /// <summary>
        /// method that fills the tree view with nodes (data from the data table that is connected with the database)
        /// </summary>
        /// <param name="trViewDB"> tree view of the main window </param>
        public static void FillTreeView(TreeView trViewDB)
        {
            trViewDB.Nodes.Clear();
            foreach (DataRow row in dtTableLookUp.Rows)
            {
                TreeNode node = new TreeNode { Text = row["IDDescr"].ToString(), Name = row["ID"].ToString(), Tag = row["ParentID"]};
                if (node.Tag.ToString() != null && node.Tag.ToString() != "")
                {
                    TreeNode[] parent = trViewDB.Nodes.Find(node.Tag.ToString(), true);
                    parent[0].Nodes.Add(node);
                }
                else
                    trViewDB.Nodes.Add(node);
            }
        }

        /// <summary>
        /// method to fill the list view of the main window, where the node ID matches specific items from the data table to add them in the listview
        /// </summary>
        /// <param name="listView"> list view from the main window to fill </param>
        /// <param name="node"> node that is selected </param>
        /// <returns> if the task is finished </returns>
        public static async Task SelectedNodeToFillList(ListView listView, TreeNode node)
        {
            InitRef();         
            listView.Items.Clear();

            foreach (DataRow dr in dtTableIPs.Rows)
            {
                if (node.Name == dr["LookUP"].ToString())
                {
                    if (dr["Phone"] == Convert.DBNull)
                        item = new ListViewItem(dr["Descr"].ToString());
                    else
                        item = new ListViewItem(dr["Descr"].ToString() + " [" + dr["Phone"].ToString() + "]");
                    item.SubItems.Add(dr["IpAddress"].ToString());
                    item.SubItems.Add(dr["Port"].ToString());
                    Int32.TryParse(dr["Port"].ToString(), out int port);
                    if (await Pinger(dr["IpAddress"].ToString(), port))
                        item.SubItems.Add("ON", Color.White, Color.Green, font);
                    else
                        item.SubItems.Add("OFF", Color.Black, Color.Red, font);

                    item.SubItems.Add(dr["ID"].ToString());
                    item.UseItemStyleForSubItems = false;
                    itemList.Add(item);
                }

            }
            foreach (ListViewItem it in itemList)
                listView.Items.Add(it);

            itemList.Clear();
        }

        /// <summary>
        /// method that fills with info from the database the add or edit form 
        /// </summary>
        /// <param name="cmBxLookUP"> combobox of lookup from the form </param>
        /// <param name="txtBxDescr"> text box of description from the form </param>
        /// <param name="txtBxIP"> text box of IP from the form </param>
        /// <param name="txtBxUser"> text box of user from the form </param>
        /// <param name="txtBxPort"> text box of port from the form </param>
        /// <param name="txtBxPass"> text box of pass from the form </param>
        /// <param name="txtBxPhone"> text box of phone from the form </param>
        /// <param name="ID"> the ID of the entry to find the one in the database </param>
        public static void FillAddOrEdit(ComboBox cmBxLookUP, TextBox txtBxDescr, TextBox txtBxIP, TextBox txtBxUser, TextBox txtBxPort, TextBox txtBxPass, TextBox txtBxPhone,String ID)
        {
            InitRef();
            foreach (DataRow dr in dtTableIPs.Rows)
            {
                if (ID.Equals(dr["ID"].ToString()) )
                {
                    FillComboBoxLookUP(cmBxLookUP);
                    int SelectedIndexLookUP = -1;
                    txtBxDescr.Text = dr["Descr"].ToString();
                    txtBxIP.Text = dr["IpAddress"].ToString();
                    txtBxUser.Text = dr["Username"].ToString();
                    txtBxPass.Text = dr["Pass"].ToString();
                    txtBxPort.Text = dr["Port"].ToString();
                    if (dr["Phone"] == Convert.DBNull)
                        txtBxPhone.Text = null;
                    else
                        txtBxPhone.Text = dr["Phone"].ToString();

                    for (int i = 0; (i <= (cmBxLookUP.Items.Count - 1)); i++)
                    {
                        cmBxLookUP.SelectedIndex = i;
                        if (cmBxLookUP.SelectedValue.ToString() == dr["LookUP"].ToString())
                            SelectedIndexLookUP = i;
                    }
                    cmBxLookUP.SelectedIndex = SelectedIndexLookUP;
                }
                
            }

        }

        /// <summary>
        /// method to create a new add or edit form
        /// </summary>
        /// <param name="cmBxLookUP"> combobox of the form </param>
        /// <param name="txtBxUser"> text of username to set the default </param>
        /// <param name="txtBxPort"> text of port to set the default </param>
        /// <param name="txtBxPass"> text of pass to set the default </param>
        /// <param name="node"> node to select the ID of the look up </param>
        public static void NewAddOrEdit(ComboBox cmBxLookUP, TextBox txtBxUser, TextBox txtBxPort, TextBox txtBxPass, String node)
        {
            FillComboBoxLookUP(cmBxLookUP);
            txtBxUser.Text = ReturnRegistry("Def User");
            txtBxPort.Text = ReturnRegistry("Def Port");
            txtBxPass.Text = ReturnRegistry("Def Pass");
            int SelectedIndexLookUP = -1;
            for (int i = 0; (i <= (cmBxLookUP.Items.Count - 1)); i++)
            {
                cmBxLookUP.SelectedIndex = i;
                if (cmBxLookUP.SelectedValue.ToString() == node)
                    SelectedIndexLookUP = i;
            }
            cmBxLookUP.SelectedIndex = SelectedIndexLookUP;
        }

        /// <summary>
        /// method to fill the combobox of lookup in the add or remove form
        /// </summary>
        /// <param name="cmBxLookUP"> combobox from the add or remove form </param>
        public static void FillComboBoxLookUP(ComboBox cmBxLookUP)
        {
            dtTableForCmBxLU = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            cmBxLookUP.DataSource = null;
            cmBxLookUP.DataBindings.Clear();
            adaLookUp.Fill(dtTableForCmBxLU);
            cmBxLookUP.DataSource = dtTableForCmBxLU;
            cmBxLookUP.DisplayMember = "IDDescr";
            cmBxLookUP.ValueMember = "ID";
        }

        /// <summary>
        /// method to fill the datagrid of the lookup form
        /// </summary>
        /// <param name="dtGrdLU"> tree view from the lookup form </param>
        public static void FillDataGridforLookUp(DataGridView dtGrdLU)
        {
            dtTableForLookUp = new DataTable();
            bindingSource = new BindingSource();
            adaLookUp.Fill(dtTableForLookUp);
            dtTableForLookUp.Locale = CultureInfo.InvariantCulture;
            bindingSource.DataSource = dtTableForLookUp;
            dtGrdLU.DataSource = bindingSource;
            dtGrdLU.Columns["IDDescr"].Visible = false;
            dtGrdLU.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        /// <summary>
        /// method to fill the 2 comboboxes in the settings form 
        /// </summary>
        /// <param name="cmbBxBpp"> bitmap combobox </param>
        /// <param name="cmbBxUpdt"> refresh rate combobox </param>
        public static void FillComboBoxesOfSettings(ComboBox cmbBxBpp, ComboBox cmbBxUpdt)
        {
            DataTable dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dt.Clear();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add(new object[] { "1", 1 });
            dt.Rows.Add(new object[] { "2", 2 });
            dt.Rows.Add(new object[] { "4", 4 });
            dt.Rows.Add(new object[] { "8", 8 });
            dt.Rows.Add(new object[] { "16", 16 });
            dt.Rows.Add(new object[] { "24", 24 });
            cmbBxBpp.DataSource = dt;
            cmbBxBpp.DisplayMember = "Text";
            cmbBxBpp.ValueMember = "Value";

            dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dt.Clear();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add(new object[] { "15", 15 });
            dt.Rows.Add(new object[] { "25", 25 });
            dt.Rows.Add(new object[] { "30", 30 });
            dt.Rows.Add(new object[] { "60", 60 });
            dt.Rows.Add(new object[] { "100", 100 });
            cmbBxUpdt.DataSource = dt;
            cmbBxUpdt.DisplayMember = "Text";
            cmbBxUpdt.ValueMember = "Value";
        }


        // ---------------------------- SQL COMMANDS ----------------------------------------------------------

        /// <summary>
        /// method that edits a row that is selected from the user or adds a new data row if there was no ID sent
        /// </summary>
        /// <param name="cmBxLookUP"> combobox of the lookup selection of the user </param>
        /// <param name="txtBxDescr"> text box of the description inputed from the user </param>
        /// <param name="txtBxIP"> text box of the ip inputed from the user </param>
        /// <param name="txtBxUser"> text box of the user inputed from the user </param>
        /// <param name="txtBxPass"> text box of the pass inputed from the user </param>
        /// <param name="txtBxPort"> text box of the port inputed from the user </param>
        /// <param name="txtBxPhone"> text box of the phone inputed from the user </param>
        /// <param name="ID"> the ID of the row that going to get edited </param>
        public static void SaveInfoToDB(ComboBox cmBxLookUP, String txtBxDescr, String txtBxIP, String txtBxUser, String txtBxPass, String txtBxPort, String txtBxPhone, String ID)
        {
            String str = null;
            if (ID == null)
                str = "INSERT INTO IPsInfo ([Descr], [IpAddress], [Username],[Pass], [Port], [Phone], [LookUP]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            else
                str = "UPDATE IPsInfo SET [Descr] = ?, [IpAddress] = ?, [Username] = ?, [Pass] = ?, [Port] = ?, [Phone] = ?, [LookUp] = ? WHERE [ID] = ?";
            comm = new OleDbCommand
            {
                Connection = conn,
                CommandText = str
            };
            
            comm.Parameters.AddWithValue("@Descr",(object)txtBxDescr);
            comm.Parameters.AddWithValue("@IpAddress", (object)txtBxIP);
            comm.Parameters.AddWithValue("@Username", (object)txtBxUser);
            comm.Parameters.AddWithValue("@Pass", (object)txtBxPass);
            comm.Parameters.AddWithValue("@Port", (object)txtBxPort);
            if (txtBxPhone == null || txtBxPhone == "")
                comm.Parameters.AddWithValue("@Phone", Convert.DBNull);
            else
                comm.Parameters.AddWithValue("@Phone", (object)txtBxPhone);
            comm.Parameters.AddWithValue("@LookUP", cmBxLookUP.SelectedValue);
            if(ID != null)
                comm.Parameters.AddWithValue("@ID", (object)ID);

            try
            {
                conn.Open();
                int o = comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem found while trying to insert data " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// searches for the ID of the entry in the database to delete the row
        /// </summary>
        /// <param name="ID"> ID sent </param>
        public static void FindRowToDelete(String ID)
        {
            string str = "DELETE FROM IPsInfo WHERE [ID] = ?";
            comm = new OleDbCommand
            {
                Connection = conn,
                CommandText = str
            };
            comm.Parameters.AddWithValue("@ID", (object)ID);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Problem found while trying to insert data " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// method to update the database from the changes in the dataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void UpdateDatabaseLookUP(DataGridView dtGrdLU)
        {
            try
            {
                dtGrdLU.EndEdit();
                bindingSource.EndEdit();
                DataTable dataSource = (DataTable)bindingSource.DataSource;
                MessageBox.Show(dataSource.GetChanges().Rows.Count.ToString() + " Rows Changed");
                adaLookUp.Update(dataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        // ---------------------------- Registry Methods ------------------------------------------------------

        /// <summary>
        /// method to set the registry with the data the user entered
        /// </summary>
        /// <param name="keyName"> the name of the data </param>
        /// <param name="value"> the data </param>
        public static void SetRegistry(String keyName, String value)
        {
            if (CheckRegistry())
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Radministrator", true);
                key.SetValue(keyName, value);
            }
            else
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey("Radministrator");
                key = key.OpenSubKey("Radministrator", true);
                key.SetValue(keyName, value);
            }
        }

        /// <summary>
        /// Checks if there is any required data missing so the radmin can run normally
        /// </summary>
        /// <returns> true (if everything is found) or false (if there is something missing) </returns>
        public static bool CheckRegistry()
        {
            if(Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey("Radministrator") != null)
            {
                if (Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Exe") != null 
                    && Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Update") != null 
                    && Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Bpp") != null 
                    && Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Def User") != null 
                    && Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Def Pass") != null
                    && Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue("Def Port") != null) 
                    return true;
            }
            return false;
        }

        /// <summary>
        /// return the data of the key name entered
        /// </summary>
        /// <param name="keyName"> the name of the data </param>
        /// <returns></returns>
        public static string ReturnRegistry(String keyName)
        {
            string returnkeyName = null;
            try
            {
                returnkeyName = Registry.LocalMachine.OpenSubKey("Software\\Radministrator", true).GetValue(keyName).ToString();
            }
            catch(Exception)
            {                
            }
            return returnkeyName;            
        }


        // ------------------------------ Miscellaneous -------------------------------------------------------

        /// <summary>
        /// Getting the right x and y of a window to open the child right next to it on the right side
        /// </summary>
        /// <param name="x"> parent's x </param>
        /// <param name="y"> parent's y</param>
        public static void SetWindow(int x, int y)
        {
            xCord = x;
            yCord = y;
        }

        /// <summary>
        /// Browser dialog window for the need of finding the Radming executable
        /// </summary>
        /// <param name="browser"></param>
        /// <returns> returns the file path </returns>
        public static string Browser(OpenFileDialog browser)
        {
            Thread thread = new Thread(() =>
            {
                browser.Filter = "Executable files|*.exe|All Files|*.*";
                browser.FilterIndex = 1;

                DialogResult result = browser.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    try
                    {
                        string text = File.ReadAllText(browser.FileName);
                    }
                    catch (IOException)
                    {
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            thread.Join();

            return browser.FileName;
        }


        /// <summary>
        /// async task in order for the form not to froze and so that a session can get killed either from the time set (timespan) or when someone changes the ips to be pinged(cancellTknSrcFromOtherSelection)
        /// </summary>
        /// <param name="ip"> ip of the item sent </param>
        /// <param name="port"> port of the item </param>
        /// <returns> true (the port opened before the corresponding time) or false (the corresponding time ended or the selection changed so new ips will be tetsed </returns>
        public static async Task<Boolean> Pinger(String ip, int port)
        {
            var timeOut = TimeSpan.FromMilliseconds(60);
            var cancellationCompletionSource = new TaskCompletionSource<bool>();
            try
            {
                using (var cancellTknSrc = new CancellationTokenSource(timeOut))
                {
                    using (var client = new TcpClient())
                    {
                        var task = client.ConnectAsync(ip, port);

                        using (cancellTknSrc.Token.Register(() => cancellationCompletionSource.TrySetResult(true)))
                        {
                            using (cancellTknSrcFromOtherSelection.Token.Register(() => cancellationCompletionSource.TrySetResult(true)))
                            {
                                if ((task != await Task.WhenAny(task, cancellationCompletionSource.Task)))
                                {
                                    throw new OperationCanceledException(cancellTknSrc.Token);
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }


        /// <summary>
        /// procedure that is responsible for the changes in listview and checks if the token can be cancelled and if so it cancels it while also creating a new one
        /// </summary>
        /// <param name="lstVEq"> list to fill from the main window </param>
        /// <param name="trViewDB"> treeview from the main window to get the selected node </param>
        public static async void CheckIfAnotherSelectionIsRunning(ListView lstVEq,TreeView trViewDB)
        {
            try
            {
                if (cancellTknSrcFromOtherSelection.Token.CanBeCanceled)
                    cancellTknSrcFromOtherSelection.Cancel();
            }
            catch (NullReferenceException) { }
            catch (OperationCanceledException) { }
            catch (ObjectDisposedException) { }
            catch (Exception) { }
            finally
            {
                try
                {
                    cancellTknSrcFromOtherSelection = new CancellationTokenSource();
                    await SelectedNodeToFillList(lstVEq, trViewDB.SelectedNode);
                }
                catch (Exception) { }
            }
        }


        /// <summary>
        /// function that returns true if the users entries are found in the database and so would be duplicate or returns false if there is no duplication of data going to occur
        /// </summary>
        /// <param name="txtBxIP"> text box with the IP that the user has inputted </param>
        /// <param name="txtBxPort"> text box with the Port that the user has inputted </param>
        /// <param name="ID"> the ID of the entry that is getting edited (only used if an entry is getting edited else it is null) </param>
        /// <returns> true of false </returns>
        public static Boolean CheckForEntry(String txtBxIP,String txtBxPort ,String ID)
        {
            Boolean boolean = false;
            int i = 0;
            DataRow IDsRow = RowRetrieverThroughID(ID);
            while (boolean == false && i < dtTableIPs.Rows.Count)
            {
                DataRow dr = dtTableIPs.Rows[i];
                String dataSetIP = dr["IpAddress"].ToString();
                String dataSetPort = dr["Port"].ToString();
                if (IDsRow == null)
                {
                    if (txtBxIP == dataSetIP && txtBxPort == dataSetPort)
                        boolean = true;
                    else
                        boolean = false;
                }
                else
                {
                    if ((IDsRow["IpAddress"].ToString() == txtBxIP && IDsRow["Port"].ToString() != txtBxPort) && (txtBxIP == dataSetIP && txtBxPort == dataSetPort))
                        boolean = true;
                    else if ((IDsRow["Port"].ToString() != txtBxPort) && (IDsRow["IpAddress"].ToString() != txtBxIP) && (txtBxIP == dataSetIP) && (txtBxPort == dataSetPort))
                        boolean = true;
                    else if ((IDsRow["IpAddress"].ToString() != txtBxIP) && (txtBxIP == dataSetIP) && (txtBxPort == dataSetPort))
                        boolean = true;
                    else
                        boolean = false;
                }
                i++;
            }
            return boolean;
        }

        /// <summary>
        /// method that searches the database data to find the ID of the selected item
        /// </summary>
        /// <param name="ID"> ID of the item </param>
        /// <returns> the row of the matched item </returns>
        public static DataRow RowRetrieverThroughID(String ID)
        {
            InitRef();
            Boolean found = false;
            int i = 0;
            DataRow dr = null,drFound = null;            
            while (found == false && i < dtTableIPs.Rows.Count)
            {
                dr = dtTableIPs.Rows[i];
                if (ID == dr["ID"].ToString())
                {
                    found = true;
                    drFound = dr;                    
                }                    
                i++;
            }                       
            return drFound;
        }

        /// <summary>
        /// method that calls the radmin so that the program can connect to the selected item
        /// </summary>
        /// <param name="type"> type of the connection : 1 (view connection) , 2 (file transfer connection), 3 (telnet connection),
        /// 4 (telnet shutdown connection), 5 (through connection that calls the radmin to do the creation of the through there </param>
        /// <param name="program"> the path of the executable radmin </param>
        /// <param name="dr"> the data row that has the info of the connection </param>
        public static void Connect(int type, string program,DataRow dr)
        {
            /*
            * /through:<address>:<port> 
            * /connect:212.44.120.10:4899 /telnet 
            * /connect:212.44.120.10:4899 /file 
            * /updates:30 /16bpp
            */            
            string ip = dr["IpAddress"].ToString(), port = dr["Port"].ToString(), user = dr["Username"].ToString(), pass = dr["Pass"].ToString();

            string selTypeWithIp = null;
            switch (type)
            {
                case 1:
                    selTypeWithIp = "/connect:" + ip + ":" + port + " /" + ReturnRegistry("Bpp") + "bpp /updates:" + ReturnRegistry("Update");
                    break;
                case 2:
                    selTypeWithIp = "/connect:" + ip + ":" + port + " /file";
                    break;
                case 3:
                    selTypeWithIp = "/connect:" + ip + ":" + port + " /telnet";
                    break;
                case 4:
                    selTypeWithIp = "/connect:" + ip + ":" + port + " /telnet";
                    break;
                case 5:     
                    selTypeWithIp = "/connect:" + ip + ":" + port + " /through:" + throughIP + ":" + throughPort;
                    break;
            }
            ProcessStartInfo start = new ProcessStartInfo(program, selTypeWithIp);
            Process viewer = new Process
            {
                StartInfo = start
            };
            try
            {
                Task task = new Task(delegate
                {
                    viewer.Start();
                    if (type == 4)
                    {
                        FocusProcess("Radmin Security: " + ip, user, pass);
                        FocusTelnet(ip + " - Telnet");
                    }
                    else
                    {
                        FocusProcess("Radmin Security: " + ip, user, pass);
                        FocusRadminWindowToBringItForeground(ip + " - Full Control");
                    }                        
                });
                task.Start();
            }
            catch(Exception)
            {
            }
        }
    }

    //------------------------------ Sorting ---------------------------------------------------------------

    /// <summary>
    /// class to enable sorting of the columns in the listview of the main menu
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private static int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private static System.Windows.Forms.SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private static CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = System.Windows.Forms.SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == System.Windows.Forms.SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public System.Windows.Forms.SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
