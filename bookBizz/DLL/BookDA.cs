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
    internal class BookDA
    {
        private static string filePath = Application.StartupPath + @"\Book.dat";

        private static string fileTemp = Application.StartupPath + @"Temp2.dat";

        public static void Save(Book book)

        {

            StreamWriter sWrite = new StreamWriter(filePath, true);
            sWrite.WriteLine(book.ISBN + "," + book.Price + "," + book.Title + "," +book.YearPublished+ "," + book.QOH);
            sWrite.Close();

            MessageBox.Show("Book Data has been saved!");

        }

        public static void ListBook(ListView listBook)
        {

            StreamReader streamReader = new StreamReader(filePath);
            listBook.Items.Clear();

            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                listBook.Items.Add(item);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }




        public static List<Book> ListBook()
        {

            List<Book> listC = new List<Book>();

            StreamReader streamReader = new StreamReader(filePath);

            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
               Book book = new Book();
                book.ISBN = Convert.ToInt32(fields[0]); ;
                book.Price = Convert.ToInt32(fields[1]); 
                book.Title = fields[2];
                book.YearPublished = fields[3];
                book.QOH = Convert.ToInt32(fields[4]);
                listC.Add(book);
                line = streamReader.ReadLine();

            }
            streamReader.Close();
            return listC;


        }

        public static Book Search(int ISBN)
        {
            Book b = new Book();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ISBN == Convert.ToInt32(fields[0]))
                {
                    b.ISBN = Convert.ToInt32(fields[0]);
                    b.Price = Convert.ToInt32( fields[1]);
                    b.Title = fields[2];
                    b.YearPublished = fields[3];
                    b.QOH = Convert.ToInt32(fields[4]);
                    sReader.Close();
                    return b;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
    }
}

