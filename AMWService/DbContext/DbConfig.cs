using AMWService.IdentityAuth;
using AMWService.Models;
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

        public DbSet<CreateSO> ams_ServiceOrder { get; set; }
        public DbSet<Project> am_Custommer { get; set; }
        public DbSet<Columns> am_Status { get; set; }
        public DbSet<Problem> am_Type { get; set; }
        public DbSet<RootCause> am_RootCauseType { get; set; }
        public DbSet<Priolity>am_Priority { get; set; }
        public DbSet<UserOwner>amv_User { get; set; }
    }
}
