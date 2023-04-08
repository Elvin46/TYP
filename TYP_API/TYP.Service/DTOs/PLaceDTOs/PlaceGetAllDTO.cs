using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PLaceDTOs
{
    public class PlaceGetAllDTO
    {
        public List<PlaceGetDTO> Places { get; set; }
        public int Count { get; set; }
    }
}
