using Microsoft.EntityFrameworkCore;
using Costa.Domain;

namespace Costa.Application.Interfaces
{
    public interface ICostaDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
