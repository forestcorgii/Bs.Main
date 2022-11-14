using Bs.MasterlistModule.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bs.MasterlistModule.FrontEnd
{
    public static class Builder
    {
        public static ServiceCollection AddMasterlistModule(this ServiceCollection services, IConfigurationRoot conf)
        {
            string connectionString = conf.GetConnectionString("Default");
            services.AddSingleton<IDbContextFactory<MasterlistDbContext>>(new MasterlistDbContextFactory(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IDbContextFactory<MasterlistDbContext> timesheetDbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<MasterlistDbContext>>();
            using (MasterlistDbContext dbContext = timesheetDbContextFactory.CreateDbContext())
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
