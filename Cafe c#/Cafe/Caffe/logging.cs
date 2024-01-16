using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Caffe
{
    public partial class logging : Form
    {
        public logging()
        {
            InitializeComponent();
        }

        private void gunaPictureBoxLoginAsAdmn_Click(object sender, EventArgs e)         //login as admin
        {
            adminLogging ad1 = new adminLogging();
            ad1.Show();
            this.Hide();
        }

        private void gunaPictureBoxCrtAccnt_Click(object sender, EventArgs e)       //create new customer account
        {
            CreateAccountCustomer CrtAcc1= new CreateAccountCustomer();
            CrtAcc1.Show();
            this.Hide();
        }

        private void gunaPictureBoxCstmrLogin_Click(object sender, EventArgs e)       //login as customer
        {
            if(textBoxCstmrLoginID.Text=="")          //validating customer id and password
            {
                MessageBox.Show("Enter Customer ID !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxCstmrLoginPW.Text=="")
            {
                MessageBox.Show("Enter Your Password !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try      //exception handling
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True");   //database connection
                    SqlCommand cmd = new SqlCommand("select * from CUSTOMER where CUSTOMER_ID = @CUSTOMER_ID and CU_PASSWORD = @CU_PASSWORD", conn);     //picking data from customer table

                    cmd.Parameters.AddWithValue("@CUSTOMER_ID", textBoxCstmrLoginID.Text);   //checking data accuracy
                    cmd.Parameters.AddWithValue("@CU_PASSWORD", textBoxCstmrLoginPW.Text);   //checking data accuracy

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)  //checking data accuracy
                    {
                        MessageBox.Show("Login Successful !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        menuform m = new menuform();
                        m.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Customer ID or Password is Invalid !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                catch (Exception)     //exception handling
                {
                    MessageBox.Show("Something Went Wrong !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void gunaPictureBoxExitLogin_Click(object sender, EventArgs e)   //exit 
        {
            this.Close();
        }
    }
}
