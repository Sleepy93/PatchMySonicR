namespace PatchMySonicR
{
    partial class Form1
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
            this.cb_drive = new System.Windows.Forms.ComboBox();
            this.lb_drivetext = new System.Windows.Forms.Label();
            this.cb_res = new System.Windows.Forms.ComboBox();
            this.btn_exepatch = new System.Windows.Forms.Button();
            this.btn_respatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_drive
            // 
            this.cb_drive.FormattingEnabled = true;
            this.cb_drive.Location = new System.Drawing.Point(118, 5);
            this.cb_drive.MaxLength = 1;
            this.cb_drive.Name = "cb_drive";
            this.cb_drive.Size = new System.Drawing.Size(155, 21);
            this.cb_drive.TabIndex = 0;
            // 
            // lb_drivetext
            // 
            this.lb_drivetext.AutoSize = true;
            this.lb_drivetext.Location = new System.Drawing.Point(7, 8);
            this.lb_drivetext.Name = "lb_drivetext";
            this.lb_drivetext.Size = new System.Drawing.Size(105, 13);
            this.lb_drivetext.TabIndex = 1;
            this.lb_drivetext.Text = "Select Drive\'s Letter:";
            // 
            // cb_res
            // 
            this.cb_res.FormattingEnabled = true;
            this.cb_res.Location = new System.Drawing.Point(117, 32);
            this.cb_res.Name = "cb_res";
            this.cb_res.Size = new System.Drawing.Size(155, 21);
            this.cb_res.TabIndex = 2;
            // 
            // btn_exepatch
            // 
            this.btn_exepatch.Location = new System.Drawing.Point(197, 60);
            this.btn_exepatch.Name = "btn_exepatch";
            this.btn_exepatch.Size = new System.Drawing.Size(75, 23);
            this.btn_exepatch.TabIndex = 3;
            this.btn_exepatch.Text = "Patch It!";
            this.btn_exepatch.UseVisualStyleBackColor = true;
            this.btn_exepatch.Click += new System.EventHandler(this.btn_exepatch_Click);
            // 
            // btn_respatch
            // 
            this.btn_respatch.Location = new System.Drawing.Point(117, 59);
            this.btn_respatch.Name = "btn_respatch";
            this.btn_respatch.Size = new System.Drawing.Size(75, 23);
            this.btn_respatch.TabIndex = 3;
            this.btn_respatch.Text = "Patch Res!";
            this.btn_respatch.UseVisualStyleBackColor = true;
            this.btn_respatch.Click += new System.EventHandler(this.btn_respatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Custom Resolution:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_respatch);
            this.Controls.Add(this.btn_exepatch);
            this.Controls.Add(this.cb_res);
            this.Controls.Add(this.lb_drivetext);
            this.Controls.Add(this.cb_drive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patch my SonicR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_drive;
        private System.Windows.Forms.Label lb_drivetext;
        private System.Windows.Forms.ComboBox cb_res;
        private System.Windows.Forms.Button btn_exepatch;
        private System.Windows.Forms.Button btn_respatch;
        private System.Windows.Forms.Label label1;
    }
}

