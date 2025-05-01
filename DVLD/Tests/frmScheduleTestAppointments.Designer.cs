namespace DVLD.Tests
{
    partial class frmScheduleTestAppointments
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
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEditTestAppointmentInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddAppointments = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.ctrlScheduleTest1 = new DVLD.Tests.controls.ctrlScheduleTest();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD.Properties.Resources.eye64;
            this.pbTestImage.Location = new System.Drawing.Point(286, 12);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(179, 75);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 0;
            this.pbTestImage.TabStop = false;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(23, 518);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.Size = new System.Drawing.Size(690, 134);
            this.dgvAppointments.TabIndex = 2;
            // 
            // cmAppointments
            // 
            this.cmAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditTestAppointmentInfo,
            this.tsmTakeTest});
            this.cmAppointments.Name = "cmAppointments";
            this.cmAppointments.Size = new System.Drawing.Size(121, 48);
            // 
            // tsmEditTestAppointmentInfo
            // 
            this.tsmEditTestAppointmentInfo.Name = "tsmEditTestAppointmentInfo";
            this.tsmEditTestAppointmentInfo.Size = new System.Drawing.Size(120, 22);
            this.tsmEditTestAppointmentInfo.Text = "Edit";
            this.tsmEditTestAppointmentInfo.Click += new System.EventHandler(this.tsmEditTestAppointmentInfo_Click);
            // 
            // tsmTakeTest
            // 
            this.tsmTakeTest.Name = "tsmTakeTest";
            this.tsmTakeTest.Size = new System.Drawing.Size(120, 22);
            this.tsmTakeTest.Text = "Take Test";
            this.tsmTakeTest.Click += new System.EventHandler(this.tsmTakeTest_Click);
            // 
            // btnAddAppointments
            // 
            this.btnAddAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointments.Image = global::DVLD.Properties.Resources.addAppointment24;
            this.btnAddAppointments.Location = new System.Drawing.Point(678, 484);
            this.btnAddAppointments.Name = "btnAddAppointments";
            this.btnAddAppointments.Size = new System.Drawing.Size(35, 31);
            this.btnAddAppointments.TabIndex = 3;
            this.btnAddAppointments.UseVisualStyleBackColor = true;
            this.btnAddAppointments.Click += new System.EventHandler(this.btnAddAppointments_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(296, 92);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 18);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Schedule Vision Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Appointments :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 655);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Records :";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(114, 655);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(35, 18);
            this.lblRecords.TabIndex = 7;
            this.lblRecords.Text = "???";
            // 
            // ctrlScheduleTest1
            // 
            this.ctrlScheduleTest1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlScheduleTest1.Location = new System.Drawing.Point(12, 110);
            this.ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            this.ctrlScheduleTest1.Size = new System.Drawing.Size(714, 368);
            this.ctrlScheduleTest1.TabIndex = 8;
            // 
            // frmScheduleTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 678);
            this.Controls.Add(this.ctrlScheduleTest1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddAppointments);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.pbTestImage);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test Appointments";
            this.Load += new System.EventHandler(this.frmScheduleTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnAddAppointments;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecords;
        private controls.ctrlScheduleTest ctrlScheduleTest1;
        private System.Windows.Forms.ContextMenuStrip cmAppointments;
        private System.Windows.Forms.ToolStripMenuItem tsmEditTestAppointmentInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmTakeTest;
    }
}