using MediatR;

namespace Costa.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public uint ID { get; set; }

    }
}
