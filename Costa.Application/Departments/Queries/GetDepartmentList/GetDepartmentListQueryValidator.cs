using FluentValidation;


namespace Costa.Application.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryValidator : AbstractValidator<GetDepartmentListQuery>
    {
        public GetDepartmentListQueryValidator()
        {
            // Окончательная проверка запроса на валидность
        }
    }
}