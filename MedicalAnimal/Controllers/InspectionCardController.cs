using MedicalAnimal.DTO;
using MedicalAnimal.Models;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace MedicalAnimal.Controllers
{
    class InspectionCardController : ICard<InspectionCard>
    {
        DatabaseContext db;
        public InspectionCardController(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(InspectionCard card)
        {
            db.InspectionCards.Add(card);
            db.SaveChanges();
        }

        public void Delete(InspectionCard card)
        {
            db.InspectionCards.Remove(card);
            db.SaveChanges();
        }

        public void Edit(InspectionCard card)
        {
            db.InspectionCards.Attach(card);
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void ExportExcel(InspectionCard card)
        {
            try
            {
                var rows = GetList("").ToList().Select(e =>
                {
                    return new InspectionDTO(e);
                });
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Инспекция");
                    worksheet.Cells[1, 1].LoadFromCollection(rows, true);
                    var saveFileDialog = new SaveFileDialog
                    {
                        DefaultExt = "xlsx",
                        FileName = @"%UserProfile%\Desktop\Report-" + DateTime.Now.ToString().Replace(':', '_').Replace('.', '_')
                    };
                    saveFileDialog.ShowDialog();
                    var path = saveFileDialog.FileName;
                    if (path != null)
                    {
                        package.SaveAs(path);
                    }
                }
            }
            catch (Exception ex) { }

        }

        public InspectionCard Get(int id)
        {
            var card = db.InspectionCards.Where(animal => animal.Id == id).FirstOrDefault();
            return card;

        }

        public List<InspectionCard> GetList(string filter)
        {
            return db.InspectionCards.ToList();
        }

        public ObservableCollection<InspectionCard> GetObservableList(string filter)
        {
            db.InspectionCards.Load();
            return db.InspectionCards.Local;
        }
    }
}
