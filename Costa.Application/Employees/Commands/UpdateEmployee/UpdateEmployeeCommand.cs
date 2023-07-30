using MediatR;

namespace Costa.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public uint ID { get; set; }
        public Guid DepartmentID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? DocSeries { get; set; }
        public string? DocNumber { get; set; }
        public string Position { get; set; }
    }
}
