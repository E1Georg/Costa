using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Domain;

namespace Costa.Application.Departments.Queries.GetDepartmentDetails
{
    public class DepartmentDetailsVm : IMapWith<Department>
    {
        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? ParentDepartmentName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDetailsVm>()
                .ForMember(departmentVm => departmentVm.ID,
                opt => opt.MapFrom(department => department.ID))
                .ForMember(departmentVm => departmentVm.ParentDepartmentID,
                opt => opt.MapFrom(department => department.ParentDepartmentID))
                .ForMember(departmentVm => departmentVm.Code,
                opt => opt.MapFrom(department => department.Code))
                .ForMember(departmentVm => departmentVm.Name,
                opt => opt.MapFrom(department => department.Name));
        }

    }
}
