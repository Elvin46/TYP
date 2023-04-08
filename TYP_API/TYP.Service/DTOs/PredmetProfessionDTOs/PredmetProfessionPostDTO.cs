using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PredmetProfessionDTOs
{
    public class PredmetProfessionPostDTO
    {
        public List<int> PredmetIds { get; set; }
        public int ProfessionId { get; set; }
        public List<string> Codes { get; set; }
        public int Credit { get; set; }
        public int GeneralHours { get; set; }
        public int OutOfAuditoryHours { get; set; }
        public int AuditoryHours { get; set; }
        public int Lecturer { get; set; }
        public int Seminar { get; set; }
        public int Laboratory { get; set; }
        public bool IsPrerequisite { get; set; }
        public int WeeklyLoad { get; set; }
        public int CategoryId { get; set; }
        public int SessionId { get; set; }
    }
}
