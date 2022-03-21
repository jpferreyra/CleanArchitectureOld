using FluentValidation;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{Name is empty}");

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{Barcode is empty}")
                .MaximumLength(50).WithMessage("{Barcode} max length 50");                
        }
    }
}
