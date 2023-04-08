using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class TeacherSector : BaseEntity 
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public int Level { get; set; }
    }
}
