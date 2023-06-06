using MedicalAnimal.Models;
using Microsoft.Win32;
using OfficeOpenXml;
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

        public void ExportExcel(AnimalCard card)
        {
            try
            {
                var rows = GetList("");
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Животные");
                    worksheet.Cells[1, 1].LoadFromCollection(rows, true);
                    var saveFileDialog = new SaveFileDialog
                    {
                        DefaultExt = "xlsx",
                        FileName = @"%UserProfile%\Desktop\Report-" + DateTime.Now.ToString().Replace(':', '_').Replace('.', '_')
                    };
                    saveFileDialog.ShowDialog();
                    var path = saveFileDialog.FileName;
                    if(path != null)
                    {
                        package.SaveAs(path);
                    }
                }
            } catch (Exception ex) { }
            
        }

        public AnimalCard Get(int id)
        {
            var card = db.AnimalCards.Where(animal => animal.Id == id).FirstOrDefault();
            return card;

        }

        public List<AnimalCard> GetList(string filter)
        {
            return db.AnimalCards.ToList();
        }

        public ObservableCollection<AnimalCard> GetObservableList(string filter)
        {
            db.AnimalCards.Load();
            return db.AnimalCards.Local;
        }
    }
}
