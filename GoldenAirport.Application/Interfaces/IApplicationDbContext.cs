﻿using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace GoldenAirport.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        #region Auth
        DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region GoldenAirport Entities
        DbSet<Employee> Employees { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }
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