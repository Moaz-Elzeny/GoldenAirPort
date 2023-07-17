using Etqaan.Domain.Entities;
using Etqaan.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Etqaan.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        #region Auth
        DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region Etqaan Entities
        DbSet<Nationality> Nationalities { get; set; }
        DbSet<UserActivity> UserActivities { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<SchoolClassSubject> SchoolClassSubjects { get; set; }
        #endregion



        DatabaseFacade Database { get; }

        ChangeTracker ChangeTracker { get; }
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));






        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
