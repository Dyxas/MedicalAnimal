using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider serviceProvider;
        [STAThread]
        public static void Main()
        {

            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<App>();
                services.AddSingleton<DatabaseContext>();
                services.AddTransient<ICard<AnimalCard>, AnimalCardController>(e => new AnimalCardController(e.GetService<DatabaseContext>()));
                services.AddTransient<ICard<OrganizationCard>, OrganizationCardController>(e => new OrganizationCardController(e.GetService<DatabaseContext>()));
                services.AddTransient<ICard<ContractCard>, ContractCardController>(e => new ContractCardController(e.GetService<DatabaseContext>()));
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AnimalCardsWindow>();
                services.AddSingleton<OrganizationCardsWindow>();
                services.AddSingleton<ContractCardsWindow>();
            }).Build();
            serviceProvider = host.Services;
            var app = serviceProvider.GetService<App>();
            app.InitializeComponent();
            app.Run();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
