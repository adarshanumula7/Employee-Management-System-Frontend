using EmployeeManagementSystemFrontend.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagementSystemFrontend.Models;

namespace EmployeeManagementSystemFrontend
{
    public partial class Dashboard : Form
    {

        private Timer sessionTimer;
        private TimeSpan sessionDuration;
        private TimeSpan timeLeft;
        private Login_page loginPage;

        public Dashboard(Login_page loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            sessionDuration = TimeSpan.FromMinutes(60);
            timeLeft = sessionDuration;

            // Initialize and start the timer
            sessionTimer = new Timer();
            sessionTimer.Interval = 1000; // 1 second
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();

            // Update label initially
            labl_sessiontime.Text = $"Remaining Session Time : {timeLeft:mm\\:ss}";

            try
            {
                var emp = await HttpJsonHelper.GetCurrentEmployeeAsync(LoggedInEmployee.employee_id);

                if (emp == null)
                {
                    MessageBox.Show("Employee not found. Please log in again.");
                    this.Close();
                    return;
                }

                Globals.currentEmployee.Employee_id = emp.Employee_id;
                Globals.currentEmployee.Employee_name = emp.Employee_name ?? "";
                Globals.currentEmployee.Gender = emp.Gender ?? "";
                Globals.currentEmployee.DOB = emp.DOB;
                Globals.currentEmployee.Email = emp.Email ?? "";
                Globals.currentEmployee.Phone = emp.Phone ?? "";
                Globals.currentEmployee.Salary = emp.Salary;
                Globals.currentEmployee.Role = emp.Role;
                Globals.currentEmployee.Job_starting_date = emp.Job_starting_date;
                Globals.currentEmployee.Isactive = emp.Isactive;

                labl_name.Text = Globals.currentEmployee.Employee_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message);
                this.Close(); // Or handle as appropriate
            }
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            labl_sessiontime.Text = $"Remaining Session Time: {timeLeft:mm\\:ss}";

            if (timeLeft <= TimeSpan.Zero)
            {
                sessionTimer.Stop();
                MessageBox.Show("Session expired. Please log in again.");
                Globals.currentEmployee = new Employee();
                loginPage.Show();
                this.Close();
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileDetails();
            OpenChildFormInPanel(profileForm);
        }

        private void btn_Employees_Click(object sender, EventArgs e)
        {
            string role = Globals.currentEmployee.Role;
            if (role == "Admin" || role == "HR")
            {
                var employeeslist = new EmployeesList(this);
                OpenChildFormInPanel(employeeslist);

            } else
            {
                MessageBox.Show("Only Admin or HR can have access", "Warning!!!");
            }
        }

        private void btn_Addemployee_Click(object sender, EventArgs e)
        {
            string role = Globals.currentEmployee.Role;
            if (role == "Admin" || role == "HR")
            {
                Employee emp = new Employee();
                var addemployee = new AddUpdateEmployee(emp);
                OpenChildFormInPanel(addemployee);
            }
            else
            {
                MessageBox.Show("Only Admin or HR can have access", "Warning!!!");
            }
        }

        public void OpenChildFormInPanel(Form childForm)
        {
            // Remove any existing controls from the panel
            childformpanel.Controls.Clear();

            // Set up the child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add the child form to the panel and show it
            childformpanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void logout_req_Click(object sender, EventArgs e)
        {
            Globals.currentEmployee = new Employee();
            loginPage.Show();
            this.Close();
        }
    }
}
