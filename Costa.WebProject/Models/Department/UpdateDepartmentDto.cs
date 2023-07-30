using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Application.Departments.Commands.UpdateDepartment;
using Costa.Application.Departments.Queries.GetDepartmentDetails;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Costa.WebProject.Models.Department
{
    public class UpdateDepartmentDto : IMapWith<UpdateDepartmentCommand>, IMapWith<DepartmentDetailsVm>
    {
        public Guid ID { get; set; }
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
            profile.CreateMap<UpdateDepartmentDto, UpdateDepartmentCommand>()
                .ForMember(departmentCommand => departmentCommand.ParentDepartmentID,
                opt => opt.MapFrom(departmentDto => departmentDto.ParentDepartmentID))
                .ForMember(departmentCommand => departmentCommand.Code,
                opt => opt.MapFrom(departmentDto => departmentDto.Code))
                .ForMember(departmentCommand => departmentCommand.ID,
                opt => opt.MapFrom(departmentDto => departmentDto.ID))
                .ForMember(departmentCommand => departmentCommand.Name,
                opt => opt.MapFrom(departmentDto => departmentDto.Name));

            profile.CreateMap<DepartmentDetailsVm, UpdateDepartmentDto>()
                .ForMember(departmentCommand => departmentCommand.ParentDepartmentID,
                opt => opt.MapFrom(departmentDto => departmentDto.ParentDepartmentID))
                .ForMember(departmentCommand => departmentCommand.Code,
                opt => opt.MapFrom(departmentDto => departmentDto.Code))
                .ForMember(departmentCommand => departmentCommand.ID,
                opt => opt.MapFrom(departmentDto => departmentDto.ID))
                .ForMember(departmentCommand => departmentCommand.Name,
                opt => opt.MapFrom(departmentDto => departmentDto.Name));
        }
    }
}
