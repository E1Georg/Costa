using MediatR;

namespace Costa.Application.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsVm>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

    }
}
