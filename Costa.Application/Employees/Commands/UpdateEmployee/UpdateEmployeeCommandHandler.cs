using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Costa.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Costa.Application.Employees.Commands.UpdateEmployee
{    
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly ICostaDbContext _dbContext;
        public UpdateEmployeeCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
                throw new NotFoundException(nameof(Employee), request.ID);

            entity.DepartmentID = request.DepartmentID;
            entity.SurName = request.SurName;
            entity.FirstName = request.FirstName;
            entity.Patronymic = request.Patronymic;
            entity.DateOfBirth = request.DateOfBirth;
            entity.DocSeries = request.DocSeries;
            entity.DocNumber = request.DocNumber;
            entity.Position = request.Position;

            var entityTest = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.SurName == entity.SurName
                                                                            && employee.FirstName == entity.FirstName
                                                                            && employee.DateOfBirth == entity.DateOfBirth,
                                                                            cancellationToken);

            if (entityTest != null && entityTest.SurName == entity.SurName && entityTest.FirstName == entity.FirstName && entityTest.DateOfBirth == entity.DateOfBirth)
                throw new EntityСannotUpdated(nameof(Employee), request.ID);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
