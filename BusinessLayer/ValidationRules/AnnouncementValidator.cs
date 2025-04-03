using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyiniz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen içeriği boş geçmeyiniz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalı");
            RuleFor(x => x.Title).MaximumLength(25).WithMessage("Başlık en fazla 20 karakter olmalı");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("İçerik en az 5 karakter olmalı");
            RuleFor(x => x.Content).MaximumLength(40).WithMessage("İçerik en fazla 40 karakter olmalı");
        }
    }
}
