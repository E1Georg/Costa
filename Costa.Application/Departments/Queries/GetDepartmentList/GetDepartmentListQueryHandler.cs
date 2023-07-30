using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Costa.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Costa.Application.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, DepartmentListVm>
    {
        private readonly ICostaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(ICostaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DepartmentListVm> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentsQuery = await _dbContext.Departments
                .ProjectTo<DepartmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DepartmentListVm { Departments = departmentsQuery };
        }
    }
}
