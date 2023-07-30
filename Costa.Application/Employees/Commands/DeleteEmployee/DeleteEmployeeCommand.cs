using MediatR;

namespace Costa.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public uint ID { get; set; }

    }
}
