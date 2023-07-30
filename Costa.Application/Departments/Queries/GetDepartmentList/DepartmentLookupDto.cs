using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Domain;

namespace Costa.Application.Departments.Queries.GetDepartmentList
{
    public class DepartmentLookupDto : IMapWith<Department>
    {
        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentLookupDto>()
                .ForMember(departmentDto => departmentDto.ID,
                opt => opt.MapFrom(department => department.ID))
                .ForMember(departmentDto => departmentDto.ParentDepartmentID,
                opt => opt.MapFrom(department => department.ParentDepartmentID))
                .ForMember(departmentDto => departmentDto.Code,
                opt => opt.MapFrom(department => department.Code))
                .ForMember(departmentDto => departmentDto.Name,
                opt => opt.MapFrom(department => department.Name));
        }

    }
}
