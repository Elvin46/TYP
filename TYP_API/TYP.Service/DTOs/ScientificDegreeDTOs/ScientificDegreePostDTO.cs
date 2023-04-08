using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Service.DTOs.ScientificNameDTOs;

namespace TYP.Service.DTOs.ScientificDegreeDTOs
{
    public class ScientificDegreePostDTO
    {
        public string Name { get; set; }
    }
    public class ScientificDegreePostDTOValidator : AbstractValidator<ScientificNamePostDTO>
    {
        public ScientificDegreePostDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(4).MaximumLength(50);

        }
    }
}
