
namespace LeavePortal.Report
{
    partial class RptLeaveType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRptSearch = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnRptSearch
            // 
            this.btnRptSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRptSearch.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptSearch.ForeColor = System.Drawing.Color.White;
            this.btnRptSearch.Location = new System.Drawing.Point(59, 75);
            this.btnRptSearch.Name = "btnRptSearch";
            this.btnRptSearch.Size = new System.Drawing.Size(229, 57);
            this.btnRptSearch.TabIndex = 0;
            this.btnRptSearch.Text = "Leave Type Report";
            this.btnRptSearch.UseVisualStyleBackColor = false;
            this.btnRptSearch.Click += new System.EventHandler(this.btnRptSearch_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // RptLeaveType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRptSearch);
            this.Name = "RptLeaveType";
            this.Size = new System.Drawing.Size(1218, 696);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRptSearch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
