using Bs.Common;
using Bs.Main.Modules.MasterlistModule;
using Bs.Masterlists.FrontEnd.ViewModels;
using Bs.Masterlists.FrontEnd.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bs.Masterlists.FrontEnd
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
                .AddMasterlistModule(conf);


            services.AddSingleton<NavigationStore>();

            
            services.AddSingleton<MasterlistMainVm>();
            services.AddSingleton(s => new MasterlistMainView()
            {
                DataContext = s.GetRequiredService<MasterlistMainVm>()
            });


            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = Services.GetRequiredService<MasterlistMainView>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
