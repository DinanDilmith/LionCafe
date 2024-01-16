using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe
{
    public partial class CreateAccountCustomer : Form
    {
        public CreateAccountCustomer()
        {
            InitializeComponent();
        }
        private void gunaPictureBoxCrtNewCstmr_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{10}$");   //declaring that mobile number can have only 10 digits

            if (textBoxCstmrID.Text == "")   //customer id validation
            {
                MessageBox.Show("Please Enter Your Customer ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBoxNewCstmrName.Text == "")  //customer name validation
            {
                MessageBox.Show("Please Enter Your Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxNewCstmrMobNo.Text == "")   //customer mobile number validation
            {
                MessageBox.Show("Please Enter Your Mobile Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(!r.IsMatch (textBoxNewCstmrMobNo.Text)) //validating mobile number (new technology)
            {
                MessageBox.Show("Please Enter a Valid Mobile Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxNewCstmrPW.Text == "")   //validating customer password
            {
                MessageBox.Show("Please Enter a Password of Your Choice !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxNewCstmrRePW.Text == "")  //validating confirmed password
            {
                MessageBox.Show("Please Confirm Your Password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBoxNewCstmrPW.Text != textBoxNewCstmrRePW.Text)   //validating if password and confirmed password is equal
            {
                MessageBox.Show("Your Password and Confirmed Password Doesn't Match !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxNewCstmrAddrs.Text == "")  //validating customer address
            {
                MessageBox.Show("Please Enter Your Address !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else 
            {
                try   //exception handling
                {

                    String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";  //database connection
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "insert into CUSTOMER values ('" + textBoxCstmrID.Text + "','" + textBoxNewCstmrName.Text + "','" + textBoxNewCstmrAddrs.Text + "','" + textBoxNewCstmrMobNo.Text + "','" + textBoxNewCstmrRePW.Text + "')";     //inserting data into customer table
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You are Registered Successfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    logging l1 = new logging();   //directed back to login page after registering successfully,customer have to login with newly created account
                    l1.Show();
                    this.Hide();
                }

                catch (Exception)  //exception handling
                {
                    MessageBox.Show("The ID you Entered is Already Taken !!! Try a Different One !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
               
        }

        private void gunaPictureBoxBack2_Click(object sender, EventArgs e)   //go back
        {
            logging l1 = new logging();
            l1.Show();
            this.Hide();
        }
    }
}
