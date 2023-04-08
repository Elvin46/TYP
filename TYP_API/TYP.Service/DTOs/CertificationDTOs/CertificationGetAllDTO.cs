using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.CertificationDTOs
{
    public class CertificationGetAllDTO
    {
        public List<CertificationGetDTO> Certifications { get; set; }
        public int Count { get; set; }
    }
}
