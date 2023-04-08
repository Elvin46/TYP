using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public int EducationDegreeId { get; set; }
        public EducationDegree EducationDegree { get; set; }
        //public ICollection<FacultyDepartment> FacultyDepartments { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Profession> Professions { get; set; }

    }
}
