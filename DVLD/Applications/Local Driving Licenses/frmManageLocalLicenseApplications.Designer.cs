namespace DVLD.Applications.Local_Driving_Licenses
{
    partial class frmManageLocalLicenseApplications
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
            this.dgvLocalLicensesApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmLocalLicensesApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalLicenseApplication = new System.Windows.Forms.Button();
            this.tsmShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIssueLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesApplications)).BeginInit();
            this.cmLocalLicensesApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalLicensesApplications
            // 
            this.dgvLocalLicensesApplications.AllowUserToAddRows = false;
            this.dgvLocalLicensesApplications.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesApplications.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesApplications.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalLicensesApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesApplications.ContextMenuStrip = this.cmLocalLicensesApplications;
            this.dgvLocalLicensesApplications.Location = new System.Drawing.Point(12, 217);
            this.dgvLocalLicensesApplications.Name = "dgvLocalLicensesApplications";
            this.dgvLocalLicensesApplications.ReadOnly = true;
            this.dgvLocalLicensesApplications.Size = new System.Drawing.Size(922, 234);
            this.dgvLocalLicensesApplications.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "#Records :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(90, 192);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 22);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(217, 194);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(121, 20);
            this.txtFilterValue.TabIndex = 5;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(99, 454);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(35, 18);
            this.lblRecordsCount.TabIndex = 6;
            this.lblRecordsCount.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filter By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(287, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Manage Local Licenses Applications";
            // 
            // cmLocalLicensesApplications
            // 
            this.cmLocalLicensesApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowApplicationDetails,
            this.toolStripMenuItem1,
            this.tsmEditApplication,
            this.tsmDeleteApplication,
            this.toolStripMenuItem2,
            this.tsmCancelApplication,
            this.toolStripMenuItem3,
            this.tsmScheduleTest,
            this.toolStripMenuItem4,
            this.tsmIssueLicenseFirstTime,
            this.toolStripMenuItem5,
            this.tsmShowLicense,
            this.toolStripMenuItem6,
            this.tsmLicenseHistory});
            this.cmLocalLicensesApplications.Name = "cmLocalLicensesApplications";
            this.cmLocalLicensesApplications.Size = new System.Drawing.Size(246, 238);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(242, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(242, 6);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.applications;
            this.pictureBox1.Location = new System.Drawing.Point(384, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewLocalLicenseApplication
            // 
            this.btnAddNewLocalLicenseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalLicenseApplication.Image = global::DVLD.Properties.Resources.newApplication24;
            this.btnAddNewLocalLicenseApplication.Location = new System.Drawing.Point(895, 184);
            this.btnAddNewLocalLicenseApplication.Name = "btnAddNewLocalLicenseApplication";
            this.btnAddNewLocalLicenseApplication.Size = new System.Drawing.Size(39, 30);
            this.btnAddNewLocalLicenseApplication.TabIndex = 1;
            this.btnAddNewLocalLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalLicenseApplication_Click);
            // 
            // tsmShowApplicationDetails
            // 
            this.tsmShowApplicationDetails.Image = global::DVLD.Properties.Resources.showDocDetails;
            this.tsmShowApplicationDetails.Name = "tsmShowApplicationDetails";
            this.tsmShowApplicationDetails.Size = new System.Drawing.Size(245, 22);
            this.tsmShowApplicationDetails.Text = "Show Application Details";
            this.tsmShowApplicationDetails.Click += new System.EventHandler(this.tsmShowApplicationDetails_Click);
            // 
            // tsmEditApplication
            // 
            this.tsmEditApplication.Image = global::DVLD.Properties.Resources.editDoc;
            this.tsmEditApplication.Name = "tsmEditApplication";
            this.tsmEditApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmEditApplication.Text = "Edit Application";
            this.tsmEditApplication.Click += new System.EventHandler(this.tsmEditApplication_Click);
            // 
            // tsmDeleteApplication
            // 
            this.tsmDeleteApplication.Image = global::DVLD.Properties.Resources.deleteDoc24;
            this.tsmDeleteApplication.Name = "tsmDeleteApplication";
            this.tsmDeleteApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmDeleteApplication.Text = "Delete Application";
            this.tsmDeleteApplication.Click += new System.EventHandler(this.tsmDeleteApplication_Click);
            // 
            // tsmCancelApplication
            // 
            this.tsmCancelApplication.Image = global::DVLD.Properties.Resources.cancel24;
            this.tsmCancelApplication.Name = "tsmCancelApplication";
            this.tsmCancelApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmCancelApplication.Text = "Cancel Application";
            this.tsmCancelApplication.Click += new System.EventHandler(this.tsmCancelApplication_Click);
            // 
            // tsmScheduleTest
            // 
            this.tsmScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVisionTest,
            this.tsmWrittenTest,
            this.tsmStreetTest});
            this.tsmScheduleTest.Image = global::DVLD.Properties.Resources.schedule24;
            this.tsmScheduleTest.Name = "tsmScheduleTest";
            this.tsmScheduleTest.Size = new System.Drawing.Size(245, 22);
            this.tsmScheduleTest.Text = "Schedule Test";
            // 
            // tsmVisionTest
            // 
            this.tsmVisionTest.Image = global::DVLD.Properties.Resources.eye24;
            this.tsmVisionTest.Name = "tsmVisionTest";
            this.tsmVisionTest.Size = new System.Drawing.Size(180, 22);
            this.tsmVisionTest.Text = "Vision Test";
            this.tsmVisionTest.Click += new System.EventHandler(this.tsmVisionTest_Click);
            // 
            // tsmWrittenTest
            // 
            this.tsmWrittenTest.Image = global::DVLD.Properties.Resources.test24;
            this.tsmWrittenTest.Name = "tsmWrittenTest";
            this.tsmWrittenTest.Size = new System.Drawing.Size(180, 22);
            this.tsmWrittenTest.Text = "Written Test";
            this.tsmWrittenTest.Click += new System.EventHandler(this.tsmWrittenTest_Click);
            // 
            // tsmStreetTest
            // 
            this.tsmStreetTest.Image = global::DVLD.Properties.Resources.car24;
            this.tsmStreetTest.Name = "tsmStreetTest";
            this.tsmStreetTest.Size = new System.Drawing.Size(180, 22);
            this.tsmStreetTest.Text = "Street Test";
            this.tsmStreetTest.Click += new System.EventHandler(this.tsmStreetTest_Click);
            // 
            // tsmIssueLicenseFirstTime
            // 
            this.tsmIssueLicenseFirstTime.Image = global::DVLD.Properties.Resources.license24;
            this.tsmIssueLicenseFirstTime.Name = "tsmIssueLicenseFirstTime";
            this.tsmIssueLicenseFirstTime.Size = new System.Drawing.Size(245, 22);
            this.tsmIssueLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.tsmIssueLicenseFirstTime.Click += new System.EventHandler(this.tsmIssueLicenseFirstTime_Click);
            // 
            // tsmShowLicense
            // 
            this.tsmShowLicense.Image = global::DVLD.Properties.Resources.license24;
            this.tsmShowLicense.Name = "tsmShowLicense";
            this.tsmShowLicense.Size = new System.Drawing.Size(245, 22);
            this.tsmShowLicense.Text = "Show License";
            this.tsmShowLicense.Click += new System.EventHandler(this.tsmShowLicense_Click);
            // 
            // tsmLicenseHistory
            // 
            this.tsmLicenseHistory.Image = global::DVLD.Properties.Resources.history24;
            this.tsmLicenseHistory.Name = "tsmLicenseHistory";
            this.tsmLicenseHistory.Size = new System.Drawing.Size(245, 22);
            this.tsmLicenseHistory.Text = "Show Persons License History";
            this.tsmLicenseHistory.Click += new System.EventHandler(this.tsmLicenseHistory_Click);
            // 
            // frmManageLocalLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 481);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewLocalLicenseApplication);
            this.Controls.Add(this.dgvLocalLicensesApplications);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalLicenseApplications";
            this.Text = "Manage Local Licenses Applications";
            this.Load += new System.EventHandler(this.frmManageLocalLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesApplications)).EndInit();
            this.cmLocalLicensesApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalLicensesApplications;
        private System.Windows.Forms.Button btnAddNewLocalLicenseApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmLocalLicensesApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem tsmVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmStreetTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmLicenseHistory;
    }
}