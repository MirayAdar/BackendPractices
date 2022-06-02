using FluentValidation;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Business.ValidationRules.FluentValidator
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.ProductName).Length(2, 30).WithMessage("Ürün ismi 2 ile 30 karakter arasında olmalı");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat boş olamaz");
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA);  // kendi kuralımız
         }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
