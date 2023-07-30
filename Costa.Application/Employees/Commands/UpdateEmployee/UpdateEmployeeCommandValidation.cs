using FluentValidation;


namespace Costa.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidation : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.artist).NotEmpty().MaximumLength(250);
            // RuleFor(createArtistTitleCommand => createArtistTitleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}