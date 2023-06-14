
namespace LeavePortal
{
    partial class EmployeeProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeProfile));
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvEmpProfile = new System.Windows.Forms.DataGridView();
            this.btnAddNewEmpProfile = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick_1);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(470, 109);
            this.txtEmpNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(198, 26);
            this.txtEmpNo.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Employee Profile";
            // 
            // gvEmpProfile
            // 
            this.gvEmpProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEmpProfile.Location = new System.Drawing.Point(58, 174);
            this.gvEmpProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvEmpProfile.Name = "gvEmpProfile";
            this.gvEmpProfile.RowHeadersWidth = 51;
            this.gvEmpProfile.RowTemplate.Height = 24;
            this.gvEmpProfile.Size = new System.Drawing.Size(771, 219);
            this.gvEmpProfile.TabIndex = 21;
            this.gvEmpProfile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvEmpProfile_CellDoubleClick);
            // 
            // btnAddNewEmpProfile
            // 
            this.btnAddNewEmpProfile.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewEmpProfile.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewEmpProfile.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmpProfile.Location = new System.Drawing.Point(70, 102);
            this.btnAddNewEmpProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNewEmpProfile.Name = "btnAddNewEmpProfile";
            this.btnAddNewEmpProfile.Size = new System.Drawing.Size(125, 40);
            this.btnAddNewEmpProfile.TabIndex = 20;
            this.btnAddNewEmpProfile.Text = "+ Add New";
            this.btnAddNewEmpProfile.UseVisualStyleBackColor = false;
            this.btnAddNewEmpProfile.Click += new System.EventHandler(this.btnAddNewEmpProfile_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(706, 101);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(123, 41);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = " Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EmployeeProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvEmpProfile);
            this.Controls.Add(this.btnAddNewEmpProfile);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeProfile";
            this.Size = new System.Drawing.Size(880, 449);
            this.Load += new System.EventHandler(this.EmployeeProfile_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvEmpProfile;
        private System.Windows.Forms.Button btnAddNewEmpProfile;
    }
}
