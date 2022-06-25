using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BitsaFundingSystem.Areas.Identity.Data;
using BitsaFundingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitsaFundingSystem.Data
{
    public class BitsaFundingSystemContext : IdentityDbContext<BitsaFundingSystemUser>
    {
        public BitsaFundingSystemContext(DbContextOptions<BitsaFundingSystemContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.UseSqlite("Data Source=BitsaFundingSystem.db;");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entitytype in builder.Model.GetEntityTypes())
                {
                    var properties = entitytype.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    foreach (var property in properties)
                    {
                        //Converting decimal to double
                        builder.Entity(entitytype.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
