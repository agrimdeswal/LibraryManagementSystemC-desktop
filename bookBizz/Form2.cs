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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bookBizz
{
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void ClearAll()
        {
            textBoxName.Clear();
            textBoxStreet.Clear();
            textBoxCity.Clear();
            maskedTextBoxPhone.Clear();
            textBoxPostalCode.Clear();
            textBoxFax.Clear();
            textBoxName.Focus();
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<Client> listC = ClientDA.ListClient();

            Client a = new Client();
            if (Validator.IsValidName(textBoxName))
            {
                a.Name = textBoxName.Text;
                a.Street = textBoxStreet.Text;
                a.City = textBoxCity.Text;
                a.Postal = textBoxPostalCode.Text;
                a.Phone = (maskedTextBoxPhone.Text);
                a.Fax = textBoxFax.Text;
                ClientDA.Save(a);

                ClearAll();
            }
            
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewClients.Items.Clear();
            ClientDA.ListClient(listViewClients);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Client cust = ClientDA.Search(textBoxInput.Text);

            if (cust != null)
            {
                
                textBoxName.Text = cust.Name;
                textBoxStreet.Text = cust.Street;
                textBoxCity.Text = cust.City;
                textBoxPostalCode.Text = cust.Postal;
                maskedTextBoxPhone.Text=cust.Phone;
                textBoxFax.Text = cust.Fax;

            }
            else
            {

                MessageBox.Show("Not found!");
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
    }
}
