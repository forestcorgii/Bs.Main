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


            //services.AddSingleton<Companies>();
            //services.AddSingleton<CompanyAccounts>();
            //services.AddSingleton<JournalAccounts>();
            //services.AddSingleton<Vouchers>();
            //services.AddSingleton<PayeeAccounts>();


            //services.AddSingleton<VoucherManager>();
            //services.AddSingleton<VoucherProvider>();
            //services.AddSingleton<CompanyProvider>();
            //services.AddSingleton<CompanyAccountProvider>();
            //services.AddSingleton<PayeeProvider>();
            //services.AddSingleton<PayeeAccountProvider>();
            //services.AddSingleton<JournalAccountProvider>();


            //services.AddSingleton<VoucherListingVm>();
            //services.AddSingleton<Func<VoucherListingVm>>((s) => () => s.GetRequiredService<VoucherListingVm>());
            //services.AddSingleton<NavigationService<VoucherListingVm>>();

            //services.AddSingleton<VoucherDetailVm>();
            //services.AddSingleton<Func<VoucherListingVm>>((s) => () => s.GetRequiredService<VoucherListingVm>());
            //services.AddSingleton<NavigationService<VoucherListingVm>>();


            return services;
        }
    }
}
