using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class EducationDegree : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
