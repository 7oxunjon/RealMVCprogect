using EntityLayer.Concreat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRele
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            
            RuleFor(x => x.CotegoryName).NotEmpty().WithMessage("Bo`sh qolmasligi kerak");
            RuleFor(x => x.CotegoryName).MinimumLength(3).WithMessage("eng kamida 3 ta belgi");
            RuleFor(x => x.CotegoryName).MaximumLength(20).WithMessage("Eng kupi bilan 20 ta belgi");
            RuleFor(x => x.CotegoryDescription).NotEmpty().WithMessage("Tasnifini bo`sh qoldirolmaysiz");
            RuleFor(x => x.CotegoryStatus).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");

            
        }
    }
}
