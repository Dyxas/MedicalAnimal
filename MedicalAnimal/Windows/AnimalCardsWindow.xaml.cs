using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для AnimalCardsWindow.xaml
    /// </summary>
    public partial class AnimalCardsWindow : Page
    {
        ICard<AnimalCard> controller;
        UserController userController;
        public ObservableCollection<AnimalCard> AnimalCards { get; set; }
        public AnimalCardsWindow()
        {
            InitializeComponent();
        }
        internal AnimalCardsWindow(ICard<AnimalCard> controller, UserController userController)
        {
            this.controller = controller;
            this.userController = userController;
            InitializeComponent();

            AnimalCardsGrid.CanUserAddRows = false;
            AnimalCardsGrid.CanUserDeleteRows = false;
            AnimalCardsGrid.IsReadOnly = true;

            var permissions = userController.GetUserInfo().Role.AnimalAccess;
            if (permissions >= 1)
            {
                AnimalCards = controller.GetObservableList("");
                AnimalCardsGrid.ItemsSource = AnimalCards;

                if (permissions == 2)
                {
                    AnimalCardsGrid.CanUserAddRows = true;
                    AnimalCardsGrid.CanUserDeleteRows = true;
                    AnimalCardsGrid.IsReadOnly = false;
                }
            }   
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as AnimalCard;
            if (!AnimalCardValidationRule.Validate(card).IsValid)
            {
                return;
            }
            if (controller.GetList("").Count == AnimalCards.Count)
            {
                controller.Edit(card);
            }
            else
            {
                controller.Add(card);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key ==  System.Windows.Input.Key.Delete)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    AnimalCard[] items = new AnimalCard[AnimalCardsGrid.SelectedItems.Count];
                    AnimalCardsGrid.SelectedItems.CopyTo(items, 0);
                    foreach (var item in items)
                    {
                        controller.Delete(item as AnimalCard);
                    }
                }
                e.Handled = true;
            }
        }

        private void OnReport(object sender, RoutedEventArgs e)
        {
            controller.ExportExcel(AnimalCardsGrid.SelectedItem as AnimalCard);
        }

        private void OnPickImage(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            var path = dialog.FileName;
            var card = AnimalCardsGrid.SelectedItem as AnimalCard;
            if (path != null)
            {
                card.Picture = path;
            }
        }

        private void OnFilter(object sender, RoutedEventArgs e)
        {
            AnimalCards.Clear();
            var city = TextBoxCity.Text;
            var sex = TextBoxSex.Text;
            var list = controller.GetList("").Where(item => {
                return (!string.IsNullOrEmpty(city) && item.City == city) || (!string.IsNullOrEmpty(sex) && item.Sex == sex);
            });
            foreach(var item in list)
            {
                AnimalCards.Add(item);
            }
        }

        private void OnResetFilter(object sender, RoutedEventArgs e)
        {
            AnimalCards.Clear();
            var list = controller.GetList("");
            foreach (var item in list)
            {
                AnimalCards.Add(item);
            }

        }
    }
    public class AnimalCardValidationRule : ValidationRule
    {
        public AnimalCardValidationRule() { }  
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            AnimalCard card = (value as BindingGroup).Items[0] as AnimalCard;
            return Validate(card);
        }
        static public ValidationResult Validate(AnimalCard card)
        {
            if (string.IsNullOrEmpty(card.City))
            {
                return new ValidationResult(false, "Город не указан");
            }
            if (string.IsNullOrEmpty(card.Picture))
            {
                return new ValidationResult(false, "Картинки нет");
            }
            if (card.ChipId <= 0)
            {
                return new ValidationResult(false, "Номер чипа не задан");
            }
            if (card.Birthday == new DateTime())
            {
                return new ValidationResult(false, "Дата не указана");
            }
            if (string.IsNullOrEmpty(card.Name))
            {
                return new ValidationResult(false, "Имя не указано");
            }
            if (card.RegistrationNumber <= 0)
            {
                return new ValidationResult(false, "Номер регистрации не указан");
            }
            if (string.IsNullOrEmpty(card.Sex))
            {
                return new ValidationResult(false, "Пол не указан");
            }
            return ValidationResult.ValidResult;
        }
    }
}
