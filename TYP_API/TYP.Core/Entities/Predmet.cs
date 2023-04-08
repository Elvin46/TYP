using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Predmet : BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<PredmetProfession> PredmetProfessions { get; set; }
        public ICollection<TeacherPredmet> TeacherPredmets { get; set; }
        public ICollection<PredmetGroup> PredmetGroups { get; set; }

    }
}
