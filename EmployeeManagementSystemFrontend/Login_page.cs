using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using EmployeeManagementSystemFrontend.Models;
using EmployeeManagementSystemFrontend.Helper;

namespace EmployeeManagementSystemFrontend
{
    public partial class Login_page : Form
    {
        public Login_page()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employee_id.Clear();
            password.Clear();
        }

        private async void login_req_Click(object sender, EventArgs e)
        {
            int employeeId = int.Parse(employee_id.Text);
            string passwordtext = password.Text;

            bool success = await HttpJsonHelper.LoginAsync(employeeId, passwordtext);

            if (success)
            {
                MessageBox.Show("Login successful!");
                employee_id.Clear();
                password.Clear();
                Dashboard dashboard = new Dashboard(this);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
                employee_id.Clear();
                password.Clear();
            }

        }
    }
}
