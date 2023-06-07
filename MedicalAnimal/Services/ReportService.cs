using MedicalAnimal.Controllers;
using MedicalAnimal.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.Services
{
    internal class ReportService
    {
        public void GetReport(DateTime start, DateTime end)
        {
            List<InspectionCard> cards = App.serviceProvider.GetService<DatabaseContext>().InspectionCards.Local.Where(a => a.Date >= start && a.Date <= end).ToList();
            cards.GroupBy(g => g.Animal.City);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Данные по осмотру");
                worksheet.Cells[1, 1].LoadFromCollection(cards, true);
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
    }
}
