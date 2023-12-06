using GoldenAirport.Domain.Entities;
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
        DbSet<Trip> Trips { get; set; }
        DbSet<CityTrip> CityTrips { get; set; }
        DbSet<TripRegistration> TripRegistrations { get; set; }
        DbSet<TripRegistrationEditing> TripRegistrationsEditing { get; set; }
        DbSet<TripRegistrationDeleting> TripRegistrationsDeleting { get; set; }
        DbSet<AdultEditing> AdultsEditing { get; set; }
        DbSet<Adult> Adults { get; set; }
        DbSet<Child> Children { get; set; }
        DbSet<ChildEditing> ChildrenEditing { get; set; }
        DbSet<WhyVisit> WhyVisits { get; set; }
        DbSet<WhatIsIncluded> WhatAreIncluded { get; set; }
        DbSet<Accessibility> Accessibilities { get; set; }
        DbSet<Restriction> Restrictions { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<PackagePlan> PackagePlans { get; set; }
        DbSet<PackageRegistration> PackageRegistrations { get; set; }
        DbSet<PackageRegistrationEditing> PackageRegistrationsEditing { get; set; }
        DbSet<PackageRegistrationDeleting> PackageRegistrationsDeleting { get; set; }
        DbSet<PaymentOption> PaymentOptions { get; set; }
        DbSet<PaymentOptionTrip> PaymentOptionTrips { get; set; }
        DbSet<PaymentOptionPackage> PaymentOptionPackages { get; set; }
        DbSet<PaymentOptionEmployee> paymentOptionEmployee { get; set; }
        DbSet<CityPackage> CityPackages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Domain.Entities.Chat> Chats { get; set; }
        DbSet<ChatMessage> ChatMessages { get; set; }
        DbSet<DailyGoal> DailyGoals { get; set; }
        DbSet<Balance> Balances { get; set; }
        //DbSet<BalanceHistory> BalanceHistories { get; set; }
        DbSet<Domain.Entities.AdminDetails> AdminDetails { get; set; }
        DbSet<Statement> Statements { get; set; }
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
