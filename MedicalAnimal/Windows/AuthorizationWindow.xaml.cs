using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAnimal.DTO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MedicalAnimal.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAnimal.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            AuthFormDTO authFormDTO = new AuthFormDTO { Login = inputLogin.Text, Password = inputPassword.Text };
            if (App.serviceProvider.GetService<UserController>().Auth(authFormDTO))
            {
                MessageBox.Show("Успешная авторизация");
                var cardsFrame = App.serviceProvider.GetService<MainWindow>();
                cardsFrame.Show();

                this.Close();
            } else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
