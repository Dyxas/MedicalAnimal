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
    }
}
