using MedicalAnimal.Models;
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
            var frame = Content as Frame;
            if (frame.Content == null)
            {
                frame.Navigate(App.serviceProvider.GetService<AnimalCardsWindow>());
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         

        }
    }
}
