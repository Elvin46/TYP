using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.ProfessionDTOs
{
    public class ProfessionGetAllDTO
    {
        public List<ProfessionGetDTO> Professions { get; set; }
        public int Count { get; set; }
    }
}
