using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.TeacherDTOs
{
    public class TeacherGetAllDTO
    {
        public List<TeacherGetDTO> Teachers { get; set; }
        public int Count { get; set; }

    }
}
