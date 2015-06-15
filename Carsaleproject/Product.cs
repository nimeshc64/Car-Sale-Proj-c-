using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Carsaleproject
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape6_Click(object sender, EventArgs e)
        {
            formLoad.homeLoad();
            this.Hide();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.salaryLoad();
            this.Hide();
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {
            formLoad.customerLoad();
            this.Hide();
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            formLoad.invoiceLoad();
            this.Hide();
        }

        private void ovalShape4_Click(object sender, EventArgs e)
        {
            formLoad.supplierLoad();
            this.Hide();
        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            formLoad.salaryLoad();
            this.Hide();
        }

        private void ovalShape5_Click(object sender, EventArgs e)
        {
            formLoad.employeeLoad();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
