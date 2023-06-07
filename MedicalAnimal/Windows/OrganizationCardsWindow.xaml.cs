using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для OrganizationCardsWindow.xaml
    /// </summary>
    public partial class OrganizationCardsWindow : Page
    {
        ICard<OrganizationCard> controller;
        UserController UserController;
        public ObservableCollection<OrganizationCard> OrganizationCards { get; set; }
        internal OrganizationCardsWindow(ICard<OrganizationCard> controller, UserController userController)
        {
            this.controller = controller;
            this.UserController = userController;
            InitializeComponent();
            OrganizationCardsGrid.CanUserAddRows = false;
            OrganizationCardsGrid.CanUserDeleteRows = false;
            OrganizationCardsGrid.IsReadOnly = true;

            var permissions = userController.GetUserInfo().Role.OrganizationAccess;
            if (permissions >= 1)
            {
                OrganizationCards = controller.GetObservableList("");
                OrganizationCardsGrid.ItemsSource = OrganizationCards;

                if (permissions == 2)
                {
                    OrganizationCardsGrid.IsReadOnly = false;
                    OrganizationCardsGrid.CanUserAddRows = true;
                    OrganizationCardsGrid.CanUserDeleteRows = true;
                }
            }
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as OrganizationCard;
            if (!OrganizationCardValidationRule.Validate(card).IsValid)
            {
                return;
            }
            if (controller.GetList("").Count == OrganizationCards.Count)
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
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    OrganizationCard[] items = new OrganizationCard[OrganizationCardsGrid.SelectedItems.Count];
                    OrganizationCardsGrid.SelectedItems.CopyTo(items, 0);
                    foreach (var item in items)
                    {
                        controller.Delete(item as OrganizationCard);
                    }
                }
                e.Handled = true;
            }
        }
        private void OnReport(object sender, RoutedEventArgs e)
        {
            controller.ExportExcel(OrganizationCardsGrid.SelectedItem as OrganizationCard);
        }

        private void OnFilter(object sender, RoutedEventArgs e)
        {
            OrganizationCards.Clear();
            var organizationType = TextBoxOrganizationType.Text;
            var list = controller.GetList("").Where(item =>
            {
                return item.OrganizationType == organizationType;
            });
            foreach (var item in list)
            {
                OrganizationCards.Add(item);
            }
        }

        private void OnResetFilter(object sender, RoutedEventArgs e)
        {

            OrganizationCards.Clear();
            var list = controller.GetList("");
            foreach (var item in list)
            {
                OrganizationCards.Add(item);
            }
        }
    }

    public class OrganizationCardValidationRule : ValidationRule
    {
        public OrganizationCardValidationRule() { }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            OrganizationCard card = (value as BindingGroup).Items[0] as OrganizationCard;
            return Validate(card);
        }
        static public ValidationResult Validate(OrganizationCard card)
        {
            if (string.IsNullOrEmpty(card.Kpp))
            {
                return new ValidationResult(false, "КПП не указан");
            }
            if (string.IsNullOrEmpty(card.Inn))
            {
                return new ValidationResult(false, "ИНН не указан");
            }
            if (string.IsNullOrEmpty(card.Address))
            {
                return new ValidationResult(false, "Адрес не указано");
            }
            if (string.IsNullOrEmpty(card.Name))
            {
                return new ValidationResult(false, "Название не указано");
            }
            if (string.IsNullOrEmpty(card.OwnerType))
            {
                return new ValidationResult(false, "Владелец не указан");
            }
            if (string.IsNullOrEmpty(card.OrganizationType))
            {
                return new ValidationResult(false, "Тип организации не указан");
            }
            return ValidationResult.ValidResult;
        }
    }
}
