using FluentValidation;


namespace Costa.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidation : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
