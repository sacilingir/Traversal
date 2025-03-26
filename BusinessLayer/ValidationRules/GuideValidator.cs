using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim En az 3 harf olmalı");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Açıklama en az 5 harf olmalı");

            RuleFor(X => X.Image).NotEmpty().WithMessage("Resim boş geçilemez.");
        
        }
    }
}
