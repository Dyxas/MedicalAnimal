﻿using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            var card = e.Row.Item as AnimalCard;
            if (controller.GetList("", "").Count == AnimalCards.Count)
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
    }
}