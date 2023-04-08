using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Service.DTOs.DepartmentDTOs
{
    public class DepartmentPostDTO
    {
        public string Name { get; set; }
    }
    public class DepartmentPostDTOValidator : AbstractValidator<DepartmentPostDTO>
    {
        public DepartmentPostDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(4).MaximumLength(50);

        }
    }
}
