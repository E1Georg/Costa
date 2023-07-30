using FluentValidation;


namespace Costa.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandValidation : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidation()
        {
            // Можно проверить валидность команды удаления
        }
    }
}