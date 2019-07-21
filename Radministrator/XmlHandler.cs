using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Radministrator
{
    class XmlHandler
    {
        public static void Writer()
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
                if (r.NodeType == XmlNodeType.Text )
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
        }
        
    }
}
