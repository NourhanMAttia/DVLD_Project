namespace DVLD.Tests.controls
{
    partial class frmAddAppointment
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
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.dtpTestAppointment = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFees = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTrials = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLocalID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRetakeAppID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRetakeAppFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.gbTestInfo.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD.Properties.Resources.eye64;
            this.pbTestImage.Location = new System.Drawing.Point(134, 19);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(121, 79);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 0;
            this.pbTestImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set Test";
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.dtpTestAppointment);
            this.gbTestInfo.Controls.Add(this.btnSave);
            this.gbTestInfo.Controls.Add(this.lblFees);
            this.gbTestInfo.Controls.Add(this.label12);
            this.gbTestInfo.Controls.Add(this.label10);
            this.gbTestInfo.Controls.Add(this.lblTrials);
            this.gbTestInfo.Controls.Add(this.label8);
            this.gbTestInfo.Controls.Add(this.lblName);
            this.gbTestInfo.Controls.Add(this.label6);
            this.gbTestInfo.Controls.Add(this.lblLicenseClass);
            this.gbTestInfo.Controls.Add(this.label4);
            this.gbTestInfo.Controls.Add(this.lblLocalID);
            this.gbTestInfo.Controls.Add(this.label2);
            this.gbTestInfo.Controls.Add(this.gbRetakeTest);
            this.gbTestInfo.Controls.Add(this.pbTestImage);
            this.gbTestInfo.Controls.Add(this.label1);
            this.gbTestInfo.Location = new System.Drawing.Point(12, 12);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(406, 598);
            this.gbTestInfo.TabIndex = 2;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "Vision Test";
            // 
            // dtpTestAppointment
            // 
            this.dtpTestAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTestAppointment.Location = new System.Drawing.Point(134, 311);
            this.dtpTestAppointment.Name = "dtpTestAppointment";
            this.dtpTestAppointment.Size = new System.Drawing.Size(125, 20);
            this.dtpTestAppointment.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(345, 558);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 34);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(131, 350);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(35, 18);
            this.lblFees.TabIndex = 14;
            this.lblFees.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(76, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "Fees:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(79, 313);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Date:";
            // 
            // lblTrials
            // 
            this.lblTrials.AutoSize = true;
            this.lblTrials.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrials.Location = new System.Drawing.Point(131, 276);
            this.lblTrials.Name = "lblTrials";
            this.lblTrials.Size = new System.Drawing.Size(35, 18);
            this.lblTrials.TabIndex = 10;
            this.lblTrials.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(72, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Trials:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(130, 239);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 18);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Name:";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Location = new System.Drawing.Point(130, 202);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(35, 18);
            this.lblLicenseClass.TabIndex = 6;
            this.lblLicenseClass.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "License Class:";
            // 
            // lblLocalID
            // 
            this.lblLocalID.AutoSize = true;
            this.lblLocalID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalID.Location = new System.Drawing.Point(130, 165);
            this.lblLocalID.Name = "lblLocalID";
            this.lblLocalID.Size = new System.Drawing.Size(35, 18);
            this.lblLocalID.TabIndex = 4;
            this.lblLocalID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "L.D.L App ID:";
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblTotalFees);
            this.gbRetakeTest.Controls.Add(this.label11);
            this.gbRetakeTest.Controls.Add(this.lblRetakeAppID);
            this.gbRetakeTest.Controls.Add(this.label7);
            this.gbRetakeTest.Controls.Add(this.lblRetakeAppFees);
            this.gbRetakeTest.Controls.Add(this.label3);
            this.gbRetakeTest.Enabled = false;
            this.gbRetakeTest.Location = new System.Drawing.Point(6, 400);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(394, 142);
            this.gbRetakeTest.TabIndex = 2;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "Retake Test";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(290, 36);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(35, 18);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(198, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total Fees:";
            // 
            // lblRetakeAppID
            // 
            this.lblRetakeAppID.AutoSize = true;
            this.lblRetakeAppID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeAppID.Location = new System.Drawing.Point(125, 80);
            this.lblRetakeAppID.Name = "lblRetakeAppID";
            this.lblRetakeAppID.Size = new System.Drawing.Size(35, 18);
            this.lblRetakeAppID.TabIndex = 17;
            this.lblRetakeAppID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "R. App. ID:";
            // 
            // lblRetakeAppFees
            // 
            this.lblRetakeAppFees.AutoSize = true;
            this.lblRetakeAppFees.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeAppFees.Location = new System.Drawing.Point(125, 36);
            this.lblRetakeAppFees.Name = "lblRetakeAppFees";
            this.lblRetakeAppFees.Size = new System.Drawing.Size(35, 18);
            this.lblRetakeAppFees.TabIndex = 15;
            this.lblRetakeAppFees.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "R. App. Fees:";
            // 
            // frmAddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 622);
            this.Controls.Add(this.gbTestInfo);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Test";
            this.Load += new System.EventHandler(this.frmAddAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTrials;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocalID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRetakeAppID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRetakeAppFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpTestAppointment;
    }
}