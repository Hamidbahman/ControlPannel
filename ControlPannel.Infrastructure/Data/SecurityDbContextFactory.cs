using System;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using ControlPannel.Infrastructure.Data;

namespace controlpannel.infrastructure.Data;

    public class SecurityDbContextFactory : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        public SecurityDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SecurityDbContext>();
            var connectionString = configuration.GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionString);

            return new SecurityDbContext(optionsBuilder.Options);
        }
    }

