using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe
{
    public partial class adminMenu2 : Form
    {
        public adminMenu2()
        {
            InitializeComponent();
        }

        private void gunaPictureBoxBack6_Click(object sender, EventArgs e)     //go back
        {
            adminMenu ad = new adminMenu();
            ad.Show();
            this.Hide();
        }

        private void gunaPictureBoxAddCus_Click(object sender, EventArgs e)     // to Add new customers
        {
            Regex r = new Regex(@"^[0-9]{10}$");    //Validating customer mobile number

            if(guna2TextBoxCusID.Text == "")
            {
                MessageBox.Show("Please Enter Customer ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(guna2TextBoxCusName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(!r.IsMatch(guna2TextBoxCusTele.Text))
            {
                MessageBox.Show("Please Enter the Correct Mobile Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(guna2TextBoxCusPW.Text == "")
            {
                MessageBox.Show("Please Enter Customer Password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(guna2TextBoxCusAdd.Text == "")
            {
                MessageBox.Show("Please Enter Customer Address !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    string constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";    //database connection
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "insert into CUSTOMER values ('" + guna2TextBoxCusID.Text + "','" + guna2TextBoxCusName.Text + "','" + guna2TextBoxCusAdd.Text + "','" + guna2TextBoxCusTele.Text + "','" + guna2TextBoxCusPW.Text + "') ";   //addind customer details
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Succesfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Error Adding Customer !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gunaPictureBox2UpdateCus_Click(object sender, EventArgs e)    //to update customers
        {

            Regex r = new Regex(@"^[0-9]{10}$");

            if (guna2TextBoxCusID.Text == "")
            {
                MessageBox.Show("Please Enter Customer ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxCusName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!r.IsMatch(guna2TextBoxCusTele.Text))
            {
                MessageBox.Show("Please Enter the Correct Mobile Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxCusPW.Text == "")
            {
                MessageBox.Show("Please Enter Customer Password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxCusAdd.Text == "")
            {
                MessageBox.Show("Please Enter Customer Address !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    string constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "update CUSTOMER set CUSTOMER_NAME = '" + guna2TextBoxCusName.Text + "', CUSTOMER_ADD = '" + guna2TextBoxCusAdd.Text + "', CUSTOMER_TP = '" + guna2TextBoxCusTele.Text + "', CU_PASSWORD = '" + guna2TextBoxCusPW.Text + "' where CUSTOMER_ID = '" + guna2TextBoxCusID.Text + "' ";     //updating customers
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated Succesfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Error Updating Customer !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunaPictureBoxDeleteCus_Click(object sender, EventArgs e)    //to delete customers
        {
            if (guna2TextBoxCusID.Text == "")
            {
                MessageBox.Show("Please Enter Customer ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxCusName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    string constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "delete from CUSTOMER where CUSTOMER_ID = '"+guna2TextBoxCusID.Text+"' ";      //deleting customers
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Succesfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Error Deleting Customer !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void gunaPictureBoxViewCus_Click(object sender, EventArgs e)     //customers data grid view
        {
            String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            String sql = "select * from CUSTOMER";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCus.DataSource = dt;

        }
    }
}
