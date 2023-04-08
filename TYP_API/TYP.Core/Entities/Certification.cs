using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Certification : BaseEntity
    {
        public string Name { get; set; }
        public bool IsLocal { get; set; }
        public string Country { get; set; }
        public ICollection<TeacherCertification> TeacherCertifications { get; set; }


    }
}
