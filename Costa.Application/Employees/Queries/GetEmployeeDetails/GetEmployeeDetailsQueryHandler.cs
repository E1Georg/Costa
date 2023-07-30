using Costa.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Costa.Application.Common.Exceptions;
using Costa.Domain;


namespace Costa.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly ICostaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(ICostaDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .FirstOrDefaultAsync(employee => employee.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
            {
                throw new NotFoundException(nameof(Employee), request.ID);
            }

            var result = _mapper.Map<EmployeeDetailsVm>(entity);
            result.Age = result.CalculateAgeCorrect(result.DateOfBirth);

            var tmp = await _dbContext.Departments
                .FirstOrDefaultAsync(department => department.ID == result.DepartmentID, cancellationToken);

            result.DepartmentName = tmp?.Name;
            return result;
        }
    }
}
