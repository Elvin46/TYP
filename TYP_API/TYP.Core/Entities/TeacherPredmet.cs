using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class TeacherPredmet : BaseEntity
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int PredmetGroupId { get; set; }
        public PredmetGroup PredmetGroup { get; set; }
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
    }
}
