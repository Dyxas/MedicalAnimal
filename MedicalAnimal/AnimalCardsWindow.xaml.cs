using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MedicalAnimal
{
    /// <summary>
    /// Логика взаимодействия для AnimalCardsWindow.xaml
    /// </summary>
    public partial class AnimalCardsWindow : Window
    {
        ICard<AnimalCard> controller;
        public ObservableCollection<AnimalCard> AnimalCards { get; set; }
        public AnimalCardsWindow(ICard<AnimalCard> controller)
        {
            this.controller = controller;
            InitializeComponent();
            AnimalCards = controller.GetObservableList("", "");
            AnimalCardsGrid.ItemsSource = AnimalCards;
        }


        private void OnEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var c = AnimalCardsGrid.Items[AnimalCardsGrid.Items.Count-1];
            var card = e.Row.Item as AnimalCard;
            controller.Add(card);
        }
    }
}
