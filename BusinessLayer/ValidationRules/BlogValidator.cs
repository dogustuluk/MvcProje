using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz");
            RuleFor(x => x.BlogTitle).MinimumLength(10).WithMessage("Blog başlığı en az 10 karakter olmalıdır");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Blog başlığı en fazla 100 karakter olmalıdır");
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("Blog Saati değiştirilemez");
        }
    }
}
