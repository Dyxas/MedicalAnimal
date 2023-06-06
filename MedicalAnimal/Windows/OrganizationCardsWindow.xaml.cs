using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для OrganizationCardsWindow.xaml
    /// </summary>
    public partial class OrganizationCardsWindow : Page
    {
        ICard<OrganizationCard> controller;
        public ObservableCollection<OrganizationCard> OrganizationCards { get; set; }
        public OrganizationCardsWindow(ICard<OrganizationCard> controller)
        {
            this.controller = controller;
            InitializeComponent();
            OrganizationCards = controller.GetObservableList("", "");
            OrganizationCardsGrid.ItemsSource = OrganizationCards;
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as OrganizationCard;
            if (controller.GetList("","").Count == OrganizationCards.Count)
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
    }
}
