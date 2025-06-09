using EmployeeManagementSystemFrontend.Helper;
using EmployeeManagementSystemFrontend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystemFrontend
{
    public partial class EmployeesList : Form
    {
        private Dashboard _parentdashboard;
        public EmployeesList(Dashboard parentdashboard)
        {
            InitializeComponent();
            _parentdashboard = parentdashboard;
        }

        private async void EmployeesList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            try
            {
                var employees = await HttpJsonHelper.GetJsonAsync<List<Employee>>("employeeslist");

                dataGridView1.Rows.Clear();

                foreach (var emp in employees)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];

                    row.Cells["employee_id"].Value = emp.Employee_id;
                    row.Cells["employee_name"].Value = emp.Employee_name;
                    row.Cells["email"].Value = emp.Email;
                    row.Cells["dob"].Value = emp.DOB.ToString("yyyy-MM-dd"); // or your preferred format
                    row.Cells["gender"].Value = emp.Gender;

                    row.Tag = emp;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private async void btn_filter_Click(object sender, EventArgs e)
        {
            var queryParams = new List<string>();

            // Add employee_id if provided
            if (!string.IsNullOrWhiteSpace(tb_employeeid.Text))
                queryParams.Add($"employee_id={tb_employeeid.Text.Trim()}");

            // Add name if provided
            if (!string.IsNullOrWhiteSpace(tb_name.Text))
                queryParams.Add($"employee_name={tb_name.Text.Trim()}");

            // Add email if provided
            if (!string.IsNullOrWhiteSpace(tb_email.Text))
                queryParams.Add($"email={tb_email.Text.Trim()}");

            // Add gender if selected
            if (comboBoxGender.SelectedItem != null)
                queryParams.Add($"gender={comboBoxGender.SelectedItem.ToString()}");

            // Add dob if picked (check if not default)
            if (dateTimePicker.ShowCheckBox && dateTimePicker.Checked)
                queryParams.Add($"dob={dateTimePicker.Value:yyyy-MM-dd}");

            // Build the query string
            string route = "employeeslist";
            if (queryParams.Count > 0)
                route += "?" + string.Join("&", queryParams);

            try
            {
                var employees = await HttpJsonHelper.GetJsonAsync<List<Employee>>(route);
                dataGridView1.Rows.Clear();

                foreach (var emp in employees)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];

                    row.Cells["employee_id"].Value = emp.Employee_id;
                    row.Cells["employee_name"].Value = emp.Employee_name;
                    row.Cells["email"].Value = emp.Email;
                    row.Cells["dob"].Value = emp.DOB.ToString("yyyy-MM-dd"); // or your preferred format
                    row.Cells["gender"].Value = emp.Gender;

                    row.Tag = emp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering employees: " + ex.Message);
            }
        }

        private async Task ReloadEmployeesAsync()
        {
            var employees = await HttpJsonHelper.GetJsonAsync<List<Employee>>("employeeslist");
            dataGridView1.DataSource = employees;
        }


        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the click is on a valid row
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var emp = row.Tag as Employee;
                if (emp == null)
                    return;

                // Check for Update button column
                if (dataGridView1.Columns[e.ColumnIndex].Name == "UpdateButton")
                {
                    // Open the AddUpdateEmployee form, passing the employee
                    var updateForm = new AddUpdateEmployee(emp);
                    _parentdashboard.OpenChildFormInPanel(updateForm);
                    
                }
                // Check for Delete button column
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete employee {emp.Employee_name} (ID: {emp.Employee_id})?",
                        "Delete Confirmation",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        HttpJsonHelper.DeleteEmployeeAsync(emp.Employee_id);

                        // Optionally, refresh the DataGridView
                        await ReloadEmployeesAsync();
                    }
                }
            }
        }
    }
}
