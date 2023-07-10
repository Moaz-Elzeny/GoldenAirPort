using Etqaan.Application.Interfaces;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Etqaan.Infrastructure.Presistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region Auth
        public DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region Etqaan Entities
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion
        public override DatabaseFacade Database => base.Database;
        public override ChangeTracker ChangeTracker => base.ChangeTracker;



        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
