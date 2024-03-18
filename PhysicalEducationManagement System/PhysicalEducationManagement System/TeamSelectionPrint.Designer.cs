namespace PhysicalEducationManagement_System
{
    partial class TeamSelectionPrint
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
            this.FinalizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintData = new PhysicalEducationManagement_System.PrintData();
            this.FinalizeTableAdapter = new PhysicalEducationManagement_System.PrintDataTableAdapters.FinalizeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FinalizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintData)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FinalizeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PhysicalEducationManagement_System.Print.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(656, 626);
            this.reportViewer1.TabIndex = 0;
            // 
            // FinalizeBindingSource
            // 
            this.FinalizeBindingSource.DataMember = "Finalize";
            this.FinalizeBindingSource.DataSource = this.PrintData;
            // 
            // PrintData
            // 
            this.PrintData.DataSetName = "PrintData";
            this.PrintData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FinalizeTableAdapter
            // 
            this.FinalizeTableAdapter.ClearBeforeFill = true;
            // 
            // TeamSelectionPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 626);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TeamSelectionPrint";
            this.Text = "TeamSelectionPrint";
            this.Load += new System.EventHandler(this.TeamSelectionPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FinalizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FinalizeBindingSource;
        private PrintData PrintData;
        private PrintDataTableAdapters.FinalizeTableAdapter FinalizeTableAdapter;
    }
}