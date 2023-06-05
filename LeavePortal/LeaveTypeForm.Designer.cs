
namespace LeavePortal
{
    partial class LeaveTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveTypeForm));
            this.btnAddNewLeaveType = new System.Windows.Forms.Button();
            this.dgLeaveTypes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeaveTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewLeaveType
            // 
            this.btnAddNewLeaveType.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewLeaveType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLeaveType.ForeColor = System.Drawing.Color.White;
            this.btnAddNewLeaveType.Location = new System.Drawing.Point(55, 77);
            this.btnAddNewLeaveType.Name = "btnAddNewLeaveType";
            this.btnAddNewLeaveType.Size = new System.Drawing.Size(157, 52);
            this.btnAddNewLeaveType.TabIndex = 0;
            this.btnAddNewLeaveType.Text = "+ Add New";
            this.btnAddNewLeaveType.UseVisualStyleBackColor = false;
            this.btnAddNewLeaveType.Click += new System.EventHandler(this.btnAddNewLeaveType_Click);
            // 
            // dgLeaveTypes
            // 
            this.dgLeaveTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLeaveTypes.Location = new System.Drawing.Point(55, 135);
            this.dgLeaveTypes.Name = "dgLeaveTypes";
            this.dgLeaveTypes.RowHeadersWidth = 51;
            this.dgLeaveTypes.RowTemplate.Height = 24;
            this.dgLeaveTypes.Size = new System.Drawing.Size(922, 307);
            this.dgLeaveTypes.TabIndex = 1;
            this.dgLeaveTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLeaveTypes_CellContentClick);
            this.dgLeaveTypes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLeaveTypes_CellMouseClick);
            this.dgLeaveTypes.Click += new System.EventHandler(this.dgLeaveTypes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Leave Type";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(651, 92);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(183, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(861, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(116, 37);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = " Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // LeaveTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgLeaveTypes);
            this.Controls.Add(this.btnAddNewLeaveType);
            this.Name = "LeaveTypeForm";
            this.Size = new System.Drawing.Size(1033, 466);
            this.Load += new System.EventHandler(this.LeaveTypeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLeaveTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewLeaveType;
        private System.Windows.Forms.DataGridView dgLeaveTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
