using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe
{
    public partial class adminLogging : Form
    {
        public adminLogging()
        {
            InitializeComponent();
        }

        private void gunaPictureBoxLoginAsCstmr_Click(object sender, EventArgs e)    //login as a customer
        {
            logging l1 = new logging();
            l1.Show();
            this.Hide();
        }

        private void gunaPictureBoxAdmnLogin_Click(object sender, EventArgs e)     //login as admin
        {
            if(textBoxAdmnLoginID.Text=="")        //validating admin id and password
            {
                MessageBox.Show("Enter Admin ID !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(textBoxAdmnLoginPW.Text=="")
            {
                MessageBox.Show("Enter Your Password !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try   //exception handling
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True");   //database connection
                    SqlCommand cmd = new SqlCommand("select * from ADMIN where ADMIN_ID = @ADMIN_ID and AD_PASSWORD = @AD_PASSWORD", conn);      //picking data from customer table

                    cmd.Parameters.AddWithValue("@ADMIN_ID", textBoxAdmnLoginID.Text);     //checking data accuracy
                    cmd.Parameters.AddWithValue("@AD_PASSWORD", textBoxAdmnLoginPW.Text);     //checking data accuracy

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)       //checking data accuracy
                    {
                        MessageBox.Show("Login Successful !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adminMenu aM = new adminMenu();
                        aM.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Admin ID or Password is Invalid !!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            catch (Exception)     //exception handling
                {
                    MessageBox.Show("Something Went Wrong !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
          
        }

        private void gunaPictureBoxExitAdminLogin_Click(object sender, EventArgs e)     //exit
        {
            this.Close();
        }
    }
}
