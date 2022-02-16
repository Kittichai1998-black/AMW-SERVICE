using AMWService.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMWService.DbContext
{
    public class DbConfig : IdentityDbContext<User>
    {
        public DbConfig(DbContextOptions<DbConfig> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Models.CreateSO>ServiceOrder { get; set; }
    }
}
