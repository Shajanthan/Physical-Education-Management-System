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
    public partial class print_borrow : Form
    {
        public print_borrow()
        {
            InitializeComponent();
        }

        private void print_borrow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'borrowDetails.DataTable1' table. You can move, or remove it, as needed.
            this.BorrowedTableAdapter.Fill(this.borrowDetails.Borrowed);

            this.reportViewer1.RefreshReport();

        }
    }
}
