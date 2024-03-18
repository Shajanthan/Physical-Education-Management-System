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
    public partial class TimeSchedule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");
        void faculty()
        {
            cb2.Items.Clear();
            cb1.Items.Clear();
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "Select Faculty from Faculty";
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cb1.Items.Add(dr["Faculty"].ToString());
                cb2.Items.Add(dr["Faculty"].ToString());
            }
            con.Close();
        }
            void all()
        {
            con.Open();
            string que = "select * from Schedule order by Date ASC";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvSch.DataSource = ds.Tables[0];
            
            con.Close();
        }
        public TimeSchedule()
        {
            InitializeComponent();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void TimeSchedule_Load(object sender, EventArgs e)
        {
            all();
            faculty();
            btnSch.BackColor = Color.LightGray;
            btnSch.ForeColor = Color.Black;
            
        }

        private void btnInst_Click_1(object sender, EventArgs e)
        {
            Close();
            Instruments ins = new Instruments();
            ins.Show();
        }

        private void btnStaff_Click_1(object sender, EventArgs e)
        {
            Close();
            Staff staff = new Staff();
            staff.Show();
        }

        private void btnTeam_Click_1(object sender, EventArgs e)
        {
            Close();
            TeamSelection ts = new TeamSelection();
            ts.Show();
        }

        private void btnSports_Click_1(object sender, EventArgs e)
        {
            Close();
            Sports sport = new Sports();
            sport.Show();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Close();
            Home home = new Home();
            home.Show();
        }

        private void cb1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (cb1.Text == cb2.Text)
            {
                MessageBox.Show("Select Different Faculty");
            }
            else if (cb1.Text == "" || cb2.Text == "")
            {
                MessageBox.Show("Dont leave empty");
            }
            else if (tbSport.Text == "" || tbVenue.Text == "") {
                MessageBox.Show("Dont leave empty");
            }
            else
            {
                String q = "select convert(Varchar(10),Time) from Schedule where convert(Varchar(10),Time)='" + dtpTime.Text + "'";
                SqlCommand cm = new SqlCommand(q, con);
                string p = (string)cm.ExecuteScalar();
                if (p == dtpDate.Text)
                {
                    MessageBox.Show("Already Exist");
                }
                else
                {
                    String query = "insert into Schedule values('" + dtpDate.Text.ToLower() + "','" + dtpTime.Text.ToLower() + "','" + tbSport.Text.ToLower() + "','" + tbVenue.Text.ToLower() + "','" + cb1.Text.ToLower() + "','" + cb2.Text.ToLower() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Sucessfully");
                    tbSport.Text = "";
                    tbVenue.Text = "";
                    cb1.Text = "";
                    cb2.Text = "";
                }
            }
            con.Close();
            all();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            if (dtpDate.Text == "" || dtpTime.Text == "" || cb1.Text == "" || cb2.Text == "" || tbSport.Text == "" || tbVenue.Text == "")
            {
                MessageBox.Show("Do not leave Empty!!!");
            }
            else
            {
                string q = "update Schedule Set Date='" + dtpDate.Text.ToLower() + "', Time ='" + dtpTime.Text.ToLower() + "' where Sport='"+tbSport.Text.ToLower()+ "' AND Team1 like '" + cb1.Text.ToLower() + "' AND Team2 like '" + cb2.Text.ToLower() + "'";
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
            if (tbSport.Text == ""||tbVenue.Text==""||cb1.Text==""||cb2.Text==""||dtpDate.Text=="")
            {
                MessageBox.Show("Fill all details");
            }
            else
            {
                DialogResult k = MessageBox.Show("Are you sure?", "Delete Sport", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (k == DialogResult.OK)
                {
                    string q = "delete from Schedule where Date='" + dtpDate.Text.ToLower() + "' and Team1='" + cb1.Text.ToLower() + "' and Team2='" + cb2.Text.ToLower() + "' and Sport='" + tbSport.Text.ToLower() + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Delete Sucessfully");
                    tbSport.Text = "";
                    tbVenue.Text = "";
                    cb1.Text = "";
                    cb2.Text = "";
                }
                    
            }
            con.Close();
            all();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
