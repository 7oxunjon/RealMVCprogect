using EntityLayer.Concreat;
using FluentValidation;


namespace BusinessLayer.ValidationRele
{
    public class ContectValidator : AbstractValidator<Contact>
    {
        public ContectValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail bo`sh bo`lmasligi kerak");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bo`sh bo`lmasligi kerak");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("Kamida 3 ta belgi ishlatilsin");
            RuleFor(x => x.Subject).MinimumLength(4).WithMessage("Kamida 3 ta belgi bo`lishi kerak");
            RuleFor(x => x.UserMail).MaximumLength(20).WithMessage("Ko`pi bilan 20 ta belgi ishlatilsin");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Ko`pi bilan 20 ta belgi ishlatilsin");
        }
    }
}
