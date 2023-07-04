using EntityLayer.Concreat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRele
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Qabul_qiluvchiMail).NotEmpty().WithMessage("Oluvchi Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mavzu Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Masseg Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("ko`pi bilan 100 ta belgi bo`lishi kerak");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Kamida bilan 3 ta belgi bo`lishi kerak");
        }
    }
}
