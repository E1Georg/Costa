using FluentValidation;

namespace Costa.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidation()
        {
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.artist).NotEmpty().MaximumLength(250);
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}