using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities.Autentication;

namespace TYP.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        //public ICollection<FacultyDepartment> FacultyDepartments { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public int FacultyId { get; set; }
        public ICollection<Predmet> Predmets { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
