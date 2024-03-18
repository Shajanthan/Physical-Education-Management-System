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
    public partial class Sports : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");
        void sport() {
            cbSports.Items.Clear();
            cbsports2.Items.Clear();
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "Select Sport from Sports";
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cm);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbSports.Items.Add(dr["Sport"].ToString());
                cbsports2.Items.Add(dr["Sport"].ToString());
            }
            con.Close();
        }
        void faculty()
        {
            cbFac2.Items.Clear();
            cbFaculty.Items.Clear();
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
                cbFaculty.Items.Add(dr["Faculty"].ToString());
                cbFac2.Items.Add(dr["Faculty"].ToString());
            }
            con.Close();
        }
        void all()
        {
            string que;
            con.Open();
            if (cbSports.Text == "") {
                if (cbFaculty.Text == "")
                {
                    que = "Select * from Players";
                }
                else {
                    que = "select * from Players where Faculty like '" + cbFaculty.Text + "'";
                }
            }
            else
            {
                if (cbFaculty.Text == "")
                {
                    que = "select * from Players where Sport like '" + cbSports.Text + "'";
                }
                else {
                    que = "Select * from Players where Sport like '" + cbSports.Text + "'AND Faculty like '" + cbFaculty.Text + "'";
                }
                
            }
            
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvPlayersDetails.DataSource = ds.Tables[0];
            con.Close();
        }
        public Sports()
        {
            InitializeComponent();
        }

        private void Sports_Load(object sender, EventArgs e)
        {
            faculty();
            sport();
            all();
            btnSports.BackColor = Color.LightGray;
            btnSports.ForeColor = Color.Black;

            cbFaculty.Sorted = true;
            cbFac2.Sorted = true;
            cbSports.Sorted=true;
            
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
            Home home = new Home();
            home.Show();
        }

        private void btnTeam_Click_1(object sender, EventArgs e)
        {
            Close();
            TeamSelection ts = new TeamSelection();
            ts.Show();
        }

        private void btnSch_Click_1(object sender, EventArgs e)
        {
            Close();
            TimeSchedule ts = new TimeSchedule();
            ts.Show();
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
            Staff st = new Staff();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Player pl = new Player();
            pl.Show();
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            if (cbSports.Items.Contains(tbSports.Text))
            {
                MessageBox.Show("Sport is already in a list");
            }
            else {
                con.Open();
                String query = "insert into Sports values('" + tbSports.Text.ToLower() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sport added successfully");
            }
            sport();
            tbSports.Clear();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            all();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?", "Delete Sport", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                con.Open();
                SqlCommand cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "delete from Sports where Sport='" + cbsports2.Text.ToLower() + "'";
                cm.ExecuteNonQuery();
                con.Close();
                sport();
                MessageBox.Show("Sport deleted successfully");
                cbsports2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeletePlayer dp = new DeletePlayer();
            dp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbFaculty.Items.Contains(tbfac.Text.ToLower()))
            {
                MessageBox.Show("Faculty is already in a list");
            }
            else
            {
                con.Open();
                String query = "insert into Faculty values('" + tbfac.Text.ToLower() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Faculty added successfully");
            }
            faculty();
            tbfac.Clear();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?", "Delete Faculty", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                con.Open();
                SqlCommand cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "delete from Faculty where Faculty='" + cbFac2.Text.ToLower() + "'";
                cm.ExecuteNonQuery();
                con.Close();
                faculty();
                MessageBox.Show("Faculty deleted successfully");
                cbFac2.Text = "";
            }
        }
    }
}
