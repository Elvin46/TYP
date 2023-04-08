using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.SectorDTOs
{
    public class SectorGetAllDTO
    {
        public List<SectorGetDTO> Sectors { get; set; }
        public int Count { get; set; }
    }
}
