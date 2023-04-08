using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TeacherPlace> TeacherPlaces { get; set; }

    }
}
