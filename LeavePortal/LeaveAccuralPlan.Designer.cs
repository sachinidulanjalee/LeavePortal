
namespace LeavePortal
{
    partial class LeaveAccuralPlan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveAccuralPlan));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridViewAP = new System.Windows.Forms.DataGridView();
            this.btnAddNewAccrualPaln = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAP)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(654, 75);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(183, 23);
            this.txtSearch.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Leave Accrual Plan";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DataGridViewAP
            // 
            this.DataGridViewAP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAP.Location = new System.Drawing.Point(58, 121);
            this.DataGridViewAP.Name = "DataGridViewAP";
            this.DataGridViewAP.RowHeadersWidth = 51;
            this.DataGridViewAP.RowTemplate.Height = 24;
            this.DataGridViewAP.Size = new System.Drawing.Size(922, 326);
            this.DataGridViewAP.TabIndex = 11;
            // 
            // btnAddNewAccrualPaln
            // 
            this.btnAddNewAccrualPaln.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewAccrualPaln.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAccrualPaln.ForeColor = System.Drawing.Color.White;
            this.btnAddNewAccrualPaln.Location = new System.Drawing.Point(58, 59);
            this.btnAddNewAccrualPaln.Name = "btnAddNewAccrualPaln";
            this.btnAddNewAccrualPaln.Size = new System.Drawing.Size(157, 55);
            this.btnAddNewAccrualPaln.TabIndex = 10;
            this.btnAddNewAccrualPaln.Text = "+ Add New";
            this.btnAddNewAccrualPaln.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(864, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(116, 39);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = " Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            // 
            // LeaveAccuralPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewAP);
            this.Controls.Add(this.btnAddNewAccrualPaln);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LeaveAccuralPlan";
            this.Size = new System.Drawing.Size(1033, 466);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridViewAP;
        private System.Windows.Forms.Button btnAddNewAccrualPaln;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Timer timer2;
    }
}
