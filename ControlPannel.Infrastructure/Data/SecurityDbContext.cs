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

    
    modelBuilder.HasSequence<int>("Seq_User", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

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


        entity.Property(u => u.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_User");

        entity.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);  

        entity.HasIndex(u => u.Email).IsUnique();
    });

    // UserRole

    modelBuilder.HasSequence<int>("Seq_UserRole", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<UserRole>(entity =>
    {
        entity.HasKey(ur => ur.Id);

        entity.Property(ur => ur.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_UserRole");

        entity.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //Permission

    modelBuilder.HasSequence<int>("Seq_Permission", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<Permission>(entity =>
    {
        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Permission");

        entity.HasOne(p => p.Actee)
            .WithMany(a => a.Permissions)
            .HasForeignKey(p => p.ActeeId)
            .OnDelete(DeleteBehavior.Cascade); 

        entity.HasOne(p => p.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    });

    //Actee
    
    modelBuilder.HasSequence<int>("Seq_Actee", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<Actee>(entity =>
    {
        entity.HasKey(a => a.Id);
        entity.Property(a => a.Uuid).IsRequired().HasMaxLength(40);
        entity.Property(a => a.Title).IsRequired().HasMaxLength(200);
        entity.Property(a => a.Description).HasMaxLength(1000);

        entity.Property(a => a.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Actee");

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


    //Service
    
    modelBuilder.HasSequence<int>("Seq_Service", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    
        modelBuilder.Entity<Service>(entity =>
    {
        entity.HasKey(s => s.Id);
        entity.Property(s => s.ServiceKey).IsRequired().HasMaxLength(100);
        entity.Property(s => s.Rest).HasMaxLength(100);

        entity.Property(s => s.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Service");

        entity.HasOne(s => s.Actee)
            .WithMany(a => a.Services)
            .HasForeignKey(s => s.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //Menu
    
    modelBuilder.HasSequence<int>("Seq_Menu", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<Menu>(entity =>
    {
        entity.HasKey(m => m.Id);
        entity.Property(m => m.MenuKey).IsRequired().HasMaxLength(100);
        entity.Property(m => m.Icon).HasMaxLength(100);

        entity.Property(m => m.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Menu");

        entity.HasOne(m => m.Actee)
            .WithMany(a => a.Menus)
            .HasForeignKey(m => m.ActeeId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //Mask
    
    modelBuilder.HasSequence<int>("Seq_Mask", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<Mask>(entity =>
    {
        entity.HasKey(m => m.Id);

        entity.Property(m => m.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Mask");

        entity.HasOne(m => m.Permission)
            .WithMany()
            .HasForeignKey(m => m.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //ApplicationPackage
    
    modelBuilder.HasSequence<int>("Seq_ApplicationPackage", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<ApplicationPackage>(entity =>
    {
        entity.HasKey(ap => ap.Id);

        entity.Property(ap => ap.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_ApplicationPackage");

        entity.HasOne(ap => ap.Application)
            .WithMany(a => a.ApplicationPackages)
            .HasForeignKey(ap => ap.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //ConfigurationLock
    
    modelBuilder.HasSequence<int>("Seq_ConfigurationLock", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<ConfigurationLock>(entity =>
    {

        entity.Property(cl => cl.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_ConfigurationLock");

        entity.HasKey(cl => cl.Id);
        entity.HasOne(cl => cl.Application)
            .WithMany(a => a.ConfigurationLocks)
            .HasForeignKey(cl => cl.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //ConfigurationSession
    
    modelBuilder.HasSequence<int>("Seq_ConfigurationSession", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<ConfigurationSession>(entity =>
    {

        entity.Property(cs => cs.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_ConfigurationSession");


        entity.HasKey(cs => cs.Id);
        entity.HasOne(cs => cs.Application)
            .WithMany(a => a.ConfigurationSessions)
            .HasForeignKey(cs => cs.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //ConfigurationPassword
    
    modelBuilder.HasSequence<int>("Seq_ConfigurationPassword", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<ConfigurationPassword>(entity =>
    {

        entity.Property(cp => cp.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_ConfigurationPassword");


        entity.HasKey(cp => cp.Id);
        entity.HasOne(cp => cp.Application)
            .WithMany(a => a.ConfigurationPasswords)
            .HasForeignKey(cp => cp.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });

    //Application
    
    modelBuilder.HasSequence<int>("Seq_Application", schema: "dbo")
        .StartsAt(1)
        .IncrementsBy(1);

    modelBuilder.Entity<Aplication>(entity =>
    {
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Application");

        entity.HasMany(a => a.Roles)
            .WithOne(r => r.Application)
            .HasForeignKey(r => r.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(a => a.ApplicationPackages)
            .WithOne(ap => ap.Application)
            .HasForeignKey(ap => ap.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    });





}
    }


