using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Application.Employees.Commands.CreateEmployee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Costa.WebProject.Models.Employee
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public Guid? DepartmentID { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указана фамилия сотрудника")]
        public string SurName { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указано имя сотрудника")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string? Patronymic { get; set; }

        [DateAttribute2]
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(4)]
        public string? DocSeries { get; set; }
        [MaxLength(6)]
        public string? DocNumber { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указана должность сотрудника")]
        public string Position { get; set; }
        
        public string? DepartmentName { get; set; }

        public string? ParentDepartmentID_string { get; set; }
        public List<SelectListItem>? Departments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.DepartmentID,
                opt => opt.MapFrom(employeeDto => employeeDto.DepartmentID))
                .ForMember(employeeCommand => employeeCommand.SurName,
                opt => opt.MapFrom(employeeDto => employeeDto.SurName))
                .ForMember(employeeCommand => employeeCommand.FirstName,
                opt => opt.MapFrom(employeeDto => employeeDto.FirstName))
                .ForMember(employeeCommand => employeeCommand.Patronymic,
                opt => opt.MapFrom(employeeDto => employeeDto.Patronymic))
                .ForMember(employeeCommand => employeeCommand.DateOfBirth,
                opt => opt.MapFrom(employeeDto => employeeDto.DateOfBirth))
                .ForMember(employeeCommand => employeeCommand.DocSeries,
                opt => opt.MapFrom(employeeDto => employeeDto.DocSeries))
                .ForMember(employeeCommand => employeeCommand.DocNumber,
                opt => opt.MapFrom(employeeDto => employeeDto.DocNumber))
                .ForMember(employeeCommand => employeeCommand.Position,
                opt => opt.MapFrom(employeeDto => employeeDto.Position));
        }
        public class DateAttribute2 : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                value = (DateTime)value;

                if (DateTime.Now.AddYears(-100).CompareTo(value) <= 0 && DateTime.Now.CompareTo(value) >= 0)                
                    return ValidationResult.Success;                
                else
                    return new ValidationResult("Указана невозможная дата рождения!");                
            }
        }
    }
}