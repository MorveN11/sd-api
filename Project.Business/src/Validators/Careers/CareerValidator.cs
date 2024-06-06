using FluentValidation;
using Project.Business.DTOs.Careers;

namespace Project.Business.Validators.Careers
{
    public class CareerValidator : BaseValidator<CareerRequestDTO>
    {
        public CareerValidator()
        {
            ApplyNameRules(x => x.Name, "Name");

            ApplyNotNullRules<string>(x => x.Code, "Code")
                .Matches(@"^[a-zA-Z]{2}-\d{2}$")
                .WithMessage("Code must be in the format XX-99");
        }
    }
}
