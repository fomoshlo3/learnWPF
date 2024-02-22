using CommunityToolkit.Mvvm.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace LAP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                        .ConfigureServices((hostContext, services) =>
                        {
                            var connString = hostContext.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException();
                        });
    }

}
