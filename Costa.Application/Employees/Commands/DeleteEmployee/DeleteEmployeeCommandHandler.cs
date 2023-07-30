using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Costa.Domain;
using MediatR;


namespace Costa.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly ICostaDbContext _dbContext;
        public DeleteEmployeeCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Employee), request.ID);

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
