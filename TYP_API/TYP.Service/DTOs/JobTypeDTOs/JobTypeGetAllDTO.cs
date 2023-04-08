using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.JobTypeDTOs
{
    public class JobTypeGetAllDTO
    {
        public List<JobTypeGetDTO> JobTypes { get; set; }
        public int Count { get; set; }
    }
}
