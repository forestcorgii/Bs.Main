using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Bs.CheckApp.Persistence;
using Bs.Main.FrontEnd.ChequeTracker.Views;
using Bs.Main.FrontEnd.ChequeTracker.ViewModels;
using Bs.Main.FrontEnd.ChequeTracker.Models;
using Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books;

namespace Bs.Main.FrontEnd.ChequeTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App() =>
            Services = ConfigureServices();


        private static IServiceProvider ConfigureServices()
        {
            IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            ServiceCollection services = new();
            string connectionString = conf.GetConnectionString("Default");
            services.AddSingleton<IDbContextFactory<ChequeDbContext>>(new ChequeDbContextFactory(connectionString));

            services.AddTransient<ChequeBooks>();
            services.AddTransient<Cheques>();

            services.AddSingleton<ChequeBookProvider>();
            services.AddSingleton<ChequeBookManager>();
            services.AddSingleton<ChequeBookGenerator>();


            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IDbContextFactory<ChequeDbContext> employeeDbContextFactory = Services.GetRequiredService<IDbContextFactory<ChequeDbContext>>();
            using (ChequeDbContext dbContext = employeeDbContextFactory.CreateDbContext())
                dbContext.Database.Migrate();


            MainWindow = new MainWindow() { DataContext = new MainViewModel() };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
