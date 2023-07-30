using FluentValidation;

namespace Costa.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryValidator : AbstractValidator<GetEmployeeDetailsQuery>
    {
        public GetEmployeeDetailsQueryValidator()
        {
            //RuleFor(artistTitle => artistTitle.Id).NotEqual(Guid.Empty);
        }
    }
}