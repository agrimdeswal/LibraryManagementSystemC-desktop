using bookBizz.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookBizz.DLL
{
    internal class ClientDA
    {
        private static string filePath = Application.StartupPath + @"\Client.dat";

        private static string fileTemp = Application.StartupPath + @"Temp3.dat";

        public static void Save(Client c)

        {

            StreamWriter sWrite = new StreamWriter(filePath, true);
            sWrite.WriteLine(c.Name + "," + c.Street + "," + c.City + "," + c.Postal + "," + c.Phone + "," + c.Fax);
            sWrite.Close();

            MessageBox.Show("Client Data has been saved!");

        }

        public static void ListClient(ListView listClient)
        {

            StreamReader streamReader = new StreamReader(filePath);
            listClient.Items.Clear();

            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                
                listClient.Items.Add(item);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }




        public static List<Client> ListClient()
        {

            List<Client> listC = new List<Client>();

            StreamReader streamReader = new StreamReader(filePath);

            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                Client c = new Client();
                c.Name = fields[0] ;
                c.Street = fields[1];
                c.City = fields[2];
                c.Postal = fields[3];
                c.Phone = (fields[4]);
                c.Fax = fields[5];
                listC.Add(c);
                line = streamReader.ReadLine();

            }
            streamReader.Close();
            return listC;


        }

        public static Client Search(string Name)
        {
            Client c = new Client();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (Name == (fields[0]))
                {
                    c.Name = fields[0];
                    c.Street = fields[1];
                    c.City = fields[2];
                    c.Postal = fields[3];
                    c.Phone = (fields[4]);
                    c.Fax = fields[5];
                    sReader.Close();
                    return c;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
    }
}
