using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class TeacherProfession : BaseEntity
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
    }
}
