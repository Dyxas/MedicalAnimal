using MedicalAnimal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.Controllers
{
    class AnimalCardController : ICard<AnimalCard>
    {
        DatabaseContext db;
        public AnimalCardController(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(AnimalCard card)
        {
            db.AnimalCards.Add(card);
            db.SaveChanges();
        }

        public void Delete(AnimalCard card)
        {
            db.AnimalCards.Remove(card);
            db.SaveChanges();
        }

        public void Edit(AnimalCard card)
        {
            db.AnimalCards.Attach(card);
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
        }

        public AnimalCard Get(int id)
        {
            var card = db.AnimalCards.Where(animal => animal.Id == id).FirstOrDefault();
            return card;

        }

        public List<AnimalCard> GetList(string filter, string order)
        {
            return db.AnimalCards.ToList();
        }

        public ObservableCollection<AnimalCard> GetObservableList(string filter, string order)
        {
            db.AnimalCards.Load();
            return db.AnimalCards.Local;
        }
    }
}
