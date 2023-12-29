using Microsoft.EntityFrameworkCore;

namespace ProfileService.Models
{
public class ProfileContext : DbContext
    {
        public DbSet<Profiles> Profile {get; set;}

        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
            
        }

    }

}