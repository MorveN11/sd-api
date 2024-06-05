using FluentValidation;
using Project.Business.DTOs;

namespace Project.Core.Validators
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        public StudentValidator()
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

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("LastName is required")
                .NotEmpty()
                .WithMessage("LastName is required")
                .MinimumLength(2)
                .WithMessage("LastName must have at least 2 characters")
                .MaximumLength(50)
                .WithMessage("LastName must have at most 50 characters")
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage("LastName must contain only letters");

            RuleFor(x => x.BirthDate)
                .NotNull()
                .WithMessage("BirthDate is required")
                .NotEmpty()
                .WithMessage("BirthDate is required")
                .Must(x => DateTime.TryParse(x.ToString(), out _))
                .WithMessage("BirthDate is not a valid DateTime")
                .LessThan(DateTime.Now)
                .WithMessage("BirthDate must be in the past");
        }
    }
}
