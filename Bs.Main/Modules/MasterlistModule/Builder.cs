using Bs.Common;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ViewModels;
using Bs.Main.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bs.Main.Modules.MasterlistModule
{
    public static class Builder
    {
        public static ServiceCollection AddMasterlistModule(this ServiceCollection services, IConfigurationRoot conf)
        {
            string connectionString = conf.GetConnectionString("Default");
            services.AddSingleton<IDbContextFactory<MainContext>>(new MainDbContextFactory(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IDbContextFactory<MainContext> timesheetDbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<MainContext>>();
            using (MainContext dbContext = timesheetDbContextFactory.CreateDbContext())
                dbContext.Database.Migrate();


            services.AddSingleton<Companies>();
            services.AddSingleton<CompanyAccounts>();
            services.AddSingleton<JournalAccounts>();
            services.AddSingleton<Payees>();
            services.AddSingleton<PayeeAccounts>();


            services.AddSingleton<CompanyManager>();
            services.AddSingleton<CompanyAccountManager>();
            services.AddSingleton<PayeeManager>();
            services.AddSingleton<PayeeAccountManager>();
            services.AddSingleton<JournalAccountManager>();


            services.AddSingleton<CompanyListingVm>();
            services.AddSingleton<Func<CompanyListingVm>>((s) => () => s.GetRequiredService<CompanyListingVm>());
            services.AddSingleton<NavigationService<CompanyListingVm>>();

            services.AddSingleton<CompanyAccountListingVm>();
            services.AddSingleton<Func<CompanyAccountListingVm>>((s) => () => s.GetRequiredService<CompanyAccountListingVm>());
            services.AddSingleton<NavigationService<CompanyAccountListingVm>>();


            return services;
        }
    }
}
