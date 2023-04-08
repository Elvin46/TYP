using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.CertificationDTOs
{
    public class CertificationPostDTO
    {
        public string Name { get; set; }
        public bool IsLocal { get; set; }
        public string? Country { get; set; }
    }
    public class CertificationPostDTOValidator : AbstractValidator<CertificationPostDTO>
    {
        public CertificationPostDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(10).MaximumLength(50);
        }
    }
}
