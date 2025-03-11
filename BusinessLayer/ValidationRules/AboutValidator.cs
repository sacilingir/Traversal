using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel kısmını boş geçemezsiniz.");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("En Az 50 karakterlik açıklama giriniz..");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("AEn Fazla 150 karakterlik açıklama giriniz..");
        }
    }
}
