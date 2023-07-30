using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Costa.Domain;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Costa.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly ICostaDbContext _dbContext;
        public DeleteDepartmentCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Departments.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Department), request.ID);

            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
