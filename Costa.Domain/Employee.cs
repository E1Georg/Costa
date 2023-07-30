using System.ComponentModel.DataAnnotations.Schema;

namespace Costa.Domain
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }       
        public string? Patronymic { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public string? DocSeries { get; set; }
        public string? DocNumber { get; set; }
        public string Position { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentID { get; set; }
        public Department? Department { get; set; }
    }
}
