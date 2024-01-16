using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe
{
    public partial class menuform : Form
    {
        public menuform()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBoxBack3_Click(object sender, EventArgs e)    //go back
        {
            logging l3= new logging();
            l3.Show();
            this.Hide();
        }

        private void gunaPictureBoxPayNow_Click(object sender, EventArgs e)     //head to payment tab
        {
            Payment p1 = new Payment();
            p1.Show();
            this.Hide();
        }

        private void gunaPictureBoxDisplayBill_Click(object sender, EventArgs e)  //calculate total bill
        {
            int icecoffee, cappuccino, mojito, milkshake, devilpizza, burgermagic, kickassburger , chocolatedonut ;     //declaring variables which represent textboxes
            int total;

            try     //exception handling
            {
                icecoffee = Convert.ToInt32(textBoxIceCoffee.Text);             //converting price into integers
                cappuccino = Convert.ToInt32(textBoxCappuccino.Text);
                mojito = Convert.ToInt32(textBoxMojito.Text);
                milkshake = Convert.ToInt32(textBoxMilkShake.Text);
                devilpizza = Convert.ToInt32(textBoxDevilPzza.Text);
                burgermagic = Convert.ToInt32(textBoxBrgrMagic.Text);
                kickassburger = Convert.ToInt32(textBoxKickassBrgr.Text);
                chocolatedonut = Convert.ToInt32(textBoxChcltDonut.Text);

                total = (icecoffee * 500) + (cappuccino * 350) + (mojito * 800) + (milkshake * 600) + (devilpizza * 2500)       //calculating total bill
                                    + (burgermagic * 1000) + (kickassburger * 800) + (chocolatedonut * 500);
                guna2TextBoxtotalbill.Text = total.ToString();      //assign total to textbox
            }
                

            catch(FormatException)     //exception handling
            {
                MessageBox.Show("Enter Valid Numbers :","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        

        }
    }
}
