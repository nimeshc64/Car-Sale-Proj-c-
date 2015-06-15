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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }
        dBConnection db = new dBConnection();
       
        private void label6_Click(object sender, EventArgs e)
        {

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
            AddCustomer();
        }

        public void AddCustomer() {
            try
            {
                byte[] imagebt = null;
                FileStream fst = new FileStream(this.pathget.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fst);
                imagebt = br.ReadBytes((int)fst.Length);
                
                string comd = "INSERT INTO car.customer(cid,fname,lname,adr1,adr2,adr3,nic,date,contNum1,contNUm2,mail,photo) VALUES(@id,@fname,@lname,@add1,@add2,@add3,@nic,@date,@land,@mobile,@email,@img)";
                db.cmd.CommandText = comd;
                db.cmd.Parameters.Add(new MySqlParameter("@img", imagebt));
                GetTextboxValue();

                db.conn.Open();
                int count = db.cmd.ExecuteNonQuery();
                db.conn.Close();

                if (count == 1)
                {
                    MessageBox.Show("Save Success");
                }

                else
                {
                    MessageBox.Show("Not save");
                }
                br.Close();
                fst.Close();
            }

            catch (Exception me) {
                MessageBox.Show(me.Message);
            }
        }

        public void UpdateCustomer(){
            try {
                string comd = "UPDATE car.customer SET cid=@id,fname=@fname ,lname=@Lname , adr1=@add1 , adr2 =@add2 , adr3=@add3 , nic=@nic ,contNum2=@land ,contNum2=@mobile , mail =@email ,date=@date  WHERE fname=@fname";
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

        public void SearchCustomer() {
            
            string comd = "SELECT*FROM car.customer WHERE fname='"+this.fName.SelectedItem+"'";
            db.cmd.CommandText = comd;
     
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            rd.Read();
                cID.Text = rd["cid"].ToString();
                cLName.Text = rd["lname"].ToString();
                cAdd1.Text = rd["adr1"].ToString();
                cAdd2.Text = rd["adr2"].ToString();
                cAdd3.Text = rd["adr3"].ToString();
                cNIC.Text = rd["nic"].ToString();
                cDate.Text = rd["date"].ToString();
                cMobile.Text = rd["contNum1"].ToString();
                cland.Text = rd["contNum2"].ToString();
                cEmail.Text = rd["mail"].ToString();

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

        public void DeleteCustomer() {
            try
            {
                string comd = "DELETE FROM car.customer WHERE fname='"+this.fName.SelectedItem+"'";
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
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        public void GetTextboxValue() {
            db.cmd.Parameters.AddWithValue("id", cID.Text);
            db.cmd.Parameters.AddWithValue("fname",fName.Text);
            db.cmd.Parameters.AddWithValue("lname", cLName.Text);
            db.cmd.Parameters.AddWithValue("add1", cAdd1.Text);
            db.cmd.Parameters.AddWithValue("add2", cAdd2.Text);
            db.cmd.Parameters.AddWithValue("add3", cAdd3.Text);
            db.cmd.Parameters.AddWithValue("nic", cNIC.Text);
            db.cmd.Parameters.AddWithValue("land", cland.Text);
            db.cmd.Parameters.AddWithValue("mobile", cMobile.Text);
            db.cmd.Parameters.AddWithValue("email", cEmail.Text);
            db.cmd.Parameters.AddWithValue("date", cDate.Text);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            string comd = "SELECT  * FROM car.customer";
            db.cmd.CommandText = comd;
            db.conn.Open();
            MySqlDataReader rd = db.cmd.ExecuteReader();
            while(rd.Read()){
                fName.Items.Add(rd["fname"].ToString());
            }
            db.conn.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void button5_Click(object sender, EventArgs e)
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
