using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Profession : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<TeacherProfession> TeacherProfessions { get; set; }
        public ICollection<PredmetProfession> PredmetProfessions { get; set; }

    }
}
