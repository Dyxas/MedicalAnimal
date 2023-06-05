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
    class ContractCardController : ICard<ContractCard>, IExport<ContractCard>
    {
        DatabaseContext db;
        public ContractCardController(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(ContractCard card)
        {
            db.ContractCards.Add(card);
            db.SaveChanges();
        }

        public void Delete(ContractCard card)
        {
            db.ContractCards.Remove(card);
            db.SaveChanges();
        }

        public void Edit(ContractCard card)
        {
            db.ContractCards.Attach(card);
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
        }

        public ContractCard ExportExcel(ContractCard card)
        {
            throw new NotImplementedException();
        }

        public ContractCard Get(int id)
        {
            var card = db.ContractCards.Where(organization => organization.Id == id).FirstOrDefault();
            return card;

        }

        public List<ContractCard> GetList(string filter, string order)
        {
            return db.ContractCards.ToList();
        }

        public ObservableCollection<ContractCard> GetObservableList(string filter, string order)
        {
            db.ContractCards.Load();
            return db.ContractCards.Local;
        }
    }
}
