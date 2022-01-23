using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartKraken.Data.Factories;
using PartKraken.Interfaces;
using PartKraken.Navigation;
using PartKraken.Services;
using PartKraken.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PartKraken
{

    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddTransient<AppDbContextFactory>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<Navigator>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            base.OnExit(e);
        }
    }
}
