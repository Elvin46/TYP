using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.DTOs.FacultyDTOs;

namespace TYP.Service.DTOs.PredmetGroupDTOs
{
    public class PredmetGroupOutDepartmentDTO
    {
        public FacultyGetDTO FacultyDTO { get; set; }
        public int Lecturers { get; set; }
        public int Seminars { get; set; }
        public int Laboratories { get; set; }
        public int AdviceHours { get; set; }
        public int LecturersII { get; set; }
        public int SeminarsII { get; set; }
        public int LaboratoriesII { get; set; }
        public int AdviceHoursII { get; set; }
        public int Exams { get; set; }
        public int IstehsalatTecrubesi { get; set; }
        public int BuraxilisIsi { get; set; }
        public int MagistrDissert { get; set; }
        public int Doktorantura { get; set; }

    }
}
