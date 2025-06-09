using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemFrontend.Models
{
    internal class LoginResponse
    {
        public String token { get; set; }

        public LoggedInEmployee emp { get; set; }

    }
}
