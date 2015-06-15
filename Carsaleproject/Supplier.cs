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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            combo();
            clr();
            id();
            
        }
        
        dBConnection db = new dBConnection();
        string type = "";
        string imageloc = "";
        
        public void AddSupplier()
        {
           try
            {
                byte[] imagebt = null;
                FileStream fst = new FileStream(imageloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fst);
                imagebt = br.ReadBytes((int)fst.Length);

                string comd = "INSERT INTO car.supliar(sid,fname,lname,nic,adr1,adr2,adr3,contNum1,contNum2,email,photo,type) VALUES(@sid,@fname,@lname,@nic,@add1,@add2,@add3,@con1,@con2,@mail,@img,@type)";
               
                db.cmd.CommandText = comd;
                db.cmd.Parameters.Add(new MySqlParameter("@img", imagebt));
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Save Success","Message");
                }

                else
                {
                    MessageBox.Show("Not save","Message");
                    clr();
                }
                clr();
                id();
                combo();
                
           }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
                clr();
           }
           
        }

        public void Updatesupliar()
        {
            try
            {
                string comd = "UPDATE car.supliar SET fname=@fname,lname=@lname,nic=@nic,adr1=@add1,adr2=@add2,adr3=@add3,contNum1=@con1,contNum2=@con2,email=@mail,type=@type  WHERE sid=@sid";
                db.cmd.CommandText = comd;
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Update Success","Message");
                }
                else
                {
                    MessageBox.Show("Not Updated","Message");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clr();
           

        }

        public void Searchsupliar()
        {

            string comd = "SELECT*FROM car.supliar WHERE fname='" + this.comboBox1.SelectedItem + "'";
            db.cmd.CommandText = comd;

            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            rd.Read();
            textBox1.Text = rd["sid"].ToString();
            textBox2.Text = rd["lname"].ToString();
            textBox3.Text = rd["nic"].ToString();
            textBox10.Text = rd["adr1"].ToString();
            textBox4.Text = rd["adr2"].ToString();
            textBox5.Text = rd["adr3"].ToString();
            textBox6.Text = rd["contNum1"].ToString();
            textBox7.Text = rd["contNum2"].ToString();
            textBox8.Text = rd["email"].ToString();
            type = rd["type"].ToString();
            if (type == "Foreign")
            {
                radioButton1.Checked = true;
            }
            else {
                radioButton2.Checked = true;
            }
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

        public void Deletesupliar()
        {
            try
            {
                string comd = "DELETE FROM car.supliar WHERE fname='" + this.comboBox1.SelectedItem + "'";
                db.cmd.CommandText = comd;
                //GetTextboxValue();
                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();


                if (count == 1)
                {
                    MessageBox.Show("Delete Success","Message");
                }
                else
                {
                    MessageBox.Show("Not Deleted","Message");
                }
                db.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clr();
           
        }

        public void GetTextboxValue()
        {
            db.cmd.Parameters.AddWithValue("sid", textBox1.Text);
            db.cmd.Parameters.AddWithValue("fname", comboBox1.Text);
            db.cmd.Parameters.AddWithValue("lname", textBox2.Text);
            db.cmd.Parameters.AddWithValue("nic", textBox3.Text);
            db.cmd.Parameters.AddWithValue("add1", textBox10.Text);
            db.cmd.Parameters.AddWithValue("add2", textBox4.Text);
            db.cmd.Parameters.AddWithValue("add3", textBox5.Text);
            db.cmd.Parameters.AddWithValue("con1", textBox6.Text);
            db.cmd.Parameters.AddWithValue("con2", textBox7.Text);
            db.cmd.Parameters.AddWithValue("mail", textBox8.Text);
            db.cmd.Parameters.AddWithValue("type", type);


        }
        private void clr()
        {
            textBox1.Clear();
            textBox10.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
         //   comboBox1=null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
          //  pictureBox1 = null;

        }
        private void combo()
        {



            string comd = "SELECT  fname FROM car.supliar";
            db.cmd.CommandText = comd;
            db.conn.Open();
            comboBox1.Items.Clear();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while(rd.Read())
            {
                comboBox1.Items.Add(rd["fname"].ToString());
                
            }
            db.conn.Close();
        }
        private void id() {
            string comd = "SELECT * from car.supliar";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read()) 
            {
               int a =Convert.ToInt16(rd["sid"]);
               a++;
               textBox1.Text = a.ToString();
            }

            db.conn.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddSupplier();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updatesupliar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               
                imageloc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = imageloc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deletesupliar();
        }

        private void ovalShape6_Click(object sender, EventArgs e)
        {
            formLoad.homeLoad();
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
            formLoad.employeeLoad();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Searchsupliar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "Foreign";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "Local";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
