using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.PredmetProfessionDTOs;

namespace TYP.Service.DTOs.ProfessionDTOs
{
    public class ProfessionGetDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FacultyName { get; set; }
        public ICollection<PredmetProfessionGetDTO> PredmetProfessions { get; set; }
        public ICollection<int> OrderBys { get; set; }
    }
}
