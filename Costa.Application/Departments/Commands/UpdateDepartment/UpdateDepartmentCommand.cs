using MediatR;

namespace Costa.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
    }
}
