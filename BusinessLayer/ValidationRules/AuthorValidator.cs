using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator: AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.AuthorName).MinimumLength(3).WithMessage("Yazar adı en az 3 karakterden oluşmalıdır");
            RuleFor(x => x.AuthorName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar fotoğrafı boş geçilemez");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Yazar ilgilendiği alanları boş bırakamaz");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçilemez");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar Ünvanı boş bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail adresi en fazla 50 karakterden oluşmalıdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifre alanı en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Şifre alanı maksimum 50 karakterden oluşmalıdır");
            RuleFor(x => x.PhoneNumber).MinimumLength(12).WithMessage("Telefon numarası minimum 12 karakterden oluşmalıdır");
            RuleFor(x => x.PhoneNumber).MaximumLength(16).WithMessage("Telefon numarası en fazla 16 karakterden oluşmalıdır");
            
        }
    }
}
