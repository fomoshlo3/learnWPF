using CommunityToolkit.Mvvm.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LAP.Data;
using LAP.Resource;
using LAP.ViewModels;
using LAP.Views;
using Microsoft.EntityFrameworkCore;

namespace LAP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHost();
        }

        private static IHost CreateHost()
        {
            return Host.CreateDefaultBuilder()
                        .ConfigureServices((hostContext, services) =>
                        {
                            var connString = hostContext.Configuration.GetConnectionString("Default");

                            services.AddDbContextFactory<LAPDbContext>(options => options.UseSqlServer(connString));

                            services.AddSingleton<MainWindow>(serviceProvider => new()
                            {
                                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                            });

                            services.AddSingleton<QueryTabViewModel>();
                            services.AddSingleton<SettingsViewModel>();

                            services.AddSingleton<INavigationManager, NavigationManager>();
                            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
                                                                            viewModelType =>
                                                                                (ViewModel)serviceProvider.GetRequiredService(viewModelType));
                            services.AddSingleton<MainViewModel>();

                        })
                        .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
