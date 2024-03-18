using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicalEducationManagement_System
{
    public partial class Home : Form
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void btnSports_Click(object sender, EventArgs e)
        {
            Close();
            Sports sport = new Sports();
            sport.Show();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Are you sure?","Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (k == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.LightGray;
            btnHome.ForeColor = Color.Black;
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

        private void btnInst_Click(object sender, EventArgs e)
        {
            Close();
            Instruments ins = new Instruments();
            ins.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Close();
            Staff staff = new Staff();
            staff.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
