using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.PredmetProfessionDTOs;

namespace TYP.Service.DTOs.TeacherPredmetDTOs
{
    public class TeacherPredmetGetDTO
    {
        public int TeacherId { get; set; }
        public PredmetProfessionGetDTO PredmetProfession { get; set; }
        public GroupGetDTO Group { get; set; }
    }
}
