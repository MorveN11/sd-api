using System.Linq.Expressions;
using FluentValidation;
using Project.Business.DTOs;

namespace Project.Business.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
        where T : class, IBaseEntityRequestDTO, new()
    {
        protected IRuleBuilderOptions<T, V> ApplyNotNullRules<V>(
            Expression<Func<T, V>> propertyFunc,
            string propertyName
        )
        {
            return RuleFor(propertyFunc)
                .NotNull()
                .WithMessage($"{propertyName} is required")
                .NotEmpty()
                .WithMessage($"{propertyName} cannot be empty");
        }

        protected IRuleBuilderOptions<T, string> ApplyNameRules(
            Expression<Func<T, string>> propertyFunc,
            string propertyName
        )
        {
            return ApplyNotNullRules<string>(propertyFunc, propertyName)
                .MinimumLength(2)
                .WithMessage($"{propertyName} must have at least 2 characters")
                .MaximumLength(50)
                .WithMessage($"{propertyName} must have at most 50 characters")
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage($"{propertyName} must contain only letters and spaces");
        }

        protected IRuleBuilderOptions<T, DateTime> ApplyDateTimeRules(
            Expression<Func<T, DateTime>> propertyFunc,
            string propertyName
        )
        {
            return ApplyNotNullRules<DateTime>(propertyFunc, propertyName)
                .Must(x => System.DateTime.TryParse(x.ToString(), out _))
                .WithMessage($"{propertyName} is not a valid DateTime");
        }
    }
}
