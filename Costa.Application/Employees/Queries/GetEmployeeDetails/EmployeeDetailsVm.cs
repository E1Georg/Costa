using AutoMapper;
using Costa.Application.Common.Mappings;
using Costa.Domain;

namespace Costa.Application.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public uint ID { get; set; }
        public Guid DepartmentID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? DocSeries { get; set; }
        public string? DocNumber { get; set; }
        public string Position { get; set; }
        public int? Age { get; set; }
        public string? DepartmentName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.ID,
                opt => opt.MapFrom(employee => employee.ID))
                .ForMember(employeeVm => employeeVm.DepartmentID,
                opt => opt.MapFrom(employee => employee.DepartmentID))
                .ForMember(employeeVm => employeeVm.SurName,
                opt => opt.MapFrom(employee => employee.SurName))
                .ForMember(employeeVm => employeeVm.FirstName,
                opt => opt.MapFrom(employee => employee.FirstName))
                .ForMember(employeeVm => employeeVm.Patronymic,
                opt => opt.MapFrom(employee => employee.Patronymic))
                .ForMember(employeeVm => employeeVm.DateOfBirth,
                opt => opt.MapFrom(employee => employee.DateOfBirth))
                .ForMember(employeeVm => employeeVm.DocSeries,
                opt => opt.MapFrom(employee => employee.DocSeries))
                .ForMember(employeeVm => employeeVm.DocNumber,
                opt => opt.MapFrom(employee => employee.DocNumber))
                .ForMember(employeeVm => employeeVm.Position,
                opt => opt.MapFrom(employee => employee.Position));
        }
        public int CalculateAgeCorrect(DateTime birthDate)
        {
            var now = DateTime.Today;
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

    }
}