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

        public void ExportExcel(ContractCard card)
        {
            try
            {
                var rows = GetList("", "");
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Контракты");
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
