using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Group : BaseEntity
    {
        public int Number { get; set; }
        public int StudentsCount { get; set; }
        //Enumla configure et
        public int Course { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public ICollection<TeacherGroup> TeacherGroups { get; set; }
        public ICollection<PredmetGroup> PredmetGroups   { get; set; }
    }
}
