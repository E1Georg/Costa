using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Costa.Domain;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Costa.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly ICostaDbContext _dbContext;
        public UpdateDepartmentCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(department => department.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Department), request.ID);

            entity.ParentDepartmentID = request.ParentDepartmentID;
            entity.Code = request.Code;
            entity.Name = request.Name;

            var entityTest = await _dbContext.Departments.FirstOrDefaultAsync(department => 
                                                    department.Name == entity.Name &&
                                                    department.Code == entity.Code &&
                                                     department.ParentDepartmentID == entity.ParentDepartmentID,
                                                    cancellationToken);
            if (entityTest != null)
                throw new EntityСannotUpdated(nameof(Department), request.ID);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
