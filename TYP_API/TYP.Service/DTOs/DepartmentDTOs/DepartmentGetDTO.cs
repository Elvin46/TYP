using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.TeacherDTOs;

namespace TYP.Service.DTOs.DepartmentDTOs
{
    public class DepartmentGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherGetDTO> Teachers { get; set; }
    }
}
