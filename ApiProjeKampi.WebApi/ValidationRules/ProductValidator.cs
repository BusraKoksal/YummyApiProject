using FluentValidation;
using ApiProjeKampi.WebApi.Entities;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(X => X.ProductName).NotEmpty().WithMessage("Ürün adını boş geçmeyin");
            RuleFor(X => X.ProductName).MinimumLength(2).WithMessage("En az 2 karakter veri girişi yapın");
            RuleFor(X => X.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın");
            RuleFor(X => X.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçmeyin").LessThan(0).WithMessage("Ürün fiyatı 0 olamaz").GreaterThan(1000).WithMessage("ürün fiyatı bu kadar yüksek olamaz");
            RuleFor(X => X.ProductDescription).NotEmpty().WithMessage("Ürün adını boş geçmeyin");
        }
    }
}
