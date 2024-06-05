using FluentValidation;
using Project.Business.DTOs;

namespace Project.Core.Validators
{
    public class CareerValidator : AbstractValidator<CareerDTO>
    {
        public CareerValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name is required")
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(2)
                .WithMessage("Name must have at least 2 characters")
                .MaximumLength(50)
                .WithMessage("Name must have at most 50 characters")
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage("Name must contain only letters");

            RuleFor(x => x.Code)
                .NotNull()
                .WithMessage("Code is required")
                .NotEmpty()
                .WithMessage("Code is required")
                .Matches(@"^[a-zA-Z]{2}-\d{2}$")
                .WithMessage("Code must be in the format XX-99");
        }
    }
}
