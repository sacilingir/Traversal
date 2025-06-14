﻿using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>(); //Boş bir DestinationModel listesi oluşturulur.
            using (var c = new Context()) //Veritabanına bağlanmak için bir Context nesnesi kullanılır.
                                          // Veritabanı 'Destinations' tablosundaki verileri çeker.
                                          // Her bir kayıt bir 'DestinationModel' nesnesine dönüştürülür.
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel 
                {
                    City=x.City,
                    DayNight=x.DayNight,
                    Price=x.Price,
                    Capacity=x.Capacity,
                }).ToList();
            }
            return destinationModels;

        }
        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 3].Value = "Kontenjan";

            workSheet.Cells[2, 1].Value = "Gürcistan Batum";
            workSheet.Cells[2, 2].Value = "Duru Açıcı ";
            workSheet.Cells[2, 3].Value = "20";

            workSheet.Cells[3, 1].Value = "Kıbrıs Girne";
            workSheet.Cells[3, 2].Value = "Zeynep Cebeci";
            workSheet.Cells[3, 3].Value = "30";

            var bytes = excel.GetAsByteArray();


            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                var rowCount = 2;

                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount,1).Value = item.City;
                    workSheet.Cell(rowCount,2).Value = item.DayNight;
                    workSheet.Cell(rowCount,3).Value = item.Price;
                    workSheet.Cell(rowCount,4).Value = item.Capacity;
                        rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
                
            }
        }





    }
}
