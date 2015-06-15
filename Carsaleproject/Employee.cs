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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            id();
        }
        dBConnection db = new dBConnection();
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
            formLoad.productLoad();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }
        private void id()
        {
            int idn;
            string comd = "SELECT * from car.employee";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                int a = Convert.ToInt16(rd["eid"]);
                a++;
                eid.Text = Convert.ToString(a);

            }

            db.conn.Close();
        }
        public void AddEmployee() {
            try
            {
                byte[] imagebt = null;
                FileStream fst = new FileStream(this.pathget.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fst);
                imagebt = br.ReadBytes((int)fst.Length);

                string comd = "INSERT INTO car.employee(eid,fname,lname,adr1,adr2,adr3,nic,date,contNum1,contNUm2,photo) VALUES(@id,@fname,@lname,@add1,@add2,@add3,@nic,@date,@land,@mobile,@img)";
                db.cmd.CommandText = comd;
                db.cmd.Parameters.Add(new MySqlParameter("@img", imagebt));
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Save Success");
                    cleartext();
                    db.cmd.Parameters.Clear();
                }

                else
                {
                    MessageBox.Show("Not save");
                }
            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
            }
        
        }

        public void UpdateEmployee() { 
        
            try {
                string comd = "UPDATE car.employee SET eid=@id,fname=@fname ,lname=@Lname , adr1=@add1 , adr2 =@add2 , adr3=@add3 , nic=@nic ,contNum2=@land ,contNum2=@mobile , mail =@email ,date=@date  WHERE fname=@fname";
                db.cmd.CommandText = comd;
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Update Success");
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
            }
                

            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        
        
        }

        public void RemoveEmployee() {
            try
            {
                string comd = "DELETE FROM car.employee WHERE fname='" + this.fname.SelectedItem + "'";
                db.cmd.CommandText = comd;
                //GetTextboxValue();
                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();


                if (count == 1)
                {
                    MessageBox.Show("Delete Success");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }
                db.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        public void searchemployee() {
            string comd = "SELECT*FROM car.employee WHERE fname='"+this.fname.SelectedItem+"'";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            rd.Read();
                eid.Text = rd["eid"].ToString();
                elname.Text = rd["lname"].ToString();
                eadd1.Text = rd["adr1"].ToString();
                eadd2.Text = rd["adr2"].ToString();
                eadd3.Text = rd["adr3"].ToString();
                enic.Text = rd["nic"].ToString();
                edate.Text = rd["date"].ToString();
                emobile.Text = rd["contNum1"].ToString();
                eland.Text = rd["contNum2"].ToString();

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
        public void GetTextboxValue()
        {
            db.cmd.Parameters.AddWithValue("id", eid.Text);
            db.cmd.Parameters.AddWithValue("fname", fname.Text);
            db.cmd.Parameters.AddWithValue("lname", elname.Text);
            db.cmd.Parameters.AddWithValue("add1", eadd1.Text);
            db.cmd.Parameters.AddWithValue("add2", eadd2.Text);
            db.cmd.Parameters.AddWithValue("add3", eadd3.Text);
            db.cmd.Parameters.AddWithValue("nic", enic.Text);
            db.cmd.Parameters.AddWithValue("land", eland.Text);
            db.cmd.Parameters.AddWithValue("mobile", emobile.Text);          
            db.cmd.Parameters.AddWithValue("date", edate.Text);
         
        }
        public void cleartext() {
            eid.Clear();
            fname.Text = "";
            elname.Clear();
            enic.Clear();
            eadd1.Clear();
            eadd2.Clear();
            eadd3.Clear();
            emobile.Clear();
            eland.Clear();
            edate.ResetText();
            pictureBox1.Image = null;
            pictureBox1.ImageLocation = null;
            pathget.Clear();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            string comd = "SELECT  * FROM car.employee";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while (rd.Read())
            {
                fname.Items.Add(rd["fname"].ToString());
            }
            db.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            searchemployee();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloca = dlg.FileName.ToString();
                pathget.Text = picloca;
                pictureBox1.ImageLocation = picloca;
            }
        }
    }
}
