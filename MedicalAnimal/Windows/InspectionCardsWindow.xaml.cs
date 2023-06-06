using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var card = e.Row.Item as InspectionCard;
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
}
