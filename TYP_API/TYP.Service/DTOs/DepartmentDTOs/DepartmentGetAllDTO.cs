using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.DepartmentDTOs
{
    public class DepartmentGetAllDTO
    {
        public List<DepartmentGetDTO> Departments { get; set; }
        public int Count { get; set; }
    }
}
