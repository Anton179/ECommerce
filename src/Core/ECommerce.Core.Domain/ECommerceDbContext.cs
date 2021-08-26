using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.EFConfiguration;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Schemas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;

namespace ECommerce.Core.DataAccess
{
    public class ECommerceDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<CharacteristicValue> CharacteristicsValue { get; set; }
        public DbSet<CharacteristicDecimalType> CharacteristicsDecimal { get; set; }
        public DbSet<CharacteristicIntType> CharacteristicsInt { get; set; }
        public DbSet<CharacteristicDateType> CharacteristicsDate { get; set; }
        public DbSet<CharacteristicStringType> CharacteristicsString { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(ProductConfiguration).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            // TODO: Remove
            //modelBuilder.Entity<CharacteristicDecimalType>().ToTable("CharacteristicDecimalType");
            //modelBuilder.Entity<CharacteristicIntType>().ToTable("CharacteristicIntType");
            //modelBuilder.Entity<CharacteristicDateType>().ToTable("CharacteristicDateType");
            //modelBuilder.Entity<CharacteristicStringType>().ToTable("CharacteristicStringType");

            ApplyIdentityMapConfiguration(modelBuilder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", IdentitySchemas.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", IdentitySchemas.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", IdentitySchemas.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", IdentitySchemas.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", IdentitySchemas.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", IdentitySchemas.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", IdentitySchemas.Auth);
        }
    }
}
