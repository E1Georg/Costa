using MediatR;
using Costa.Domain;
using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Costa.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly ICostaDbContext _dbContext;
        public CreateDepartmentCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Name == request.Name, cancellationToken);

            if (entity == null || entity.Name != request.Name)
            {
                var Temp = new Department
                {
                    ID = Guid.NewGuid(),
                    ParentDepartmentID = request.ParentDepartmentID,
                    Code = request.Code,
                    Name = request.Name
                };

                await _dbContext.Departments.AddAsync(Temp, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Temp.ID;
            }
            else
            {
                throw new EntityAlreadyExistException(nameof(Department), request.ID);
            }
        }
    }
}
