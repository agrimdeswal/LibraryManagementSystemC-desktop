using bookBizz.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace bookBizz.DLL
{
    internal class MISmanagerDA
    {
        private static string filePath = Application.StartupPath + @"\Authors.dat";

        private static string fileTemp = Application.StartupPath + @"Temp.dat";

        public static void Save(MISmanager man)

        {

            StreamWriter sWrite = new StreamWriter(filePath, true);
            sWrite.WriteLine(man.AuthorID + "," + man.FirstName + "," + man.LastName + "," + man.Email);
            sWrite.Close();

            MessageBox.Show("Author Data has been saved!");

        }

        public static void ListMISmanager(ListView listViewMISmanager)
        {

            StreamReader streamReader = new StreamReader(filePath);
            listViewMISmanager.Items.Clear();

            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                listViewMISmanager.Items.Add(item);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }
       

        

        public static List<MISmanager> ListMISmanager()
        {
            
                List<MISmanager> listC = new List<MISmanager>();

                StreamReader streamReader = new StreamReader(filePath);

                string line = streamReader.ReadLine();

                while (line != null)
                {
                    string[] fields = line.Split(',');
                    MISmanager man = new MISmanager();
                    man.AuthorID = Convert.ToInt32(fields[0]); ;
                    man.FirstName = fields[1];
                    man.LastName = fields[2];
                    man.Email = fields[3];
                    listC.Add(man);
                    line = streamReader.ReadLine();

                }
                streamReader.Close();
                return listC;
            
           
        }

        public static MISmanager Search(int AuthorId)
        {
            MISmanager cust = new MISmanager();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (AuthorId == Convert.ToInt32(fields[0]))
                {
                    cust.AuthorID = Convert.ToInt32(fields[0]);
                    cust.FirstName = fields[1];
                    cust.LastName = fields[2];
                    cust.Email = fields[3];
                    sReader.Close();
                    return cust;
                }
                line = sReader.ReadLine(); 
            }
            sReader.Close();
            return null;
        }
    }
}
