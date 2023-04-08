using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.PredmetGroupDTOs;

namespace TYP.Service.DTOs.TeacherPredmetDTOs
{
    public class TeacherPredmetPostViewDTO
    {
        public List<PredmetGroupGetDTO> PredmetGroups { get; set; }
        public List<int> OrderBys { get; set; }
        public int TeachersHours { get; set; }
    }
}
