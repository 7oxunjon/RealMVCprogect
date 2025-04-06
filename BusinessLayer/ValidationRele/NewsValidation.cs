using EntityLayer.Concreat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRele
{
    public class NewsValidation : AbstractValidator<News>
    {
        public NewsValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Тўлдирилмаган майдон аниқланди");
            RuleFor(x => x.Title).NotEmpty().MinimumLength(10).WithMessage("Камида 10 та белги киритилиши шарт");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Тўлдирилмаган майдон аниқланди");
            RuleFor(x => x.photoNews).NotEmpty().WithMessage("Расм жойлаштирилмаган");

        }
    }
}
