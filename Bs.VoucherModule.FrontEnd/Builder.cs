using Bs.Common;
using Bs.VoucherModule.Domain.DbContexts;
using Bs.VoucherModule.Domain.ServiceLayer.EfCore;
using Bs.VoucherModule.FrontEnd.Models;
using Bs.VoucherModule.FrontEnd.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bs.VoucherModule.FrontEnd
{
    public static class Builder
    {
        public static ServiceCollection AddVoucherModule(this ServiceCollection services, IConfigurationRoot conf)
        {
            string connectionString = conf.GetConnectionString("Default");
            services.AddSingleton<IDbContextFactory<VoucherDbContext>>(new VoucherDbContextFactory(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IDbContextFactory<VoucherDbContext> timesheetDbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<VoucherDbContext>>();
            using (VoucherDbContext dbContext = timesheetDbContextFactory.CreateDbContext())
                dbContext.Database.Migrate();


            services.AddSingleton<Companies>();
            services.AddSingleton<CompanyAccounts>();
            services.AddSingleton<JournalAccounts>();
            services.AddSingleton<Vouchers>();
            services.AddSingleton<PayeeAccounts>();


            services.AddSingleton<VoucherManager>();
            services.AddSingleton<VoucherProvider>();
            services.AddSingleton<CompanyProvider>();
            services.AddSingleton<CompanyAccountProvider>();
            services.AddSingleton<PayeeProvider>();
            services.AddSingleton<PayeeAccountProvider>();
            services.AddSingleton<JournalAccountProvider>();


            services.AddSingleton<VoucherListingVm>();
            services.AddSingleton<Func<VoucherListingVm>>((s) => () => s.GetRequiredService<VoucherListingVm>());
            services.AddSingleton<NavigationService<VoucherListingVm>>();

            services.AddSingleton<VoucherDetailVm>();
            services.AddSingleton<Func<VoucherDetailVm>>((s) => () => s.GetRequiredService<VoucherDetailVm>());
            services.AddSingleton<NavigationService<VoucherDetailVm>>();


            return services;
        }
    }
}
