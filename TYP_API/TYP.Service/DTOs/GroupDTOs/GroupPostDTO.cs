using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.GroupDTOs
{
    public class GroupPostDTO
    {
        public int Number { get; set; }
        public int StudentsCount { get; set; }
        //Enumla configure et
        public int Course { get; set; }
        public int ProfessionId { get; set; }
        public int SectorId { get; set; }
    }
}
