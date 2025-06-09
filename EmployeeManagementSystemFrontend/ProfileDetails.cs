using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagementSystemFrontend.Helper;

namespace EmployeeManagementSystemFrontend
{
    public partial class ProfileDetails : Form
    {
        public ProfileDetails()
        {
            InitializeComponent();
        }

        private void ProfileDetails_Load(object sender, EventArgs e)
        {
            labl_employee_id.Text = Globals.currentEmployee.Employee_id.ToString();
            labl_name.Text = Globals.currentEmployee.Employee_name;
            labl_gender.Text = Globals.currentEmployee.Gender;
            labl_dob.Text = Globals.currentEmployee.DOB.Date.ToString();
            labl_email.Text = Globals.currentEmployee.Email;
            labl_phone.Text = Globals.currentEmployee.Phone;
            labl_salary.Text = Globals.currentEmployee.Salary.ToString();
            labl_role.Text = Globals.currentEmployee.Role;
            labl_job_starting_date.Text = Globals.currentEmployee.Job_starting_date == DateTime.MinValue ? "" : Globals.currentEmployee.Job_starting_date.ToString() ;


        }
    }
}
