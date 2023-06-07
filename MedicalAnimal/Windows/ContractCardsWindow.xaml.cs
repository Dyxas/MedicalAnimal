using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для ContractCardWindow.xaml
    /// </summary>
    public partial class ContractCardsWindow : Page
    {
        ICard<ContractCard> controller;
        UserController UserController;
        public ObservableCollection<ContractCard> ContractCards { get; set; }
        internal ContractCardsWindow(ICard<ContractCard> controller, UserController userController)
        {
            this.controller = controller;
            UserController = userController;
            InitializeComponent();

            ContractCardsGrid.CanUserAddRows = false;
            ContractCardsGrid.CanUserDeleteRows = false;
            ContractCardsGrid.IsReadOnly = true;

            var permissions = userController.GetUserInfo().Role.ContractAccess;
            if (permissions >= 1)
            {
                ContractCards = controller.GetObservableList("");
                ContractCardsGrid.ItemsSource = ContractCards;

                if (permissions == 2)
                {
                    ContractCardsGrid.IsReadOnly = false;
                    ContractCardsGrid.CanUserAddRows = true;
                    ContractCardsGrid.CanUserDeleteRows = true;
                }
            }
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as ContractCard;
            if (!ContractCardValidationRule.Validate(card).IsValid)
            {
                return;
            }
            if (controller.GetList("").Count == ContractCards.Count)
            {
                controller.Edit(card);
            }
            else
            {
                controller.Add(card);
            }
        }

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key ==  System.Windows.Input.Key.Delete)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ContractCard[] items = new ContractCard[ContractCardsGrid.SelectedItems.Count];
                    ContractCardsGrid.SelectedItems.CopyTo(items, 0);
                    foreach (var item in items)
                    {
                        controller.Delete(item as ContractCard);
                    }
                }
                e.Handled = true;
            }
        }

        private void OnReport(object sender, RoutedEventArgs e)
        {
            controller.ExportExcel(ContractCardsGrid.SelectedItem as ContractCard);
        }

        private void OnFilter(object sender, RoutedEventArgs e)
        {
            ContractCards.Clear();
            float.TryParse(TextBoxPriceMin.Text, out var priceMin);
            float.TryParse(TextBoxPriceMax.Text, out var priceMax);
            var list = controller.GetList("").Where(item => {
                return (priceMax != 0 && priceMin != 0 && item.Price <= priceMax && item.Price >= priceMin) ||
                (priceMax != 0 && priceMin == 0 && item.Price <= priceMax) ||
                (priceMin != 0 && priceMax == 0 && item.Price >= priceMin);
            });
            foreach (var item in list)
            {
                ContractCards.Add(item);
            }
        }

        private void OnResetFilter(object sender, RoutedEventArgs e)
        {
            ContractCards.Clear();
            var list = controller.GetList("");
            foreach (var item in list)
            {
                ContractCards.Add(item);
            }

        }
    }

    public class ContractCardValidationRule : ValidationRule
    {
        public ContractCardValidationRule() { }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ContractCard card = (value as BindingGroup).Items[0] as ContractCard;
            return Validate(card);
        }
        static public ValidationResult Validate(ContractCard card)
        {
            if (string.IsNullOrEmpty(card.Number))
            {
                return new ValidationResult(false, "Не указан номер");
            }
            if (card.Price <= 0)
            {
                return new ValidationResult(false, "Не указана цена");
            }
            if (card.StartDate == new DateTime())
            {
                return new ValidationResult(false, "Начальная дата не указана");
            }
            if (card.EndDate== new DateTime())
            {
                return new ValidationResult(false, "Конечная дата не указана");
            }
            if (string.IsNullOrEmpty(card.Customer))
            {
                return new ValidationResult(false, "Потребитель не указан");
            }
            if (string.IsNullOrEmpty(card.Executor))
            {
                return new ValidationResult(false, "Исполнитель не найден");
            }
            return ValidationResult.ValidResult;
        }
    }
}
