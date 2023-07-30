using System.ComponentModel.DataAnnotations.Schema;

namespace Costa.Domain
{
    public class Department
    {        
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }        

        public Guid? ParentDepartmentID { get; set; }  

        [ForeignKey("ParentDepartmentID")]
        public Department? ParentDepartment { get; set; }
         
    }
}
