using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj içeriği boş bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj konusu boş bırakılamaz");
            RuleFor(x => x.Message).MaximumLength(50).WithMessage("Mesaj içeriği 50 karakterden fazla olamaz");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mail maksimum 50 karakter içermelidir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakterden oluşmalıdır");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Soyadı alanı maksimum 50 karakterden oluşmalıdır");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesaj konusu maksimum 50 karakter içermelidir");
        }
    }
}
