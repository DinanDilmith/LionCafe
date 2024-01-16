using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void gunaPictureBoxBack4_Click(object sender, EventArgs e)      //go back
        {
            menuform mf1 = new menuform();
            mf1.Show();
            this.Hide();
        }

        private void gunaPictureBoxExit_Click(object sender, EventArgs e)       //exit
        {
            this.Close();
        }

        private void gunaPictureBoxPayBill_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{16}$");        //declaring that credit card number must have 16 digits
            Regex r1 = new Regex(@"^[0-9]{2}$");       //declaring that month must be less than or equal 12
            Regex r2 = new Regex(@"^[0-9]{4}$");        //declaring that expire year must have 4 digits
            Regex r3 = new Regex(@"^[0-9]{3}$");        //declaring that cvn must have 3 digits


            try    //exception handling
            {
                if (gunaComboBoxPaymntType.Text == "")     //validating payment type
                {
                    MessageBox.Show("Enter Your Payment Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (!r.IsMatch(textBoxCardNmbr.Text))    //validating credit card number
                {
                    MessageBox.Show("Enter Valid Credit Card Number With 16 digits !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if ((!r1.IsMatch(textBoxExpMnth.Text)) || (Convert.ToInt32(textBoxExpMnth.Text) > 12))   //validating expire month
                {
                    MessageBox.Show("Enter Valid Expire Month !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if ((!r2.IsMatch(textBoxExpYr.Text)) || (Convert.ToInt32(textBoxExpYr.Text) < 2023))     //validating expire year
                {
                    MessageBox.Show("Enter Valid Expire Year !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (!r3.IsMatch(textBoxCVN.Text))     //validating cvn
                {
                    MessageBox.Show("Enter Valid CVN !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("Payment Successful !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    menuform mf1 = new menuform();     //going back to menu form
                    mf1.Show();
                    this.Hide();
                }
            }

            catch (Exception )  //exception handling
            {
                MessageBox.Show("Something Went Wrong !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
