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

        public void ExportExcel(OrganizationCard card)
        {
            try
            {
                var rows = GetList("");
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Организации");
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

        public OrganizationCard Get(int id)
        {
            var card = db.OrganizationCards.Where(organization => organization.Id == id).FirstOrDefault();
            return card;

        }

        public List<OrganizationCard> GetList(string filter)
        {
            return db.OrganizationCards.ToList();
        }

        public ObservableCollection<OrganizationCard> GetObservableList(string filter)
        {
            db.OrganizationCards.Load();
            return db.OrganizationCards.Local;
        }
    }
}
