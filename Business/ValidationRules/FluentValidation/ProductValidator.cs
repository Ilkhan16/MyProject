using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.ProductName).MinimumLength(3);
        RuleFor(product => product.ProductName).NotEmpty();
        RuleFor(product => product.UnitPrice).NotEmpty();
        RuleFor(product => product.UnitPrice).GreaterThan(0);
        RuleFor(product => product.ProductName).Must(StartWithB).WithMessage("Ürünler 'B' harfi ile başlamalı");
    }

    private bool StartWithB(string? arg)
    {
        return arg.StartsWith("B");
    }
}