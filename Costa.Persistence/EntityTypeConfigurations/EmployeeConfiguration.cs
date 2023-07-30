using Costa.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;

namespace Costa.Persistence.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {       
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.ID);
            builder.HasIndex(employee => employee.ID).IsUnique();
           
            builder.Property(employee => employee.ID).IsRequired();         
            builder.Property(employee => employee.DepartmentID).IsRequired();
            builder.Property(employee => employee.SurName).HasMaxLength(50).IsRequired();
            builder.Property(employee => employee.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(employee => employee.Patronymic).HasMaxLength(50);
            builder.Property(employee => employee.DateOfBirth).IsRequired().HasColumnType("DateTime");
            builder.Property(employee => employee.DocSeries).HasMaxLength(4);
            builder.Property(employee => employee.DocNumber).HasMaxLength(6);
            builder.Property(employee => employee.Position).HasMaxLength(50).IsRequired();
        }
    }
}
