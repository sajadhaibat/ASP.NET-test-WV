using System;
using ASpNEtCoreMain.Areas.Identity.Data;
using ASpNEtCoreMain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASpNEtCoreMain.Areas.Identity.IdentityHostingStartup))]
namespace ASpNEtCoreMain.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASpNEtCoreMainIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CoreTestConnectionString")));

                services.AddDefaultIdentity<ASpNEtCoreMainUser>()
                    .AddEntityFrameworkStores<ASpNEtCoreMainIdentityContext>();
            });
        }
    }
}