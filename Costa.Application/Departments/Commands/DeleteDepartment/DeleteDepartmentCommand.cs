using MediatR;

namespace Costa.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }        
    }
}
