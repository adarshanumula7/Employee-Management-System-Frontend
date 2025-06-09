namespace EmployeeManagementSystemFrontend
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logout_req = new System.Windows.Forms.Button();
            this.labl_sessiontime = new System.Windows.Forms.Label();
            this.labl_name = new System.Windows.Forms.Label();
            this.childformpanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Employees = new System.Windows.Forms.Button();
            this.btn_Addemployee = new System.Windows.Forms.Button();
            this.btn_profile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logout_req);
            this.panel1.Controls.Add(this.labl_sessiontime);
            this.panel1.Controls.Add(this.labl_name);
            this.panel1.Location = new System.Drawing.Point(173, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 58);
            this.panel1.TabIndex = 0;
            // 
            // logout_req
            // 
            this.logout_req.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.logout_req.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logout_req.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logout_req.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_req.Location = new System.Drawing.Point(890, 16);
            this.logout_req.Name = "logout_req";
            this.logout_req.Size = new System.Drawing.Size(107, 32);
            this.logout_req.TabIndex = 6;
            this.logout_req.Text = "logout";
            this.logout_req.UseVisualStyleBackColor = false;
            this.logout_req.Click += new System.EventHandler(this.logout_req_Click);
            // 
            // labl_sessiontime
            // 
            this.labl_sessiontime.AutoSize = true;
            this.labl_sessiontime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_sessiontime.Location = new System.Drawing.Point(338, 20);
            this.labl_sessiontime.Name = "labl_sessiontime";
            this.labl_sessiontime.Size = new System.Drawing.Size(157, 22);
            this.labl_sessiontime.TabIndex = 1;
            this.labl_sessiontime.Text = "{Session Time :}";
            // 
            // labl_name
            // 
            this.labl_name.AutoSize = true;
            this.labl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_name.Location = new System.Drawing.Point(19, 20);
            this.labl_name.Name = "labl_name";
            this.labl_name.Size = new System.Drawing.Size(72, 22);
            this.labl_name.TabIndex = 0;
            this.labl_name.Text = "{name}";
            // 
            // childformpanel
            // 
            this.childformpanel.Location = new System.Drawing.Point(173, 58);
            this.childformpanel.Name = "childformpanel";
            this.childformpanel.Size = new System.Drawing.Size(1008, 595);
            this.childformpanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.Controls.Add(this.btn_Employees);
            this.panel3.Controls.Add(this.btn_Addemployee);
            this.panel3.Controls.Add(this.btn_profile);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 653);
            this.panel3.TabIndex = 1;
            // 
            // btn_Employees
            // 
            this.btn_Employees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Employees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Employees.Location = new System.Drawing.Point(0, 340);
            this.btn_Employees.Name = "btn_Employees";
            this.btn_Employees.Size = new System.Drawing.Size(167, 57);
            this.btn_Employees.TabIndex = 2;
            this.btn_Employees.Text = "Employees List";
            this.btn_Employees.UseVisualStyleBackColor = true;
            this.btn_Employees.Click += new System.EventHandler(this.btn_Employees_Click);
            // 
            // btn_Addemployee
            // 
            this.btn_Addemployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Addemployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Addemployee.Location = new System.Drawing.Point(0, 421);
            this.btn_Addemployee.Name = "btn_Addemployee";
            this.btn_Addemployee.Size = new System.Drawing.Size(167, 57);
            this.btn_Addemployee.TabIndex = 1;
            this.btn_Addemployee.Text = "Add New Employee";
            this.btn_Addemployee.UseVisualStyleBackColor = true;
            this.btn_Addemployee.Click += new System.EventHandler(this.btn_Addemployee_Click);
            // 
            // btn_profile
            // 
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.Location = new System.Drawing.Point(0, 260);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(167, 57);
            this.btn_profile.TabIndex = 0;
            this.btn_profile.Text = "Profile";
            this.btn_profile.UseVisualStyleBackColor = true;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.childformpanel);
            this.Controls.Add(this.panel3);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel childformpanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Employees;
        private System.Windows.Forms.Button btn_Addemployee;
        private System.Windows.Forms.Button btn_profile;
        private System.Windows.Forms.Label labl_sessiontime;
        private System.Windows.Forms.Label labl_name;
        private System.Windows.Forms.Button logout_req;
    }
}