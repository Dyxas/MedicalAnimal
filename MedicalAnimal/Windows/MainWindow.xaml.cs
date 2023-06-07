using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using MedicalAnimal.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserController userController;
        public MainWindow()
        {
            InitializeComponent();
        }
        internal MainWindow(UserController userController)
        {
            this.userController = userController;
            InitializeComponent();
            var animalAccess = userController.GetUserInfo().Role.AnimalAccess;
            var organizationAccess = userController.GetUserInfo().Role.OrganizationAccess;
            var contractAccess = userController.GetUserInfo().Role.ContractAccess;

            if (animalAccess == 0)
            {
                AnimalButton.IsEnabled = false;
            } else
            {
                CardsFrame.Navigate(App.serviceProvider.GetService<AnimalCardsWindow>());
            }
            if (organizationAccess == 0)
            {
                OrganizationButton.IsEnabled = false;
            } else
            {
                CardsFrame.Navigate(App.serviceProvider.GetService<OrganizationCardsWindow>());
            }
            if (contractAccess == 0)
            {
                ContractButton.IsEnabled = false;
            }else
            {
                CardsFrame.Navigate(App.serviceProvider.GetService<ContractCardsWindow>());
            }

        }
            CardsFrame.Navigate(App.serviceProvider.GetService<AnimalCardsWindow>());
            App.serviceProvider.GetService<OrganizationCardsWindow>().BeginInit();
            App.serviceProvider.GetService<ContractCardsWindow>().BeginInit();
        }

        private void OnAnimalClick(object sender, RoutedEventArgs e)
        {
            CardsFrame.Navigate(App.serviceProvider.GetService<AnimalCardsWindow>());
        }
        private void OnOrganizationClick(object sender, RoutedEventArgs e)
        {
            CardsFrame.Navigate(App.serviceProvider.GetService<OrganizationCardsWindow>());
        }
        private void OnContractsClick(object sender, RoutedEventArgs e)
        {
            CardsFrame.Navigate(App.serviceProvider.GetService<ContractCardsWindow>());
        }

        private void OnInspectionClick(object sender, RoutedEventArgs e)
        {
            CardsFrame.Navigate(App.serviceProvider.GetService<InspectionCardsWindow>());
        }
    }
}
