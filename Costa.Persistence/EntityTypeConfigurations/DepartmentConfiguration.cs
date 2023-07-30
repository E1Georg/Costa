using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Costa.Domain;

namespace Costa.Persistence.EntityTypeConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.ID);
            builder.HasIndex(department => department.ID).IsUnique();

            builder.Property(department => department.ID).IsRequired();
            builder.Property(department => department.Code).HasMaxLength(10);
            builder.Property(department => department.Name).HasMaxLength(50).IsRequired();            
            
        }
    }
}
