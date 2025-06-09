using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagementSystemFrontend.Models;

namespace EmployeeManagementSystemFrontend.Helper
{
    public static class Globals
    {
        public static Employee currentEmployee { get; set; } = new Employee();
    }
}
