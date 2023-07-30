using FluentValidation;

namespace Costa.Application.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQueryValidator : AbstractValidator<GetDepartmentDetailsQuery>
    {
        public GetDepartmentDetailsQueryValidator()
        {
            // Возможна окончательная проверка запроса на валидность
        }
    }
}