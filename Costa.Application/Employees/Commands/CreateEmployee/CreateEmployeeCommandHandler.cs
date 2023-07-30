using MediatR;
using Costa.Domain;
using Costa.Application.Common.Exceptions;
using Costa.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Costa.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly ICostaDbContext _dbContext;
        public CreateEmployeeCommandHandler(ICostaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {            
            var entity = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.SurName == request.SurName
                                                                            && employee.FirstName == request.FirstName
                                                                            && employee.DateOfBirth == request.DateOfBirth, 
                                                                            cancellationToken);
            
            if (entity == null)
            {
                var Temp = new Employee
                {
                    ID = uint.MinValue,
                    DepartmentID = request.DepartmentID,
                    SurName = request.SurName,
                    FirstName = request.FirstName,
                    Patronymic = request.Patronymic,
                    DateOfBirth = request.DateOfBirth,
                    DocSeries = request.DocSeries,
                    DocNumber = request.DocNumber,
                    Position = request.Position
                };

                await _dbContext.Employees.AddAsync(Temp, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            else
            {
                throw new EntityAlreadyExistException(nameof(Employee), request.ID);
            }
        }
    }
}
