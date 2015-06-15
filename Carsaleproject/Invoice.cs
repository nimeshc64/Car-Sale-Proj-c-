using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Carsaleproject
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
            id();
            combo();
            combo1();
        }
        dBConnection db = new dBConnection();

        private void id()
        {
            string comd = "SELECT * from car.invoice";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                int a = Convert.ToInt16(rd["inId"]);
                a++;
               textBox1.Text =Convert.ToString(a);
            }

            db.conn.Close();
        }
        private void combo()
        {
            string comd = "SELECT  fname FROM car.customer";
            db.cmd.CommandText = comd;
            db.conn.Open();
            comboBox1.Items.Clear();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd["fname"].ToString());

            }
            db.conn.Close();
        }
        private void combo1()
        {
            string comd = "SELECT  * FROM car.stock";
            db.cmd.CommandText = comd;
            db.conn.Open();
            comboBox1.Items.Clear();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["brand"].ToString());

            }
            db.conn.Close();
        }
        public void Searchcustomer()
        {
           
                string comd = "SELECT * FROM car.customer WHERE fname='" + this.comboBox2.SelectedItem + "'";
                db.cmd.CommandText = comd;

                db.conn.Open();
                MySqlDataReader rd = db.cmd.ExecuteReader();
                rd.Read();
                textBox8.Text = rd["fname"].ToString();
                textBox9.Text = rd["nic"].ToString();
                textBox10.Text = rd["contNum1"].ToString();
                textBox11.Text = rd["date"].ToString();
                

                db.conn.Close();
            

        }
        public void Searchcar()
        {

            string comd = "SELECT * FROM car.stock WHERE brand='" + this.comboBox1.SelectedItem + "'";
            db.cmd.CommandText = comd;

            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            rd.Read();
           textBox2.Text = rd["brand"].ToString();
            textBox3.Text = rd["model"].ToString();
            textBox4.Text = rd["chasyNo"].ToString();
            textBox7.Text = rd["color"].ToString();


            db.conn.Close();


        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ovalShape6_Click(object sender, EventArgs e)
        {
            formLoad.homeLoad();
            this.Hide();
        }

        private void ovalShape4_Click(object sender, EventArgs e)
        {
            formLoad.supplierLoad();
            this.Hide();
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {
            formLoad.employeeLoad();
            this.Hide();

        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            formLoad.customerLoad();
            this.Hide();
        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            formLoad.salaryLoad();
            this.Hide();
        }

        private void ovalShape5_Click(object sender, EventArgs e)
        {
            formLoad.productLoad();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchcustomer();
        }

        private void Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchcar();
        }
    }
}
