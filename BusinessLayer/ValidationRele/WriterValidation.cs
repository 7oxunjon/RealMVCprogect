using EntityLayer.Concreat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRele
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Eng kamida 2 ta belgi bo`lishi kerak");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Eng ko`pida 50 ta belgi");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.WriterAbout).MaximumLength(150).WithMessage("ko`pi bilan 150 ta belgi");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Eng kamida 2 ta belgi kiriting");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Eng kamida 3 ta belgi");
        }
    }
}
