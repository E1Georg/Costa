using MediatR;

namespace Costa.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
    }
}
