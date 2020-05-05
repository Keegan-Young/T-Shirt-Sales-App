using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOT8_2
{
    public partial class FormCrazyCranks : Form
    {
        public FormCrazyCranks()
        {
            InitializeComponent();
        }

        // Constants
        const string DISCOUNT1 = "30%";
        const string DISCOUNT2 = "20%";
        const string DISCOUNT3 = "10%";
        const double DISCOUNTSHIRT1 = 9.62;
        const double DISCOUNTSHIRT2 = 11.0;
        const double DISCOUNTSHIRT3 = 12.37;

        // Variables
        string[] discount = { "8264", "5679", "6483" };
        string discountCode = "";
        int quantity = 0;
        double discountedPrice = 0.0;
        double subtotal = 0.0;
        double tax = 0.0;
        double finalTotal = 0.0;

        private void btnOrder_Click(object sender, EventArgs e)
        {
            checkDiscountCode();
            showInvoice();
        }

        private void checkDiscountCode()
        {
            discountCode = Convert.ToString(textBoxDiscountCode.Text);

            if(discountCode == discount[0])
            {
                labelAppliedDiscount.Text = DISCOUNT1 + " Discount Applied!";
            }
            else if(discountCode == discount[1])
            {
                labelAppliedDiscount.Text = DISCOUNT2 + " Discount Applied!";
            }
            else if(discountCode == discount[2])
            {
                labelAppliedDiscount.Text = DISCOUNT3 + " Discount Applied!";
            }
            else
            {
                labelAppliedDiscount.Text = "*Invalid Discount Code";
            }
        }

        private void showInvoice()
        {
            quantity = Convert.ToInt32(textBoxQuantity.Text);

            if (quantity <= 0)
            {
                MessageBox.Show("You Must Enter A Valid Quantity",
                                "Please Enter A Quantity",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                textBoxQuantity.Text = "";
                textBoxQuantity.Focus();
                return;
            }

            if (discountCode == discount[0])
            {
                discountedPrice = DISCOUNTSHIRT1;
                subtotal = quantity * DISCOUNTSHIRT1;
            }
            else if (discountCode == discount[1])
            {
                discountedPrice = DISCOUNTSHIRT2;
                subtotal = quantity * DISCOUNTSHIRT2;
            }
            else if (discountCode == discount[2])
            {
                discountedPrice = DISCOUNTSHIRT3;
                subtotal = quantity * DISCOUNTSHIRT3;
            }
            else
            {
                discountedPrice = 13.75;
                subtotal = quantity * 13.75;
            }

            tax = subtotal * 0.08;

            finalTotal = subtotal + tax;


            labelInvoice.Text = quantity + " T-Shirts @ " + discountedPrice.ToString("c") + "\n" +
                                "-----------------------------" + "\n" +
                                "Subtotal: " + subtotal.ToString("c") + "\n" +
                                "Tax: " + tax.ToString("c") + "\n" +
                                "Total: " + finalTotal.ToString("c");
                                                                      
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            clearOrder();
        }

        private void clearOrder()
        {
            textBoxQuantity.Text = "";
            textBoxDiscountCode.Text = "";
            labelAppliedDiscount.Text = "";
            labelInvoice.Text = "";
            textBoxQuantity.Focus();
        }
    }
}
