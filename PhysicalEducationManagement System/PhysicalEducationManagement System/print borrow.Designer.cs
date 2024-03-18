namespace PhysicalEducationManagement_System
{
    partial class print_borrow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.borrowDetails = new PhysicalEducationManagement_System.borrowDetails();
            this.BorrowedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BorrowedTableAdapter = new PhysicalEducationManagement_System.borrowDetailsTableAdapters.BorrowedTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.borrowDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BorrowedBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PhysicalEducationManagement_System.BorrowDetail.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(749, 498);
            this.reportViewer1.TabIndex = 0;
            // 
            // borrowDetails
            // 
            this.borrowDetails.DataSetName = "borrowDetails";
            this.borrowDetails.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BorrowedBindingSource
            // 
            this.BorrowedBindingSource.DataMember = "Borrowed";
            this.BorrowedBindingSource.DataSource = this.borrowDetails;
            // 
            // BorrowedTableAdapter
            // 
            this.BorrowedTableAdapter.ClearBeforeFill = true;
            // 
            // print_borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 498);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "print_borrow";
            this.Text = "Borrow Details";
            this.Load += new System.EventHandler(this.print_borrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.borrowDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowedBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private borrowDetails borrowDetails;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BorrowedBindingSource;
        private borrowDetailsTableAdapters.BorrowedTableAdapter BorrowedTableAdapter;
    }
}