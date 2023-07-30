using Costa.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Costa.Application.Common.Exceptions;
using Costa.Domain;


namespace Costa.Application.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsVm>
    {
        private readonly ICostaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentDetailsQueryHandler(ICostaDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DepartmentDetailsVm> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            Department? entity = null;

            if (request.Name != null)
                entity = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Name == request.Name, cancellationToken);
            else if (request.ID != Guid.Empty)
                entity = await _dbContext.Departments.FirstOrDefaultAsync(department => department.ID == request.ID, cancellationToken);

            if (entity == null)            
                throw new NotFoundException(nameof(Department), request.ID);

            var result = _mapper.Map<DepartmentDetailsVm>(entity);

            if (entity.ParentDepartmentID != null && entity.ParentDepartmentID != Guid.Empty)
            {
                var parent = await _dbContext.Departments.FirstOrDefaultAsync(department => department.ID == entity.ParentDepartmentID, cancellationToken);
                result.ParentDepartmentName = parent?.Name;
            }

            return result;
        }
    }
}
