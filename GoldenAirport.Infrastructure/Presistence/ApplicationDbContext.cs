﻿using GoldenAirport.Application.Interfaces;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace GoldenAirport.Infrastructure.Presistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region Auth
        public DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region GoldenAirport Entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<CityTrip> CityTrips { get; set; }
        public DbSet<TripRegistration> TripRegistrations { get; set; }
        public DbSet<TripRegistrationEditing> TripRegistrationsEditing { get; set; }
        public DbSet<TripRegistrationDeleting> TripRegistrationsDeleting { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<AdultEditing> AdultsEditing { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<ChildEditing> ChildrenEditing { get; set; }
        public DbSet<WhyVisit> WhyVisits { get; set; }
        public DbSet<WhatIsIncluded> WhatAreIncluded { get; set; }
        public DbSet<Accessibility> Accessibilities { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackagePlan> PackagePlans { get; set; }
        public DbSet<PackageRegistration> PackageRegistrations { get; set; }
        public DbSet<PackageRegistrationEditing> PackageRegistrationsEditing { get; set; }
        public DbSet<PackageRegistrationDeleting> PackageRegistrationsDeleting { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<PaymentOptionTrip> PaymentOptionTrips { get; set; }
        public DbSet<PaymentOptionPackage> PaymentOptionPackages { get; set; }
        public DbSet<PaymentOptionEmployee> paymentOptionEmployee { get; set; }
        public DbSet<CityPackage> CityPackages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DailyGoal> DailyGoals { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<AdminDetails> AdminDetails { get; set; }
        public DbSet<Statement> Statements { get; set; }

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
