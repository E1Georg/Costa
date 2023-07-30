using FluentValidation;


namespace Costa.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidation : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidation()
        {
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.artist).NotEmpty().MaximumLength(250);
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}