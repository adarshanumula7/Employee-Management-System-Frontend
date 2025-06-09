using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemFrontend.Models
{
    public class Employee
    {
        public int Employee_id { get; set; } = 0;
        public string Employee_name { get; set; } = "";
        public string password { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime DOB { get; set; } = default(DateTime);
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public decimal? Salary { get; set; } = 0;
        public string Role { get; set; } = "";
        public DateTime? Job_starting_date { get; set; } = default(DateTime);
        public int? Isactive { get; set; } = 0;
    }
}
