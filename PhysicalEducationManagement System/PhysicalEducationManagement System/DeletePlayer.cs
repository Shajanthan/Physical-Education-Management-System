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
    public partial class DeletePlayer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PEMS\PhyManSys.mdf;Integrated Security=True;Connect Timeout=30");
        public DeletePlayer()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (tbPlayer.Text == "")
            {
                MessageBox.Show("Enter a valid RegNo");
            }
            else
            {
                cbPlaSport.Items.Clear();
                con.Open();
                SqlCommand cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Select Sport from Players where RegNo='" + tbPlayer.Text.ToLower() + "'";
                cm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cm);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbPlaSport.Items.Add(dr["Sport"].ToString());
                }
            }

            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbPlayer.Text == "")
            {
                MessageBox.Show("Enter a valid Reg No");
            }
            else if (cbPlaSport.Text == "")
            {
                MessageBox.Show("Select a Valid Sport");
            }
            else
            {
                DialogResult k=MessageBox.Show("Are you sure?", "Delete player", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (k == DialogResult.OK)
                {
                    con.Open();
                    String query = "delete from Players where Sport ='" + cbPlaSport.Text.ToLower() + "' and RegNo ='" + tbPlayer.Text.ToLower() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                    con.Close();
                    cbPlaSport.Items.Clear();
                    tbPlayer.Text = "";
                }
            }
            cbPlaSport.Text = "";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
            Sports s = new Sports();
            s.Show();
        }
    }
}
