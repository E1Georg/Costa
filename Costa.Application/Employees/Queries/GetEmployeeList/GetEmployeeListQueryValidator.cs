using FluentValidation;


namespace Costa.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryValidator : AbstractValidator<GetEmployeeListQuery>
    {
        public GetEmployeeListQueryValidator()
        {
            //RuleFor(x => x.offerId).NotEmpty();
        }
    }
}