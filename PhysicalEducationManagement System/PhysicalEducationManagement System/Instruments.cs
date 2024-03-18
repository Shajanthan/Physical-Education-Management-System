using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhysicalEducationManagement_System
{
    public partial class Instruments : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");


        void all() {
            con.Open();
            string que = "select * from Instrument";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvIns.DataSource = ds.Tables[0];
            tbID.Text = "";
            tbName.Text = "";
            tbQu.Text = "";
            con.Close();
        }
        void Bo()
        {
            con.Open();
            string que = "select * from Borrowed";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
            tbBID.Text = "";
            tbSNo.Text = "";
            con.Close();
        }
        public Instruments()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Instruments_Load(object sender, EventArgs e)
        {
            all();
            Bo();
            btnInst.BackColor = Color.LightGray;
            btnInst.ForeColor = Color.Black;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
            Home hm = new Home();
            hm.Show();
        }

        private void btnSports_Click(object sender, EventArgs e)
        {
            Close();
            Sports sport = new Sports();
            sport.Show();
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            Close();
            TeamSelection ts = new TeamSelection();
            ts.Show();
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            Close();
            TimeSchedule ts = new TimeSchedule();
            ts.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Close();
            Staff staff = new Staff();
            staff.Show();
        }

        private void tbQu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            con.Open();
            if (tbID.Text == "" || tbName.Text == "" || tbQu.Text == "")
            {
                MessageBox.Show("Do not leave Empty!!!");
            }
            else {
                String q = "select convert(Varchar(10),InsID) from Instrument where convert(Varchar(10),InsID)='" + tbID.Text + "'";
                SqlCommand cm = new SqlCommand(q, con);
                string p = (string)cm.ExecuteScalar();
                if (p == tbID.Text)
                {
                    MessageBox.Show("Already Exist");
                }
                else
                {
                    String query = "insert into Instrument values('" + tbID.Text.ToLower() + "','" + tbName.Text.ToLower() + "','" + tbQu.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Sucessfully");
                    
                }
            }
            con.Close();
            all();
        }

        private void btnUpdateIns_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tbID.Text == "" || tbQu.Text == "")
            {
                MessageBox.Show("Do not leave Empty!!!");
            }
            else {
                string q = "update Instrument Set Quantity='" + tbQu.Text + "' where InsID ='" + tbID.Text + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update Sucessfully");
            }
            con.Close();
            all();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tbID.Text == "")
            {
                MessageBox.Show("Enter Instrument ID");
            }
            else {
                string q = "delete from Instrument where InsID='" + tbID.Text + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delete Sucessfully");
            }
            con.Close();
            all();
        }

        private void btnAddBo_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tbBID.Text == "" || tbSNo.Text == "")
            {
                MessageBox.Show("Do not leave Empty!!!");
            }
            else {
                string q = "insert into Borrowed(InsID,RegNo,Borrow_Date,Borrow_Time) values('" + tbBID.Text.ToLower() + "','" + tbSNo.Text.ToLower() + "','" + lblDate.Text.ToLower() + "','" + lbTime.Text.ToLower() + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Sucessfully");
            } 
            con.Close();
            Bo();
        }

       


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tbBID.Text == "" || tbSNo.Text == "")
            {
                MessageBox.Show("Do not leave Empty!!!");
            }
            else
            {
                string q = "update Borrowed Set Return_Date='"+lblDate.Text+ "',Return_Time='"+lbTime.Text+ "' where InsID='"+tbBID.Text+"' and RegNo='"+tbSNo.Text+"'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update Sucessfully");
            }
            con.Close();
            Bo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToShortTimeString();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            print_borrow pr = new print_borrow();
            pr.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
