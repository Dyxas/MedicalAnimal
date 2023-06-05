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
    class OrganizationCardController : ICard<OrganizationCard>, IExport<OrganizationCard>
    {
        DatabaseContext db;
        public OrganizationCardController(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(OrganizationCard card)
        {
            db.OrganizationCards.Add(card);
            db.SaveChanges();
        }

        public void Delete(OrganizationCard card)
        {
            db.OrganizationCards.Remove(card);
            db.SaveChanges();
        }

        public void Edit(OrganizationCard card)
        {
            db.OrganizationCards.Attach(card);
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
        }

        public OrganizationCard ExportExcel(OrganizationCard card)
        {
            throw new NotImplementedException();
        }

        public OrganizationCard Get(int id)
        {
            var card = db.OrganizationCards.Where(organization => organization.Id == id).FirstOrDefault();
            return card;

        }

        public List<OrganizationCard> GetList(string filter, string order)
        {
            return db.OrganizationCards.ToList();
        }

        public ObservableCollection<OrganizationCard> GetObservableList(string filter, string order)
        {
            db.OrganizationCards.Load();
            return db.OrganizationCards.Local;
        }
    }
}
