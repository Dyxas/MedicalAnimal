using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Shapes;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class InspectionCardsWindow : Page
    {
        ICard<InspectionCard> controller;
        public ObservableCollection<InspectionCard> InspectionCards { get; set; }

        public InspectionCardsWindow(ICard<InspectionCard> controller)
        {
            this.controller = controller;
            InitializeComponent();
            InspectionCards = controller.GetObservableList("");
            InspectionCardsGrid.ItemsSource = InspectionCards;
            animalList.ItemsSource = App.serviceProvider.GetService<DatabaseContext>().AnimalCards.Local;
            vetList.ItemsSource = App.serviceProvider.GetService<DatabaseContext>().OrganizationCards.Local;
            contractList.ItemsSource = App.serviceProvider.GetService<DatabaseContext>().ContractCards.Local;
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as InspectionCard;
            if (!InspectionCardValidationRule.Validate(card).IsValid)
            {
                return;
            }
            if (controller.GetList("").Count == InspectionCards.Count)
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
                    InspectionCard[] items = new InspectionCard[InspectionCardsGrid.SelectedItems.Count];
                    InspectionCardsGrid.SelectedItems.CopyTo(items, 0);
                    foreach (var item in items)
                    {
                        controller.Delete(item);
                    }
                }
                e.Handled = true;
            }
        }

        private void OnReport(object sender, RoutedEventArgs e)
        {
            controller.ExportExcel(InspectionCardsGrid.SelectedItem as InspectionCard);
        }
    }

    public class InspectionCardValidationRule : ValidationRule
    {
        public InspectionCardValidationRule() { }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            InspectionCard card = (value as BindingGroup).Items[0] as InspectionCard;
            return Validate(card);
        }
        static public ValidationResult Validate(InspectionCard card)
        {
            if (card.Temperature == 0)
            {
                return new ValidationResult(false, "Температура не указана");
            }
            if (card.VetClinic == null)
            {
                return new ValidationResult(false, "Ветклиника не указана");
            }
            if (card.Animal == null)
            {
                return new ValidationResult(false, "Животное не указано");
            }
            if (string.IsNullOrEmpty(card.UniqueBehavior))
            {
                return new ValidationResult(false, "Особенности поведения не указаны");
            }
            if (string.IsNullOrEmpty(card.HealthStatus))
            {
                return new ValidationResult(false, "Состояние животного не указано");
            }
            if (string.IsNullOrEmpty(card.Skin))
            {
                return new ValidationResult(false, "Кожные покровы не указаны");
            }
            if (string.IsNullOrEmpty(card.FurStatus))
            {
                return new ValidationResult(false, "Состояние шерсти не указано");
            }
            if (string.IsNullOrEmpty(card.HealthDeviations))
            {
                return new ValidationResult(false, "Ранения, травмы и.т.д не указаны");
            }
            if (string.IsNullOrEmpty(card.Diagnosis))
            {
                return new ValidationResult(false, "Диагноз не указан");
            }
            if (string.IsNullOrEmpty(card.CompletedOperations))
            {
                return new ValidationResult(false, "Выполненые операции не указаны");
            }
            if (string.IsNullOrEmpty(card.SpecialistFullName))
            {
                return new ValidationResult(false, "Фио вет.специалиста не указан");
            }
            if (string.IsNullOrEmpty(card.SpecialistDegree))
            {
                return new ValidationResult(false, "Специальность вет.специалиста не указан");
            }
            if (card.Contract == null)
            {
                return new ValidationResult(false, "Контракт не указан");
            }
            if (card.Date == new DateTime())
            {
                return new ValidationResult(false, "Укажите дату");
            }

            return ValidationResult.ValidResult;
        }
    }
}
