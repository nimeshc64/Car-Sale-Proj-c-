using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Carsaleproject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            currenttime.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.customerLoad();
            this.Hide();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.productLoad();
            this.Hide();
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.employeeLoad();
            this.Hide();
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.supplierLoad();
            this.Hide();
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.invoiceLoad();
            this.Hide();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            formLoad.salaryLoad();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            this.time.Text = t.ToString("HH:mm:ss");
            this.date.Text = t.ToString("yyyy.MM.dd");
        }

        private void ovalShape11_Click(object sender, EventArgs e)
        {
            formLoad.reportLoad();
            this.Hide();
        }

        private void ovalShape11_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void ovalShape11_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ovalShape7_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void ovalShape8_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void ovalShape9_Click(object sender, EventArgs e)
        {
            Process.Start("firefox.exe");
        }

        private void ovalShape10_Click(object sender, EventArgs e)
        {
            Process.Start("wmplayer.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
