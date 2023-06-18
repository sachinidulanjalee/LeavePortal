
namespace LeavePortal
{
    partial class CancelLeave
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelLeave));
            this.dgCancelLeave = new System.Windows.Forms.DataGridView();
            this.LeaveChitNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeaveCodeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfHoursDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeaveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.btnMaxzimis = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.pnlMenubar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgCancelLeave)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxzimis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.pnlMenubar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCancelLeave
            // 
            this.dgCancelLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCancelLeave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeaveChitNumber,
            this.RequestDate,
            this.LeaveCodeText,
            this.StartDate,
            this.EndDate,
            this.NoOfHoursDays,
            this.LeaveStatus,
            this.btnCancel});
            this.dgCancelLeave.Location = new System.Drawing.Point(46, 197);
            this.dgCancelLeave.Name = "dgCancelLeave";
            this.dgCancelLeave.RowHeadersWidth = 51;
            this.dgCancelLeave.RowTemplate.Height = 24;
            this.dgCancelLeave.Size = new System.Drawing.Size(1059, 245);
            this.dgCancelLeave.TabIndex = 11;
            this.dgCancelLeave.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCancelLeave_CellClick);
            // 
            // LeaveChitNumber
            // 
            this.LeaveChitNumber.DataPropertyName = "LeaveChitNumber";
            this.LeaveChitNumber.HeaderText = "LeaveChitNo";
            this.LeaveChitNumber.MinimumWidth = 6;
            this.LeaveChitNumber.Name = "LeaveChitNumber";
            this.LeaveChitNumber.Width = 125;
            // 
            // RequestDate
            // 
            this.RequestDate.DataPropertyName = "RequestDate";
            this.RequestDate.HeaderText = "RequestDate";
            this.RequestDate.MinimumWidth = 6;
            this.RequestDate.Name = "RequestDate";
            this.RequestDate.Width = 125;
            // 
            // LeaveCodeText
            // 
            this.LeaveCodeText.DataPropertyName = "LeaveCodeText";
            this.LeaveCodeText.HeaderText = "LeaveCode";
            this.LeaveCodeText.MinimumWidth = 6;
            this.LeaveCodeText.Name = "LeaveCodeText";
            this.LeaveCodeText.Width = 125;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.MinimumWidth = 6;
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 125;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.MinimumWidth = 6;
            this.EndDate.Name = "EndDate";
            this.EndDate.Width = 125;
            // 
            // NoOfHoursDays
            // 
            this.NoOfHoursDays.DataPropertyName = "NoOfHoursDays";
            this.NoOfHoursDays.HeaderText = "NoOfHoursDays";
            this.NoOfHoursDays.MinimumWidth = 6;
            this.NoOfHoursDays.Name = "NoOfHoursDays";
            this.NoOfHoursDays.Width = 125;
            // 
            // LeaveStatus
            // 
            this.LeaveStatus.DataPropertyName = "LeaveStatusText";
            this.LeaveStatus.HeaderText = "LeaveStatus";
            this.LeaveStatus.MinimumWidth = 6;
            this.LeaveStatus.Name = "LeaveStatus";
            this.LeaveStatus.Width = 125;
            // 
            // btnCancel
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnCancel.HeaderText = "Cancel";
            this.btnCancel.MinimumWidth = 6;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseColumnTextForButtonValue = true;
            this.btnCancel.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtYear.Location = new System.Drawing.Point(79, 127);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(200, 22);
            this.txtYear.TabIndex = 9;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(775, 11);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(85, 19);
            this.lblDateTime.TabIndex = 6;
            this.lblDateTime.Text = "DateTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Leave Portal";
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(993, 12);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(59, 19);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "Home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            this.lblHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblHome_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.lblDateTime);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblHome);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 37);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(1072, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(33, 34);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 0;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMaxzimis
            // 
            this.btnMaxzimis.Image = ((System.Drawing.Image)(resources.GetObject("btnMaxzimis.Image")));
            this.btnMaxzimis.Location = new System.Drawing.Point(1058, 9);
            this.btnMaxzimis.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaxzimis.Name = "btnMaxzimis";
            this.btnMaxzimis.Size = new System.Drawing.Size(31, 27);
            this.btnMaxzimis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaxzimis.TabIndex = 6;
            this.btnMaxzimis.TabStop = false;
            this.btnMaxzimis.Click += new System.EventHandler(this.btnMaxzimis_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1089, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 28);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1026, 9);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(31, 27);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlMenubar
            // 
            this.pnlMenubar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMenubar.Controls.Add(this.btnMaxzimis);
            this.pnlMenubar.Controls.Add(this.btnClose);
            this.pnlMenubar.Controls.Add(this.btnMinimize);
            this.pnlMenubar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenubar.Location = new System.Drawing.Point(0, 0);
            this.pnlMenubar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMenubar.Name = "pnlMenubar";
            this.pnlMenubar.Size = new System.Drawing.Size(1131, 43);
            this.pnlMenubar.TabIndex = 7;
            // 
            // CancelLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1131, 587);
            this.Controls.Add(this.dgCancelLeave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMenubar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CancelLeave";
            this.Text = "CancelLeave";
            this.Load += new System.EventHandler(this.CancelLeave_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CancelLeave_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CancelLeave_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgCancelLeave)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxzimis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.pnlMenubar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCancelLeave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtYear;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.PictureBox btnMaxzimis;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.Panel pnlMenubar;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveChitNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveCodeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfHoursDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveStatus;
        private System.Windows.Forms.DataGridViewButtonColumn btnCancel;
    }
}