namespace DVLD.Users
{
    partial class ctrlUserCard
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
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonCardInfo2 = new DVLD.People.Controls.ctrlPersonCardInfo();
            this.gbLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.Controls.Add(this.lblIsActive);
            this.gbLoginInfo.Controls.Add(this.lblUsername);
            this.gbLoginInfo.Controls.Add(this.lblUserID);
            this.gbLoginInfo.Controls.Add(this.label3);
            this.gbLoginInfo.Controls.Add(this.label2);
            this.gbLoginInfo.Controls.Add(this.label1);
            this.gbLoginInfo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLoginInfo.Location = new System.Drawing.Point(19, 325);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Size = new System.Drawing.Size(711, 100);
            this.gbLoginInfo.TabIndex = 1;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "Login Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.Location = new System.Drawing.Point(594, 45);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(17, 18);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "?";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(362, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(17, 18);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "?";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(117, 45);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(17, 18);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(513, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Is Active :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // ctrlPersonCardInfo2
            // 
            this.ctrlPersonCardInfo2.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonCardInfo2.Name = "ctrlPersonCardInfo2";
            this.ctrlPersonCardInfo2.Size = new System.Drawing.Size(730, 312);
            this.ctrlPersonCardInfo2.TabIndex = 2;
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonCardInfo2);
            this.Controls.Add(this.gbLoginInfo);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(750, 441);
            this.gbLoginInfo.ResumeLayout(false);
            this.gbLoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlPersonCardInfo ctrlPersonCardInfo1;
        private System.Windows.Forms.GroupBox gbLoginInfo;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private People.Controls.ctrlPersonCardInfo ctrlPersonCardInfo2;
    }
}
