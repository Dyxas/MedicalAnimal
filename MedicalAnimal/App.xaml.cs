using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using MedicalAnimal.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
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
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<App>();
                services.AddSingleton<DatabaseContext>();
                services.AddTransient<ICard<AnimalCard>, AnimalCardController>(e => new AnimalCardController(e.GetService<DatabaseContext>()));
                services.AddTransient<ICard<OrganizationCard>, OrganizationCardController>(e => new OrganizationCardController(e.GetService<DatabaseContext>()));
                services.AddTransient<ICard<ContractCard>, ContractCardController>(e => new ContractCardController(e.GetService<DatabaseContext>()));
                services.AddTransient<ICard<InspectionCard>, InspectionCardController>(e => new InspectionCardController(e.GetService<DatabaseContext>()));
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AuthorizationWindow>();
                services.AddSingleton<InspectionCardsWindow>();
                services.AddSingleton<AnimalCardsWindow>();
                services.AddSingleton<OrganizationCardsWindow>();
                services.AddSingleton<ContractCardsWindow>();
                services.AddSingleton<UserController>();
            }).Build();
            serviceProvider = host.Services;
            var app = serviceProvider.GetService<App>();
            app.InitializeComponent();
            app.Run();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var authorizationWindow = serviceProvider.GetService<AuthorizationWindow>();
            authorizationWindow.Show();
        }
    }

}
