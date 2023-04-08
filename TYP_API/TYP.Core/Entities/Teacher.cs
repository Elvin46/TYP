using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int ScientificNameId { get; set; }
        public ScientificName ScientificName { get; set; }
        public int ScientificDegreeId { get; set; }
        public ScientificDegree ScientificDegree { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public ICollection<TeacherPlace> TeacherPlaces { get; set; }
        public ICollection<TeacherProfession> TeacherProfessions { get; set; }
        public ICollection<TeacherGroup> TeacherGroups { get; set; }
        public ICollection<TeacherPredmet> TeacherPredmets { get; set; }
        public ICollection<TeacherCertification> TeacherCertifications { get; set; }
        public ICollection<TeacherSector> TeacherSectors { get; set; }
        public ICollection<TeacherLanguage> TeacherLanguages { get; set; }
        public ICollection<PredmetGroup> PredmetGroups { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
