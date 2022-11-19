using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using WebApplicationReportNet7.Data;

namespace WebApplicationReportNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet("GetPdfFile")]
        public ActionResult GetPdfFile()
        {

            List<ReportItem> ResultAccountInvoice = new List<ReportItem>();

            var rom1 = new ReportItem { Description = "Widget 6000", Price = 104.99m, Qty = 1 };
            var rom2 = new ReportItem { Description = "Gizmo MAX", Price = 1.41m, Qty = 25 };
            ResultAccountInvoice.Add(rom1);
            ResultAccountInvoice.Add(rom2);


            // var rv = new ReportViewer();
            // var appPath = Directory.GetCurrentDirectory();
            LocalReport localReport = new();
            var appPath = Directory.GetCurrentDirectory();

            var pathLocation = appPath + @"/Data/Report.rdlc";
            localReport.ReportPath = pathLocation;
            localReport.DataSources.Add(new ReportDataSource("Items", ResultAccountInvoice));
            var pdf = localReport.Render("pdf");
            return File(pdf, "application/pdf", "report." + "pdf");
        }
        [HttpGet("GetPdfFileNew")]
        public ActionResult GetPdfFileNew()
        {


            List<CashReciptReport> ResultAccountInvoice = new List<CashReciptReport>();

            var rom = new CashReciptReport()
            {
                InvoiceNo = 123,
                CustomerAC = "Test 123",
                OrderAddress = "123 High Road",
                InvoiceDate = DateTime.Now,
                TotalValue = 1000,
                VATValue = 100,
                TotalVAT = 1100,
                JobAddress = "125 High Road"
            };
            ResultAccountInvoice.Add(rom);
            var rom2 = new CashReciptReport()
            {
                InvoiceNo = 124,
                CustomerAC = "Test 124",
                OrderAddress = "124 High Road",
                InvoiceDate = DateTime.Now,
                TotalValue = 1500,
                VATValue = 150,
                TotalVAT = 1650,
                JobAddress = "128 High Road"
            };
            ResultAccountInvoice.Add(rom2);

            // var rv = new ReportViewer();
            // var appPath = Directory.GetCurrentDirectory();
            LocalReport localReport = new();
            var appPath = Directory.GetCurrentDirectory();

            var pathLocation = appPath + @"/Data/ReportStatement.rdlc";
            localReport.ReportPath = pathLocation;
            localReport.DataSources.Add(new ReportDataSource("dsCashInvoice", ResultAccountInvoice));
            var pdf = localReport.Render("pdf");
            return File(pdf, "application/pdf", "report." + "pdf");
        }

    }
}
