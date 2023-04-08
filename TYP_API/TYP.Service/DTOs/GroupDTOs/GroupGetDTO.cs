using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.ProfessionDTOs;

namespace TYP.Service.DTOs.GroupDTOs
{
    public class GroupGetDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int StudentsCount { get; set; }
        //Enumla configure et
        public int Course { get; set; }
        public int ProfessionId { get; set; }
        public ProfessionGetDTO Profession { get; set; }
        public string SectorCode { get; set; }
    }
}
