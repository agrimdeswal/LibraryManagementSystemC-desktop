using bookBizz.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookBizz.Validation
{
    internal class Validator
    {
        public static bool IsValidID(string input)
        {

            int tempID;
            if ((input.Length != 3) || (Int32.TryParse(input, out tempID)))
            {
                MessageBox.Show("Invalid ID, it must be a 3 digit number");
                return false;
            }
            return true;

        }
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 3) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid ID, it must be a 3 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }
        public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid Name,Please enter another name.", "INVALID NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;

        }
        public static bool IsUniqueID(List<MISmanager> listC, int id)
        {
            foreach (MISmanager c in listC)
            {
                if (c.AuthorID == id)
                {
                    MessageBox.Show("Duplicate ID, please enter a unique one.");
                    return false;
                }
            }
            return true;
        }
    }
}
