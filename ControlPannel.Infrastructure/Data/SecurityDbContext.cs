using System;
using controlpannel.domain.Entities;
using controlpannel.domain.Enums;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ControlPannel.Infrastructure.Data;

 public class SecurityDbContext : DbContext
    {
    public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Actee> Actees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Mask> Masks { get; set; }
        public DbSet<ApplicationPackage> ApplicationPackages { get; set; }
        public DbSet<Aplication> Applications { get; set; }
        public DbSet<ConfigurationLock> ConfigurationLocks {get;set;}
        public DbSet<ConfigurationSession> ConfigurationSessions {get;set;}
        public DbSet<ConfigurationPassword> ConfigurationPasswords {get;set;}
        public DbSet<UserBiometric> UserBiometrics {get;set;}
        public DbSet<BiometricType> BiometricTypes {get;set;}
        public DbSet<OauthToken> OAuthTokens  {get;set;}
        public DbSet<UserProperty> UserProperties {get;set;}
        public DbSet<LoginPolicy> LoginPolicies {get;set;}
        public DbSet<Service> Services {get;set;}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(u => u.Id);
        entity.Property(u => u.Uuid).IsRequired().HasMaxLength(40);
        entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
        entity.Property(u => u.Mobile).HasMaxLength(20);
        entity.Property(u => u.NationalCode).HasMaxLength(50);
        entity.Property(u => u.Description).HasMaxLength(1000);

        entity.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);  

        entity.HasIndex(u => u.Email).IsUnique();
    });

    modelBuilder.Entity<UserRole>(entity =>
    {
        entity.HasKey(ur => ur.Id);

        entity.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<Permission>(entity =>
    {
        entity.HasKey(p => p.Id);

        entity.HasOne(p => p.Actee)
            .WithMany(a => a.Permissions)
            .HasForeignKey(p => p.ActeeId)
            .OnDelete(DeleteBehavior.Cascade); 

        entity.HasOne(p => p.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    });

    modelBuilder.Entity<Actee>(entity =>
    {
        entity.HasKey(a => a.Id);
        entity.Property(a => a.Uuid).IsRequired().HasMaxLength(40);
        entity.Property(a => a.Title).IsRequired().HasMaxLength(200);
        entity.Property(a => a.Description).HasMaxLength(1000);

        entity.HasMany(a => a.Permissions)
            .WithOne(p => p.Actee)
            .HasForeignKey(p => p.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(a => a.Menus)
            .WithOne(m => m.Actee)
            .HasForeignKey(m => m.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
 
        entity.HasMany(a=> a.Services)
            .WithOne(s => s.Actee)
            .HasForeignKey(s => s.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
    });



    
        modelBuilder.Entity<Service>(entity =>
    {
        entity.HasKey(s => s.Id);
        entity.Property(s => s.ServiceKey).IsRequired().HasMaxLength(100);
        entity.Property(s => s.Rest).HasMaxLength(100);

        entity.HasOne(s => s.Actee)
            .WithMany(a => a.Services)
            .HasForeignKey(s => s.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<Menu>(entity =>
    {
        entity.HasKey(m => m.Id);
        entity.Property(m => m.MenuKey).IsRequired().HasMaxLength(100);
        entity.Property(m => m.Icon).HasMaxLength(100);

        entity.HasOne(m => m.Actee)
            .WithMany(a => a.Menus)
            .HasForeignKey(m => m.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<Mask>(entity =>
    {
        entity.HasKey(m => m.Id);

        entity.HasOne(m => m.Permission)
            .WithMany()
            .HasForeignKey(m => m.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<ApplicationPackage>(entity =>
    {
        entity.HasKey(ap => ap.Id);

        entity.HasOne(ap => ap.Application)
            .WithMany(a => a.ApplicationPackages)
            .HasForeignKey(ap => ap.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<ConfigurationLock>(entity =>
    {
        entity.HasKey(cl => cl.Id);
        entity.HasOne(cl => cl.Application)
            .WithMany(a => a.ConfigurationLocks)
            .HasForeignKey(cl => cl.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<ConfigurationSession>(entity =>
    {
        entity.HasKey(cs => cs.Id);
        entity.HasOne(cs => cs.Application)
            .WithMany(a => a.ConfigurationSessions)
            .HasForeignKey(cs => cs.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<ConfigurationPassword>(entity =>
    {
        entity.HasKey(cp => cp.Id);
        entity.HasOne(cp => cp.Application)
            .WithMany(a => a.ConfigurationPasswords)
            .HasForeignKey(cp => cp.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<Aplication>(entity =>
    {
        entity.HasKey(a => a.Id);

        entity.HasMany(a => a.Roles)
            .WithOne(r => r.Application)
            .HasForeignKey(r => r.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(a => a.ApplicationPackages)
            .WithOne(ap => ap.Application)
            .HasForeignKey(ap => ap.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    DateTime specificTime = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc); 

modelBuilder.Entity<User>().HasData(
        new User(
            id: 1,
            uuid: "user-uuid-002",
            firstName: "John",
            lastName: "Doe",
            nationalCode: "9876543210",
            email: "john.doe@example.com",
            mobile: "09123456789",
            primaryKey: "john-primary-key",
            ipRange: "0.0.0.0",
            loginAttempt: 0,
            scheduled: "00:00-23:59",
            status: StatusTypes.Active,
            twoFactor: false,
            description: "Standard user",
            createDate: specificTime,
            modifyDate: specificTime,
            deleteDate: null,
            deleteUser: null,
            modifyUser: null
        )
    );
    modelBuilder.Entity<Aplication>().HasData(
    new Aplication(
        id: 1,
        title: "Main Application",
        clientId: "client-id-123",
        createDate: specificTime,
        modifyDate: specificTime,
        redirectUrls: "https://example.com/callback",
        clientScope: "openid profile",
        clientSecret: "super-secure-secret",
        authenticateGrantType: GrantType.AuthorizationCode,
        ipRange: "192.168.1.0/24",
        isAutoApprove: false,
        scheduled: "00:00-23:59",
        status: StatusTypes.Active,
        lockEnabled: true,
        description: "This is the main application for authentication"
    )
);
    modelBuilder.Entity<ConfigurationPassword>().HasData(
    new ConfigurationPassword(
        userProperties: new List<UserProperty>(), // Empty list initially
        createDate: new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
        modifyDate: new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
        deleteDate: new DateTime(9999, 12, 31), // No deletion
        deleteUser: null,
        modifyUser: null,
        id: 1,  // Ensure this ID matches the one referenced in UserProperty
        isComplex: false,
        mustBeChangedInFirstLogin: false,
        mustContainChar: false,
        mustContainUpperCase: false,
        isPolicyNeeded: false,
        minPassLength: 8,
        maxPassLength: 16,
        numericPassNotEqual: 2,
        willPassExpire: true,
        expireDaysAmount: 90,
        redirectToCustomUrlAfterChangePass: false,
        urlAfterChangePass: "https://example.com/password-changed",
        applicationId: 1, // Ensure this ApplicationId exists in Applications table
        twoFactorEnabled: true
    )
);

    modelBuilder.Entity<UserProperty>().HasData(
        new UserProperty(
            userId: 1,
            password: "securepassword123",
            configurationPasswordId: 1
        )
    );

    modelBuilder.Entity<LoginPolicy>().HasData(
        new LoginPolicy(
            id: 1,
            lockTypes: LockTypes.None,
            userId: 1,
            lockStartDateTime: specificTime,
            lockEndDateTime: specificTime.AddMinutes(30),
            createDate: specificTime,
            modifyDate: specificTime,
            deleteDate: null,
            deleteUser: null,
            modifyUser: null
        )
    );

    modelBuilder.Entity<UserRole>().HasData(
        new UserRole(
            id: 1,
            userId: 1,
            roleId: 1,
            isDefault: false,
            createDate: specificTime,
            modifyDate: specificTime,
            deleteDate: null,
            deleteUser: null,
            modifyUser: null
        )
    );
}
    }


