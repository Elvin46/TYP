using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.CertificationDTOs
{
    public class CertificationGetDTO
    {
        public string Name { get; set; }
        public bool IsLocal { get; set; }
        public string Country { get; set; }
    }
}
