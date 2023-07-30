using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Application.Departments.Commands.CreateDepartment;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Costa.WebProject.Models.Department
{
    public class CreateDepartmentDto : IMapWith<CreateDepartmentCommand>
    {
        public Guid? ParentDepartmentID { get; set; }
        [MaxLength(10)]
        public string? Code { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указано название отдела")]
        public string Name { get; set; }

        public string? ParentDepartmentID_string { get; set; }
        public List<SelectListItem>? Departments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentDto, CreateDepartmentCommand>()
                .ForMember(departmentCommand => departmentCommand.ParentDepartmentID,
                opt => opt.MapFrom(departmentDto => departmentDto.ParentDepartmentID))
                .ForMember(departmentCommand => departmentCommand.Code,
                opt => opt.MapFrom(departmentDto => departmentDto.Code))
                .ForMember(departmentCommand => departmentCommand.Name,
                opt => opt.MapFrom(departmentDto => departmentDto.Name));
        }
    }
}
