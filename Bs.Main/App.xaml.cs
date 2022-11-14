using Bs.Common;
using Bs.Main.Modules.MainModule.ViewModels;
using Bs.Main.Modules.MasterlistModule;
using Bs.Main.Modules.VoucherModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bs.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App() => Services = ConfigureServices();


        public static IServiceProvider ConfigureServices()
        {
            IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            ServiceCollection services = new();
            services
                .AddMasterlistModule(conf)
                .AddVoucherModule(conf);


            services.AddSingleton<NavigationStore>();

            services.AddSingleton<MainVm>();
            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainVm>()
            });


            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
