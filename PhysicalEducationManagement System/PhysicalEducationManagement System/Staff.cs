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
    public partial class Staff : Form
    {
        public Staff()
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

        private void Staff_Load(object sender, EventArgs e)
        {
            btnStaff.BackColor = Color.LightGray;
            btnStaff.ForeColor = Color.Black;
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
    }
}
