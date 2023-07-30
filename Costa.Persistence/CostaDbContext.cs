using Costa.Domain;
using Costa.Application.Interfaces;
using Costa.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Costa.Persistence
{
    public class CostaDbContext : DbContext, ICostaDbContext
    {        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public CostaDbContext(DbContextOptions<CostaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(builder);
        }        
    }
}
