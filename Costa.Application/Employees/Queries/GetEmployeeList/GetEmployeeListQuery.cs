using MediatR;

namespace Costa.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IRequest<EmployeeListVm>
    {
        public uint ID { get; set; }
        public Guid? DepartmentID { get; set; }
    }
}
