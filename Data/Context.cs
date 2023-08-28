using Microsoft.EntityFrameworkCore;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserAdressConfiguration());
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }

    }
}
