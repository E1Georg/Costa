using MediatR;

namespace Costa.Application.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<DepartmentListVm>
    {
        public Guid ID { get; set; }
    }
}
