using Costa.Domain;

namespace Costa.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(CostaDbContext context)
        {
           // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();            
        }
    }
}
