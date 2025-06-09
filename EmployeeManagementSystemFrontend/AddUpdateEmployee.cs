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
using EmployeeManagementSystemFrontend.Helper;
using System.Net.Http;


namespace EmployeeManagementSystemFrontend
{
    public partial class AddUpdateEmployee : Form
    {
        Employee workingemployee = new Employee();
        public AddUpdateEmployee(Employee emp)
        {
            InitializeComponent();
            workingemployee = emp;
        }

        private void AddUpdateEmployee_Load(object sender, EventArgs e)
        {
            if (workingemployee != null)
            {
                // load the data
                // TextBoxes
                tb_employee_id.Text = (workingemployee.Employee_id == 0) ? "": workingemployee.Employee_id.ToString();
                tb_name.Text = workingemployee.Employee_name ?? "";
                tb_email.Text = workingemployee.Email ?? "";
                tb_phone.Text = workingemployee.Phone ?? "";
                tb_salary.Text = (workingemployee.Salary == 0) ? "" : workingemployee.Salary.ToString();
                tb_password.Text = workingemployee.password ?? "";

                // ListBoxes
                if (!string.IsNullOrEmpty(workingemployee.Gender))
                    comboBoxGender.SelectedItem = workingemployee.Gender;

                if (!string.IsNullOrEmpty(workingemployee.Role))
                    comboBoxRole.SelectedItem = workingemployee.Role;

                // DateTimePickers
                dateTimePicker1.Value =
                    (workingemployee.DOB >= dateTimePicker1.MinDate && workingemployee.DOB <= dateTimePicker1.MaxDate)
                    ? workingemployee.DOB : DateTime.Today;

                // For Job_starting_date (nullable)
                if (workingemployee.Job_starting_date.HasValue &&
                    workingemployee.Job_starting_date.Value > dateTimePicker2.MinDate &&
                    workingemployee.Job_starting_date.Value < dateTimePicker2.MaxDate)
                {
                    dateTimePicker2.Value = workingemployee.Job_starting_date.Value;
                    if (dateTimePicker2.ShowCheckBox) dateTimePicker2.Checked = true;
                }
                else
                {
                    dateTimePicker2.Value = DateTime.Today;
                    if (dateTimePicker2.ShowCheckBox) dateTimePicker2.Checked = false;
                }
            
        }
        }

        private async void btn_addemployee_Click(object sender, EventArgs e)
        {
            // Validate required fields first
            if (string.IsNullOrWhiteSpace(tb_employee_id.Text) ||
                string.IsNullOrWhiteSpace(tb_name.Text) ||
                comboBoxGender.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tb_email.Text) ||
                !dateTimePicker1.Checked ||
                string.IsNullOrWhiteSpace(tb_password.Text))
            {
                MessageBox.Show("Please fill in all required fields: ID, Name, Gender, Email, D.O.B, password");
                return;
            }
            Employee emp = new Employee();
            emp.Employee_id = int.Parse(tb_employee_id.Text);
            emp.Employee_name = tb_name.Text ;
            emp.Gender = comboBoxGender.SelectedItem.ToString();
            emp.DOB = dateTimePicker1.Value;
            emp.Email = tb_email.Text;
            emp.password = string.IsNullOrWhiteSpace(tb_password.Text) ? null : tb_password.Text; ;
            emp.Phone = tb_phone.Text ?? null;
            emp.Salary = string.IsNullOrWhiteSpace(tb_salary.Text) ? (decimal?)null : decimal.Parse(tb_salary.Text);
            emp.Role = comboBoxRole.SelectedItem?.ToString() ?? null;
            if (dateTimePicker2.ShowCheckBox && dateTimePicker2.Checked)
            {
                emp.Job_starting_date = dateTimePicker2.Value;
            }
            else emp.Job_starting_date = null;

            try
            {
                string response = await HttpJsonHelper.SendJsonAsync("addemployee", emp, HttpMethod.Post);
                // Check if response contains error
                if (response.Contains("error"))
                {
                    MessageBox.Show($"Error from API: {response}");
                }
                else
                {
                    MessageBox.Show("Employee added successfully!");
                    tb_employee_id.Clear();
                    tb_name.Clear();
                    tb_email.Clear();
                    tb_phone.Clear();
                    tb_salary.Clear();
                    tb_password.Clear();
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker1.Checked = false;
                    dateTimePicker2.Value = DateTime.Today;
                    dateTimePicker2.Checked = false;
                    comboBoxGender.SelectedItem = null;
                    comboBoxRole.SelectedItem = null;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format in ID or Salary field");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}");
            }
        }

        private async void btn_updateemployee_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(tb_employee_id.Text) ||
                string.IsNullOrWhiteSpace(tb_name.Text) ||
                comboBoxGender.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tb_email.Text) ||
                !dateTimePicker1.Checked ||
                string.IsNullOrWhiteSpace(tb_password.Text))
            {
                MessageBox.Show("Please fill in all required fields: ID, Name, Gender, Email, ,D.O.B, password");
                return;
            }

            // Create employee object
            var emp = new Employee
            {
                Employee_id = int.Parse(tb_employee_id.Text),
                Employee_name = tb_name.Text,
                Gender = comboBoxGender.SelectedItem.ToString(),
                DOB = dateTimePicker1.Value,
                Email = tb_email.Text,
                password = string.IsNullOrWhiteSpace(tb_password.Text) ? null : tb_password.Text,
                Phone = string.IsNullOrWhiteSpace(tb_phone.Text) ? null : tb_phone.Text,
                Salary = string.IsNullOrWhiteSpace(tb_salary.Text) ? (decimal?)null : decimal.Parse(tb_salary.Text),
                Role = comboBoxRole.SelectedItem?.ToString() ?? null,
                Job_starting_date = dateTimePicker2.ShowCheckBox && dateTimePicker2.Checked ? (DateTime?)dateTimePicker2.Value : null
            };

            try
            {
                // Send PUT request
                string response = await HttpJsonHelper.SendJsonAsync("updateemployee", emp, HttpMethod.Put);

                if (response.Contains("error"))
                {
                    MessageBox.Show($"Error from API: {response}");
                }
                else
                {
                    MessageBox.Show("Employee updated successfully!");
                    tb_employee_id.Clear();
                    tb_name.Clear();
                    tb_email.Clear();
                    tb_phone.Clear();
                    tb_salary.Clear();
                    tb_password.Clear();
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker1.Checked = false;
                    dateTimePicker2.Value = DateTime.Today;
                    dateTimePicker2.Checked = false;
                    comboBoxGender.SelectedItem = null;
                    comboBoxRole.SelectedItem = null;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format in ID or Salary field");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}");
            }
        }

    }
}
