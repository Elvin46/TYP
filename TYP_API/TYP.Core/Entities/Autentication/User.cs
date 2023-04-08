using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities.Autentication
{
    public class User : IdentityUser
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
