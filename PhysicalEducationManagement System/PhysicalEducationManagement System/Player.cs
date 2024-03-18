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
    public partial class Player : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");
        public Player()
        {
            InitializeComponent();
        }

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
        private void Player_Load(object sender, EventArgs e)
        {
            faculty();

            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");

            sport();
            cbSports.Sorted = true;

            cbYOF.Items.Add("1st Year");
            cbYOF.Items.Add("2nd Year");
            cbYOF.Items.Add("3rd Year");
            cbYOF.Items.Add("4th Year");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbReg.Clear();
            tbName.Clear();
            cbGender.Text = String.Empty;
            cbFaculty.Text=String.Empty;
            cbSports.Text = String.Empty;
            cbYOF.Text = String.Empty;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            string r = tbReg.Text.ToLower();
            string n = tbName.Text.ToLower();
            string g = cbGender.Text.ToLower();
            string f = cbFaculty.Text.ToLower();
            string y = cbYOF.Text.ToLower();
            string s = cbSports.Text.ToLower();
            if (r == "" || n == "" || g == "" || f == "" || y == "" || s == "")
            {
                MessageBox.Show("Fill all the details above");
            }
            else {
                string q = "Select RegNo,Sport from Players where RegNo='" + r + "' and Sport ='" + s + "'";
                SqlCommand cm = new SqlCommand(q, con);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet d = new DataSet();
                da.Fill(d);
                int i = d.Tables[0].Rows.Count;
                if (i < 1)
                {
                    String query = "insert into Players values('" + r + "','" + n + "','" + g + "','" + f + "','" + s + "','" + y + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player Added Sucessfully");
                    
                }
                else
                {
                    MessageBox.Show("Player Already in a list");
                }
            }
            con.Close();
            tbReg.Clear();
            tbName.Clear();
            cbGender.Text = String.Empty;
            cbFaculty.Text = String.Empty;
            cbSports.Text = String.Empty;
            cbYOF.Text = String.Empty;

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
            Sports s = new Sports();
            s.Show();
        }
    }
}
