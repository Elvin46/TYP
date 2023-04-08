using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PredmetProfessionDTOs
{
    public class PredmetProfessionGetAllDTO
    {
        public List<PredmetProfessionGetDTO> PredmetProfessions { get; set; }
        public int Count { get; set; }
    }
}
