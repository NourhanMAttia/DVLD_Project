namespace DVLD.People
{
    partial class frmAddUpdatePerson
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llblRemoveImage = new System.Windows.Forms.LinkLabel();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llblSetImage = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(285, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Person ID: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llblRemoveImage);
            this.groupBox1.Controls.Add(this.cbCountries);
            this.groupBox1.Controls.Add(this.rbMale);
            this.groupBox1.Controls.Add(this.rbFemale);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.llblSetImage);
            this.groupBox1.Controls.Add(this.pbPersonImage);
            this.groupBox1.Controls.Add(this.dtpDateOfBirth);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtNationalNo);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtThirdName);
            this.groupBox1.Controls.Add(this.txtSecondName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(27, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 335);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // llblRemoveImage
            // 
            this.llblRemoveImage.AutoSize = true;
            this.llblRemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblRemoveImage.Location = new System.Drawing.Point(608, 233);
            this.llblRemoveImage.Name = "llblRemoveImage";
            this.llblRemoveImage.Size = new System.Drawing.Size(79, 13);
            this.llblRemoveImage.TabIndex = 29;
            this.llblRemoveImage.TabStop = true;
            this.llblRemoveImage.Text = "Remove Image";
            this.llblRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRemoveImage_LinkClicked);
            // 
            // cbCountries
            // 
            this.cbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(430, 174);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(141, 21);
            this.cbCountries.TabIndex = 28;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(227, 132);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 27;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(134, 132);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 26;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(186, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "First";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(326, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Second";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(483, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Third";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(636, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "Last";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(486, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(396, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llblSetImage
            // 
            this.llblSetImage.AutoSize = true;
            this.llblSetImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblSetImage.Location = new System.Drawing.Point(619, 217);
            this.llblSetImage.Name = "llblSetImage";
            this.llblSetImage.Size = new System.Drawing.Size(55, 13);
            this.llblSetImage.TabIndex = 22;
            this.llblSetImage.TabStop = true;
            this.llblSetImage.Text = "Set Image";
            this.llblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSetImage_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.male;
            this.pbPersonImage.Location = new System.Drawing.Point(578, 86);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(141, 108);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 21;
            this.pbPersonImage.TabStop = false;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(430, 88);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(141, 20);
            this.dtpDateOfBirth.TabIndex = 20;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(430, 131);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(141, 20);
            this.txtPhone.TabIndex = 18;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this._ValidateEmptyTextBox);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(134, 217);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(427, 79);
            this.txtAddress.TabIndex = 17;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this._ValidateEmptyTextBox);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(134, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(141, 20);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Location = new System.Drawing.Point(134, 86);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(141, 20);
            this.txtNationalNo.TabIndex = 14;
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(578, 45);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(141, 20);
            this.txtLastName.TabIndex = 13;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this._ValidateEmptyTextBox);
            // 
            // txtThirdName
            // 
            this.txtThirdName.Location = new System.Drawing.Point(430, 45);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(141, 20);
            this.txtThirdName.TabIndex = 12;
            // 
            // txtSecondName
            // 
            this.txtSecondName.Location = new System.Drawing.Point(282, 45);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(141, 20);
            this.txtSecondName.TabIndex = 11;
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this._ValidateEmptyTextBox);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(134, 45);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(141, 20);
            this.txtFirstName.TabIndex = 10;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this._ValidateEmptyTextBox);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(346, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 18);
            this.label11.TabIndex = 9;
            this.label11.Text = "Country: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(356, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "Phone: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(309, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Date Of Birth: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Email: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Gender: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "National No: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name: ";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(134, 83);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(31, 17);
            this.lblPersonID.TabIndex = 3;
            this.lblPersonID.Text = "N/A";
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Person Info";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblSetImage;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.LinkLabel llblRemoveImage;
    }
}