using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Costa.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Costa.Application.Departments.Queries.GetDepartmentList;

namespace Costa.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListVm>
    {
        private readonly ICostaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(ICostaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            IList<EmployeeLookupDto> employeesQuery;

            if(request.DepartmentID is not null)
                employeesQuery = await _dbContext.Employees.Where(employee => employee.DepartmentID == request.DepartmentID)
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);            
            else
                employeesQuery = await _dbContext.Employees
               .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            foreach (var item in employeesQuery)
                item.Age = item.CalculateAgeCorrect(item.DateOfBirth);           

            return new EmployeeListVm { Employees = employeesQuery };   
        }
    }
}
