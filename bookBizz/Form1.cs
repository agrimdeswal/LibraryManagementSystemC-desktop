using bookBizz.BLL;
using bookBizz.DLL;
using bookBizz.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookBizz
{
    public partial class Form1 : Form
    {
        List <MISmanager> listC=new List<MISmanager> ();

        public void ClearAll()
        {
            textBoxAuthorID.Clear();
            textBoxFname.Clear();
            textBoxLname.Clear();
            textBoxEmail.Clear();
            
            textBoxISBN.Clear();
            textBoxPrice.Clear();
            textBoxTitle.Clear();
            textBoxYear.Clear();
            textBoxQOH.Clear();

            textBoxAuthorID.Focus();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<MISmanager> listC = MISmanagerDA.ListMISmanager();

            MISmanager a = new MISmanager();
            if((Validator.IsValidID(textBoxAuthorID)) && Validator.IsValidName(textBoxFname) && Validator.IsValidName(textBoxLname))
            {
                a.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                a.FirstName = textBoxFname.Text;
                a.LastName = textBoxLname.Text;
                a.Email = textBoxEmail.Text;

                MISmanagerDA.Save(a);

                ClearAll();
            }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            MISmanagerDA.ListMISmanager(listView1);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MISmanager cust = MISmanagerDA.Search(Convert.ToInt32(textBoxInput.Text));

            if (cust != null)
            {
                textBoxAuthorID.Text = (cust.AuthorID).ToString();
                textBoxFname.Text = cust.FirstName;
                textBoxLname.Text = cust.LastName;
                textBoxEmail.Text = cust.Email;
            }
            else
            {

                MessageBox.Show("Not found!");
            }
            
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {

            List<Book> listC = BookDA.ListBook();

            Book a = new Book();
            if (Validator.IsValidName(textBoxTitle))
            {
                a.ISBN = Convert.ToInt32(textBoxISBN.Text);
                a.Price = Convert.ToInt32(textBoxPrice.Text);
                a.Title = textBoxTitle.Text;
                a.YearPublished = textBoxYear.Text;
                a.QOH = Convert.ToInt32(textBoxQOH.Text);
                BookDA.Save(a);

                ClearAll();
            }
           
        }

        private void buttonList2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            BookDA.ListBook(listView2);
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            Book cust = BookDA.Search(Convert.ToInt32(textBoxInput2.Text));

            if (cust != null)
            {
                textBoxISBN.Text = (cust.ISBN).ToString();
                textBoxPrice.Text=cust.Price.ToString();
                textBoxTitle.Text = cust.Title;
                textBoxYear.Text = cust.YearPublished;
                textBoxQOH.Text=cust.QOH.ToString();
                
            }
            else
            {

                MessageBox.Show("Not found!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(); // Instantiate a Form3 object.
            f2.ShowDialog(); // Show Form3 and
            
        }
    }
}
