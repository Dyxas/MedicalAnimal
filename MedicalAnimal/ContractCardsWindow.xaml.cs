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
        public ObservableCollection<ContractCard> ContractCards { get; set; }
        public ContractCardsWindow(ICard<ContractCard> controller)
        {
            this.controller = controller;
            InitializeComponent();
            ContractCards = controller.GetObservableList("", "");
            ContractCardsGrid.ItemsSource = ContractCards;
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as ContractCard;
            if (!ContractCardValidationRule.Validate(card).IsValid)
            {
                return;
            }
            if (controller.GetList("","").Count == ContractCards.Count)
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
