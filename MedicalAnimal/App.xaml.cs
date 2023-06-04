using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static IServiceProvider serviceProvider;
        [STAThread]
        public static void Main()
        {

            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<App>();
                services.AddSingleton<DatabaseContext>();
                services.AddTransient<ICard<AnimalCard>, AnimalCardController>(e => new AnimalCardController(e.GetService<DatabaseContext>()));
                services.AddSingleton<AnimalCardsWindow>(e => new AnimalCardsWindow(e.GetService<ICard<AnimalCard>>()));
            }).Build();
            serviceProvider = host.Services;
            var app = serviceProvider.GetService<App>();
            app.InitializeComponent();
            app.Run();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<AnimalCardsWindow>();
            mainWindow.Show();
        }
    }

}
