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
    public partial class adminMenu : Form
    {
        public adminMenu()
        {
            InitializeComponent();
        }

        private void gunaPictureBoxBack1_Click(object sender, EventArgs e)     //go back
        {
            adminLogging al1 = new adminLogging();
            al1.Show();
            this.Hide();
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)    // to insert items to database
        {
            if(guna2TextBoxItemCode.Text == "")    //validating item code
            {
                MessageBox.Show("Enter Item ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxItemName.Text == "")     //validating item name
            {
                MessageBox.Show("Enter Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxItemPrice.Text == "")     //validating item price
            {
                MessageBox.Show("Enter Item Price !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try  
                {
                    String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";     //database connection
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "insert into ITEM values ('" + guna2TextBoxItemCode.Text + "','" + guna2TextBoxItemName.Text + "','" + guna2TextBoxItemPrice.Text + "')";     //insert item values
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Added Successfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch 
                {
                    MessageBox.Show("Error Adding Item !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }


        private void gunaPictureBoxUpdateItem_Click(object sender, EventArgs e)     //to update item details
        {
            if (guna2TextBoxItemCode.Text == "")
            {
                MessageBox.Show("Enter Item ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxItemName.Text == "")
            {
                MessageBox.Show("Enter Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxItemPrice.Text == "")
            {
                MessageBox.Show("Enter Item Price !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "update ITEM set ITEM_NAME = '" + guna2TextBoxItemName.Text + "', PRICE = '"+guna2TextBoxItemPrice.Text+"' where ITEM_ID = '"+guna2TextBoxItemCode.Text+"' ";   //updating
                    SqlCommand cmd = new SqlCommand(sql, con); 
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated Successfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch
                {
                    MessageBox.Show("Error Updating Item !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunaPictureBoxDeleteItem_Click(object sender, EventArgs e)   //to delete items
        {
            if (guna2TextBoxItemCode.Text == "")
            {
                MessageBox.Show("Enter Item ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (guna2TextBoxItemName.Text == "")
            {
                MessageBox.Show("Enter Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    String sql = "delete from ITEM where ITEM_ID = '" + guna2TextBoxItemCode.Text + "' ";   //deleting items
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully !!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch
                {
                    MessageBox.Show("Error Deleting Item !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunaPictureBoxViewItems_Click(object sender, EventArgs e)   //items data grid view
        {
            try
            {
                String constring = "Data Source=DESKTOP-4HR2PSI\\SQLEXPRESS;Initial Catalog=LICAFE;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                con.Open();

                String sql = " select * from ITEM " ;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridViewItems.DataSource = dt;
            }

            catch
            {
                MessageBox.Show("Error Viewing Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaPictureBoxEditCus_Click(object sender, EventArgs e)    //customize customers tab
        {
            adminMenu2 ad2 = new adminMenu2();
            ad2.Show();
            this.Hide();
        }
    }
}
