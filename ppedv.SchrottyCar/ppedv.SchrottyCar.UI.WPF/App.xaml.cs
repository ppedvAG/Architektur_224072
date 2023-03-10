using Microsoft.Extensions.DependencyInjection;
using ppedv.SchrottyCar.Data.EfCore;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ppedv.SchrottyCar.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";

            var services = new ServiceCollection();

            services.AddScoped<IUnitOfWork, EfUnitOfWork>(x => new EfUnitOfWork(conString));
            services.AddScoped<CarsViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
