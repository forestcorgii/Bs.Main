using Bs.Common;
using Bs.Main.Persistence.DbContexts;
using Bs.Main.Modules.VoucherModule.ServiceLayer.EfCore;
using Bs.Main.Modules.VoucherModule.Models;
using Bs.Main.Modules.VoucherModule.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Bs.Main.Modules.VoucherModule.ServiceLayer.Files;

namespace Bs.Main.Modules.VoucherModule
{
    public static class Builder
    {
        public static ServiceCollection AddVoucherModule(this ServiceCollection services, IConfigurationRoot conf)
        {
            string connectionString = conf.GetConnectionString("Default");
            services.AddSingleton<IDbContextFactory<MainContext>>(new MainDbContextFactory(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IDbContextFactory<MainContext> timesheetDbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<MainContext>>();
            using (MainContext dbContext = timesheetDbContextFactory.CreateDbContext())
                dbContext.Database.Migrate();


            services.AddSingleton<Vouchers>();

            services.AddSingleton<VoucherManager>();
            services.AddSingleton<VoucherProvider>();
            services.AddSingleton<VoucherPrinter>();


            services.AddTransient<VoucherListingVm>();
            services.AddSingleton<Func<VoucherListingVm>>((s) => () => s.GetRequiredService<VoucherListingVm>());
            services.AddSingleton<NavigationService<VoucherListingVm>>();

            services.AddTransient<VoucherDetailVm>();
            services.AddSingleton<Func<VoucherDetailVm>>((s) => () => s.GetRequiredService<VoucherDetailVm>());
            services.AddSingleton<NavigationService<VoucherDetailVm>>();


            return services;
        }
    }
}
