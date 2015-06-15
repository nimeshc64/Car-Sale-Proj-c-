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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
            combo();
            id();
            textBox6.ReadOnly = true;
            textBox4.ReadOnly = true;
        }
        int basic;
        int ex;
        int pay;
        int totex;
        int totsal;
        int idn;
        dBConnection db = new dBConnection();
        public void Searchsalary()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select The Employee Name", "Message");
            }
            else
            {
                string comd = "SELECT * FROM car.employee WHERE fname='" + this.comboBox1.SelectedItem + "'";
                db.cmd.CommandText = comd;

                db.conn.Open();
                MySqlDataReader rd = db.cmd.ExecuteReader();
                rd.Read();
                textBox1.Text = rd["eid"].ToString();


                byte[] img = (byte[])(rd["photo"]);
                if (img == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mst = new MemoryStream(img);
                    pictureBox1.Image = System.Drawing.Image.FromStream(mst);
                }
                db.conn.Close();
            }

        }
        private void combo()
        {



            string comd = "SELECT  fname FROM car.employee";
            db.cmd.CommandText = comd;
            db.conn.Open();
            comboBox1.Items.Clear();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["fname"].ToString());

            }
            db.conn.Close();
        }
        private void sal_cal() 
        {
            basic = Convert.ToInt16(textBox5.Text);
            ex=Convert.ToInt16(textBox3.Text);
            pay = Convert.ToInt16(textBox2.Text);
            //totex = Convert.ToInt16(label19.Text);
            //totsal = Convert.ToInt16(label5.Text);
            totex = ex * pay;
            totsal = totex + basic;
            textBox4.Text = Convert.ToString(totex);
            textBox6.Text = Convert.ToString(totsal);
            
        }
        public void Addsalary()
        {
            try
            {
                

                string comd = "INSERT INTO car.salary(slid,eid,ename,basic,extaHours,payEtxaHour,totExtra,totSal) VALUES(@slid,@eid,@ename,@basic,@exho,@payex,@totex,@totsal)";

                db.cmd.CommandText = comd;
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Save Success", "Message");
                }

                else
                {
                    MessageBox.Show("Not save", "Message");
                    //clr();
                }
               // clr();
               // id();
                combo();

            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
                //clr();
            }

        }
        private void clr()
        {
            textBox1.Clear();
           
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
            textBox4.Text = null;
            textBox6.Text = null;
            textBox5.Clear();
            comboBox1.Text = null;
            
           
            //   comboBox1=null;
          
            //  pictureBox1 = null;

        }
        public void GetTextboxValue()
        {
            db.cmd.Parameters.AddWithValue("slid",idn.ToString());
            db.cmd.Parameters.AddWithValue("eid", textBox1.Text);
            db.cmd.Parameters.AddWithValue("ename", comboBox1.Text);
            db.cmd.Parameters.AddWithValue("basic", textBox5.Text);
            db.cmd.Parameters.AddWithValue("exho", textBox3.Text);
            db.cmd.Parameters.AddWithValue("payex", textBox2.Text);
            db.cmd.Parameters.AddWithValue("totex", totex);
            db.cmd.Parameters.AddWithValue("totsal",totsal);
          


        }
        private void id()
        {
            string comd = "SELECT * from car.salary";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                int a = Convert.ToInt16(rd["slid"]);
                a++;
                idn = a; ;
            }

            db.conn.Close();
        }
        private void ovalShape6_Click(object sender, EventArgs e)
        {
            formLoad.homeLoad();
            this.Hide();
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {
            formLoad.employeeLoad();
            this.Hide();
        }

        private void ovalShape4_Click(object sender, EventArgs e)
        {
            formLoad.supplierLoad();
            this.Hide();
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            formLoad.customerLoad();
            this.Hide();
        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            formLoad.invoiceLoad();
            this.Hide();
        }

        private void ovalShape5_Click(object sender, EventArgs e)
        {
            formLoad.productLoad();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Searchsalary();
        }

        private void calculete_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sal_cal();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addsalary();
            clr();
        }

        private void Salary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
