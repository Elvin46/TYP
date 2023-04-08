using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PredmetDTOs
{
    public class PredmetGetAllDTO
    {
        public List<PredmetGetDTO> Predmets { get; set; }
        public int Count { get; set; }
    }
}
