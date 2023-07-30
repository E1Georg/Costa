using FluentValidation;

namespace Costa.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidation : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidation()
        {
           // Проверка полей сущности перед сохранением в БД
        }
    }
}