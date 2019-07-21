using System;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Windows.Input;
using System.Reflection;
using System.Security.Policy;
using Microsoft.Win32;
using System.Security.Permissions;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text.RegularExpressions;

namespace Radministrator
{
    class Tester
    {

        [STAThread]

        [DllImport("user32.dll")] static extern int GetClassName();

        [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr WindowHandle);

        [DllImport("user32.dll")] static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern Int32 SendMessage(IntPtr hwnd, int msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll")] static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);

        [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern string SendMessage(IntPtr hWnd, int msg, string wParam, IntPtr lParam);







        //------------------------------------ _HOW TO GET ALL THE CHILDREN HANDLES OUT OF ANY APPLICATION _----------------------------------- 

        /*private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        static public List<IntPtr> GetAllChildHandles(IntPtr mainHandle)
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(mainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }*/

        /*static private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }*/


        //------------------------------------ some methods  ----------------------------------------------------

        /*static public void FocusNote()
        {

            IntPtr hWnd = IntPtr.Zero;

            do
            {
                hWnd = FindWindow(null, "Χωρίς τίτλο - Σημειωματάριο");
            }
            while ((hWnd == IntPtr.Zero));


            IntPtr text = FindWindowEx(hWnd, IntPtr.Zero, "edit", null);

            SendMessage(text, DefineConstants.WM_SETTEXT, IntPtr.Zero, new StringBuilder("strin"));


        }*/

        /*static public void Pinger(String ip , int port)
        {
            Stopwatch timer = new Stopwatch();
            TcpClient telnet = new TcpClient();
            Boolean done = false;
            try
            {
                timer.Start();
                while ( (timer.Elapsed.TotalSeconds < 1) && (done == false) )
                {
                    telnet.SendTimeout = 1;
                    telnet.Connect(ip, port);
                    if (telnet.Connected)
                    {
                        done = true;
                        Console.WriteLine("DONE");
                    }
                    if (timer.ElapsedMilliseconds.Equals(400))
                    {
                        telnet.Close();
                    }
                }                
                telnet.Close();
                timer.Stop();                
            }
            catch
            {
            }



        }*/

        /*static public void gg(IAsyncResult result)
        {

            Console.WriteLine("DONE");

        }*/

        /*static public void TestPinger()
        {

            Stopwatch timer = new Stopwatch();
            TcpClient telnet = new TcpClient();
            telnet.SendTimeout = 1000;

            try
            {


                telnet.BeginConnect("149.202.15.10", 3032, new AsyncCallback(gg), telnet);

                // telnet.Connect("149.202.15.10", 3032);
                if (telnet.Connected)
                    Console.WriteLine("DONE");
                else
                    Console.WriteLine("NO");

            }
            catch
            {
            }

        }*/

        /*static public async Task SelectedNode(TreeView trView, String nodeName, Boolean ping)
        {



            string a = trViewDB.SelectedNode.Name;
            SqlDataAdapter shopsEquipment = null,shops = null;
            if (Program.CheckRegistry())
            txtPath.Text = Program.ReturnRegistry();
            shops = Program.GetInfo("Select CODEID, Name from[Bazaar].[dbo].[BazaarStoreInfo] where IpPool is not null");
                shopsEquipment = Program.GetInfo("Select * from [tmpBazaar].[dbo].[BazaarStoreInfoDT]");
            DataTable dt = new DataTable();
            DataTable de = new DataTable();
            DataSet ds = new DataSet();
            shops.Fill(ds, "Bazaar");
            shopsEquipment.Fill(de); ds.Relations.Add("connection", ds.Tables["Bazaar"].Columns["CodeID"], ds.Tables["Equip"].Columns["ID"]);
            foreach (DataRow rt in ds.Tables["Bazaar"].Rows)
            {
                foreach (DataRow rtChild in rt.GetChildRows("connection"))
                {
                    Console.WriteLine(rtChild[1].ToString());
                    if (a.Equals(rtChild[1].ToString()))
                    {
                        lstBox.Items.Add(rtChild[1].ToString() + ". " + rtChild[2].ToString());                    
                    }

                }

            }

        }*/

        /*static public async Task SelectedNode(TreeView trView, String nodeName, Boolean ping)
        {
            trView.Nodes.Clear();
            DataTable dt = new DataTable();
            shopsEquipment.Fill(dt);
            foreach (DataRow rt in dt.Rows)
            {
                if (nodeName.Equals(rt[1].ToString()))
                {
                    trView.Nodes.Add(rt[2].ToString(), rt[1].ToString() + ". " + rt[2].ToString());
                    if (ping)
                    {
                        int port;
                        Int32.TryParse(rt[6].ToString().Trim(), out port);
                        await TestPinger(rt[3].ToString().Trim(), port);
                    }


                }
            }
        }*/

        /*static public void GetInfo()
        {
           SqlConnection conn = new SqlConnection("Data Source=149.202.158.99;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=baz123");
           conn.Open();
           SqlCommand command = new SqlCommand("Select codeid from [Bazaar].[dbo].[BazaarStoreInfo]", conn);
           // int result = command.ExecuteNonQuery();
           SqlDataAdapter tmp = new SqlDataAdapter("Select codeid from [Bazaar].[dbo].[BazaarStoreInfo]", conn);
           DataTable ds = new DataTable();
           tmp.Fill(ds);
           using (SqlDataReader reader = command.ExecuteReader())
           {
               while (reader.Read())
               {
                   //Console.WriteLine(String.Format("{0}", reader["*"]));
                   Console.WriteLine(String.Format("{0}", reader[0]));
               }
           }

           foreach (DataRow row in ds.Rows)
           Console.WriteLine("{0}",row[0]);
           conn.Close();
        }*/

        /*public static async Task SelectedNodeToListOLD(ListView listView, String nodeName, Boolean ping)
        {

            listView.Items.Clear();
            DataTable dt = new DataTable();
            shopsEquipment.Fill(dt);

            foreach (DataRow rt in dt.Rows)
            {
                if (nodeName.Equals(rt[1].ToString()))
                {
                    string[] row = { rt[3].ToString().Trim(), rt[6].ToString().Trim(), "Unknown" };
                    if (ping)
                    {
                        int port;
                        Int32.TryParse(rt[6].ToString().Trim(), out port);
                        if (await Pinger(rt[3].ToString().Trim(), port))
                        {
                            row[2] = "Online";
                        }
                        else
                        {
                            row[2] = "Offline";
                        }
                        listView.Items.Add(rt[1].ToString().Trim() + ". " + rt[2].ToString().Trim()).SubItems.AddRange(row);
                    }
                    else
                        listView.Items.Add(rt[1].ToString().Trim() + ". " + rt[2].ToString().Trim()).SubItems.AddRange(row);

                }
            }

        }*/

        /*static public async Task<Boolean> PingerLastVersion(String ip, int port)
        {
            var timeOut = TimeSpan.FromMilliseconds(90);
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
                            if (task != await Task.WhenAny(task, cancellationCompletionSource.Task))
                            {
                                throw new OperationCanceledException(cancellTknSrc.Token);
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
        }*/

        /*private String readinnerxml(XmlTextReader reader)
        {
            reader.ReadOuterXml();
            return reader.Name;
        }*/

        /*private void LookUpTable_Load(object sender, EventArgs e)
        {



            try
            {
                FileStream fs = new FileStream("LookUpTable.xml", FileMode.Open);
                XmlTextReader r = new XmlTextReader(fs);

                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Text)
                        dtGrdLUTbl.Rows.Add(r.Value, readinnerxml(r));
                }

                r.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }*/

        /*public static void Writer()
        {
            FileStream fs;
            if (!File.Exists("LookUpTable.xml"))
            {
                fs = new FileStream("LookUpTable.xml", FileMode.OpenOrCreate);
                XmlTextWriter w = new XmlTextWriter(fs, Encoding.UTF8);
                w.WriteStartDocument();

                w.WriteStartElement("Table");

                w.WriteStartElement("Groups");
                w.WriteElementString("Μηχανογραφηση", "0");
                w.WriteElementString("ServerRoom", "1");
                w.WriteElementString("HR", "2");
                w.WriteElementString("Λογιστηριο", "3");
                w.WriteElementString("Reception", "4");
                w.WriteElementString("Διακινηση", "5");
                w.WriteElementString("Δημιουργικο", "6");
                w.WriteElementString("Πωλητες", "7");
                w.WriteElementString("Αιθουσα", "8");
                w.WriteElementString("Αποθηκη", "9");
                w.WriteElementString("Καταστηματα", "10");
                w.WriteElementString("Everest", "11");
                w.WriteElementString("Σαλονικα", "12");
                w.WriteElementString("Κρητη", "13");
                w.WriteElementString("Μυκονος", "14");
                w.WriteElementString("Ροδος", "15");
                w.WriteElementString("Τριπολη", "16");
                w.WriteElementString("Χανια", "17");

                w.WriteEndElement();

                w.WriteEndDocument();

                w.Flush();
                fs.Close();
                w.Close();
            }


            fs = new FileStream("LookUpTable.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);

            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Text)
                {
                    if (r.Value == "11")
                    {
                        r.ReadOuterXml();
                        Console.WriteLine("<" + r.Name + ">");
                    }
                }
            }
            r.Close();
            fs.Close();
        }*/

        /*public static Boolean CheckForEntry(String txtBxIP, String txtBxPort, String ID)
        {
            Boolean boolean = false;
            int i = 0;
            DataRow IDsRow = RowRetrieverThroughID(ID);
            String IDsIP = IDsRow[1].ToString(), IDsPort = IDsRow[6].ToString();
            if (ID == null)
            {
                while (boolean == false && i<dtTableShopsEquipment.Rows.Count)
                {
                    DataRow dr = dtTableShopsEquipment.Rows[i];
                    String dataSetIP = dr[1].ToString();
                    String dataSetPort = dr[6].ToString();
                    if (txtBxIP == dataSetIP && txtBxPort == dataSetPort)
                        boolean = true;
                    else
                        boolean = false;
                    i++;
                }
            }
            else
            {
                DataRow IDsRow = RowRetrieverThroughID(ID);
                String IDsIP = IDsRow[1].ToString(), IDsPort = IDsRow[6].ToString();

                while (boolean == false && i<dtTableShopsEquipment.Rows.Count)
                {
                    DataRow dr = dtTableShopsEquipment.Rows[i];
                    String dataSetIP = dr[1].ToString();
                    String dataSetPort = dr[6].ToString();

                    if ((IDsIP == txtBxIP && IDsPort != txtBxPort) && (txtBxIP == dataSetIP && txtBxPort == dataSetPort))
                        boolean = true;
                    else if ((IDsPort != txtBxPort) && (IDsIP != txtBxIP) && (txtBxIP == dataSetIP) && (txtBxPort == dataSetPort))
                        boolean = true;
                    else if ((IDsIP != txtBxIP) && (txtBxIP == dataSetIP) && (txtBxPort == dataSetPort))
                        boolean = true;
                    else
                        boolean = false;
                    i++;
                }
            }
            return boolean;
        }*/

        /*static public void Notepad()
       {
           ProcessStartInfo start = new ProcessStartInfo("notepad.exe");
           Process note = new Process
           {
               StartInfo = start
           };
           try
           {
               Task task = new Task(delegate
               {
                   note.Start();
                   FocusNote();
               });
               task.Start();
           }
           catch
           {

           }
       }*/

        /*internal static class DefineConstants
        {
            public const int WM_COMMAND = 0x0111;
            public const int BN_CLICKED = 16;
            public const int ButtonOkId = 0x78;
            public const int WM_SETTEXT = 0x000C;
        }*/
    }

}
