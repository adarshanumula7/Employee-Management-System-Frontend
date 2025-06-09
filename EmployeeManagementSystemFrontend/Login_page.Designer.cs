namespace EmployeeManagementSystemFrontend
{
    partial class Login_page
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.employee_id = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.login_req = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            // 
            // employee_id
            // 
            this.employee_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_id.Location = new System.Drawing.Point(493, 217);
            this.employee_id.Name = "employee_id";
            this.employee_id.Size = new System.Drawing.Size(402, 34);
            this.employee_id.TabIndex = 3;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(493, 285);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(402, 34);
            this.password.TabIndex = 4;
            // 
            // login_req
            // 
            this.login_req.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.login_req.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.login_req.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_req.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_req.Location = new System.Drawing.Point(385, 371);
            this.login_req.Name = "login_req";
            this.login_req.Size = new System.Drawing.Size(221, 41);
            this.login_req.TabIndex = 5;
            this.login_req.Text = "Login";
            this.login_req.UseVisualStyleBackColor = false;
            this.login_req.Click += new System.EventHandler(this.login_req_Click);
            // 
            // Login_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.login_req);
            this.Controls.Add(this.password);
            this.Controls.Add(this.employee_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login_page";
            this.Text = "Login_Page";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox employee_id;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button login_req;
    }
}

