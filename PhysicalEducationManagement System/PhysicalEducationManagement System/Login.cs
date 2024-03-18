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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tbUsername.Text == "Admin" && tbPassword.Text == "admin123")
            {
                Close();
                Home h = new Home();
                h.Show();
            }
            else {
                MessageBox.Show("Invalid username and password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact System Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
          
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {

        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbUsername.Text == "Admin" && tbPassword.Text == "admin123")
                {
                    Close();
                    Home h = new Home();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                tbPassword.Focus();
            }
        }
    }
}
