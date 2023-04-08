using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.BookDTOs;
using TYP.Service.DTOs.CertificationDTOs;
using TYP.Service.DTOs.PLaceDTOs;
using TYP.Service.DTOs.SectorDTOs;

namespace TYP.Service.DTOs.TeacherDTOs
{
    public class TeacherPostDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public int SexId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int ScientificNameId { get; set; }
        public int ScientificDegreeId { get; set; }
        public int DepartmentId { get; set; }
        public int JobTypeId { get; set; }
        public List<SectorEditDTO> Sectors { get; set; }
        public List<string> LanguageNames { get; set; }
        public List<TeacherPlacePostDTO> Places { get; set; }
        public List<CertificationPostDTO> Certifications { get; set; }
        public List<BookPostDTO> Books { get; set; }
    }
    public class TeacherPostDTOValidator : AbstractValidator<TeacherPostDTO>
    {
        public TeacherPostDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Surname).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Fathername).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Email).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.PhoneNumber).LessThanOrEqualTo(999999999).GreaterThanOrEqualTo(100000000);
            RuleFor(x => x.SexId).NotNull().NotEmpty();
            //RuleFor(x => x.ScientificNameId).NotNull().NotEmpty();
            //RuleFor(x => x.ScientificDegreeId).NotNull().NotEmpty();
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.JobTypeId).NotNull().NotEmpty();
            RuleFor(x => x.BirthDate).NotNull().NotEmpty();

        }
    }
}
