using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Sector : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<TeacherSector> TeacherSectors { get; set; }

    }
}
