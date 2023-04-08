using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.TeacherPredmetDTOs
{
    public class TeacherPredmetGetAllDTO
    {
        public List<TeacherPredmetGetDTO> TeacherPredmets { get; set; }
        public int Count { get; set; }
    }
}
