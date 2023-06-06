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
        public MainWindow()
        {
            InitializeComponent();
            CardsFrame.Navigate(App.serviceProvider.GetService<AnimalCardsWindow>());
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
