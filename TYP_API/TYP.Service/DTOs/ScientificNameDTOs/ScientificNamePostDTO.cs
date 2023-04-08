using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.ScientificNameDTOs
{
    public class ScientificNamePostDTO
    {
        public string Name { get; set; }
    }
    public class ScientificNamePostDTOValidator : AbstractValidator<ScientificNamePostDTO>
    {
        public ScientificNamePostDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(4).MaximumLength(50);

        }
    }
}
