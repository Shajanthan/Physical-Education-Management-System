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
    public partial class TeamSelection : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");
        void faculty()
        {
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
            }
            con.Close();
        }
        void all()
        {
            string que;
            con.Open();
            if (cbSports.Text == "")
            {
                if (cbFaculty.Text == "")
                {
                    que = "Select * from Players";
                }
                else
                {
                    que = "select  * from Players where Faculty like '" + cbFaculty.Text.ToLower() + "'";
                }
            }
            else
            {
                if (cbFaculty.Text == "")
                {
                    que = "select  * from Players where Sport like '" + cbSports.Text.ToLower() + "'";
                }
                else
                {
                    que = "Select  * from Players where Sport like '" + cbSports.Text.ToLower() + "'AND Faculty like '" + cbFaculty.Text.ToLower() + "'";
                }

            }
            
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvSelection.DataSource = ds.Tables[0];
            con.Close();
        }
        void final() {
            con.Open();
            string que = "select * from finalize";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvPrint.DataSource = ds.Tables[0];
            con.Close();
        }
        void sport()
        {
            cbSports.Items.Clear();
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
            }
            con.Close();
        }
        
        public TeamSelection()
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

        private void TeamSelection_Load(object sender, EventArgs e)
        {
           
            DataGridViewCheckBoxColumn checkboxcol = new DataGridViewCheckBoxColumn();
            checkboxcol.Width = 40;
            checkboxcol.Name = "check1";
            checkboxcol.HeaderText = "";
            dgvSelection.Columns.Insert(0,checkboxcol);
            
            all();
            sport();
            faculty();
            btnTeam.BackColor = Color.LightGray;
            btnTeam.ForeColor = Color.Black;

            

            cbSports.Sorted = true;
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Close();
            Home home = new Home();
            home.Show();
        }

        private void btnSports_Click_1(object sender, EventArgs e)
        {
            Close();
            Sports sport = new Sports();
            sport.Show();
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
            Staff staff = new Staff();
            staff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            all();
        }

       

        private void btnprint_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "delete from finalize";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            foreach (DataGridViewRow row in dgvSelection.Rows)
            {
                bool select1 = Convert.ToBoolean(row.Cells["check1"].Value);
                if (select1)
                {
                    SqlCommand cmd1 = new SqlCommand("insert into Finalize(RegNo,Name,YOS) values(@RegNo,@Name,@YOS)", con);
                    cmd1.Parameters.AddWithValue("RegNo", row.Cells["RegNo"].Value);
                    cmd1.Parameters.AddWithValue("Name", row.Cells["Name"].Value);
                    cmd1.Parameters.AddWithValue("YOS", row.Cells["YOS"].Value);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            final();
            TeamSelectionPrint pr = new TeamSelectionPrint();
            pr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
