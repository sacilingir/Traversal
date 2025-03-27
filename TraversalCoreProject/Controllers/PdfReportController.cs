using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
            //İlk argüman: Dosya yolu 
            //İkinci argüman: MIME türü - "application/pdf", bu, tarayıcıya dosyanın bir PDF olduğunu belirtir.
            //Üçüncü argüman: Kullanıcıya indirilecek dosyanın adı - "dosya1.pdf", kullanıcı bu dosyayı bu ad ile indirecektir.
        }



        public IActionResult StaticCustomerReport()
        {
           
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir TC");

            pdfTable.AddCell("Nazlı");
            pdfTable.AddCell("Cebeci");
            pdfTable.AddCell("11111111111");

            pdfTable.AddCell("Emir");
            pdfTable.AddCell("Cebeci");
            pdfTable.AddCell("22222222222");

            pdfTable.AddCell("Zeynep");
            pdfTable.AddCell("Cebeci");
            pdfTable.AddCell("33333333333");

            document.Add(pdfTable);

            document.Close();

            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");

        }
    }
}
