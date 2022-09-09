using Microsoft.EntityFrameworkCore;
using UserAPI.Modeles;

namespace UserAPI.Data
{
    public class UserApiContext : DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options): base(options)
        {

        }

        public DbSet<User>? User { get; set; }
    }
}
