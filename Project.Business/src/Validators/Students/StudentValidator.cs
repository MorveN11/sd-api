using FluentValidation;
using Project.Business.DTOs.Students;

namespace Project.Business.Validators.Students
{
    public class StudentValidator : BaseValidator<StudentRequestDTO>
    {
        public StudentValidator()
        {
            ApplyNameRules(x => x.Name, "Name");

            ApplyNameRules(x => x.LastName, "LastName");

            ApplyDateTimeRules(x => x.BirthDate, "BirthDate")
                .LessThan(System.DateTime.Now)
                .WithMessage("BirthDate must be in the past");
        }
    }
}
