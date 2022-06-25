using System;
using BitsaFundingSystem.Areas.Identity.Data;
using BitsaFundingSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BitsaFundingSystem.Areas.Identity.IdentityHostingStartup))]
namespace BitsaFundingSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<BitsaFundingSystemContext>(options =>
                //    options.UseSqlite(
                //        context.Configuration.GetConnectionString("BitsaFundingSystemContextConnection")));

                services.AddDefaultIdentity<BitsaFundingSystemUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BitsaFundingSystemContext>();
            });
        }
    }
}