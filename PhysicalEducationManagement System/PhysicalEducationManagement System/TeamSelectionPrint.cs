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
    public partial class TeamSelectionPrint : Form
    {
        public TeamSelectionPrint()
        {
            InitializeComponent();
        }

        private void TeamSelectionPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PrintData.Finalize' table. You can move, or remove it, as needed.
            this.FinalizeTableAdapter.Fill(this.PrintData.Finalize);

            this.reportViewer1.RefreshReport();
        }
    }
}
