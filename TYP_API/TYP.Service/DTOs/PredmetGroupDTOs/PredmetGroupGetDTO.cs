using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.PredmetGroupDTOs
{
    public class PredmetGroupGetDTO
    {
        public int Id { get; set; }
        public string PredmetName { get; set; }
        public string Code { get; set; }
        public string Profession { get; set; }
        public string Faculty { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }
        public string Sector { get; set; }
        public int Credit { get; set; }
        public int GeneralHours { get; set; }
        public int OutOfAuditoryHours { get; set; }
        public int AuditoryHours { get; set; }
        public int Lecturer { get; set; }
        public int Seminar { get; set; }
        public int Laboratory { get; set; }
        public int CategoryId { get; set; }
        public int orderBy { get; set; }
        public string Session { get; set; }
        public int TeacherId { get; set; }
    }
}
