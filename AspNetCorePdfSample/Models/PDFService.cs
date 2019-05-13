using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCorePdfSample.Repository;
using DinkToPdf;
using DinkToPdf.Contracts;
using RazorLight;

namespace AspNetCorePdfSample.Models
{
    public class PDFService : IPDFService
    {
        private readonly IRazorLightEngine _razorEngine;
        private readonly IConverter _pdfConverter;

        public PDFService(IRazorLightEngine razorEngine, IConverter pdfConverter)
        {
            _razorEngine = razorEngine;
            _pdfConverter = pdfConverter;
        }
        public async Task<byte[]> GeneratePdf(string contentRootPath)
        {

            CarCalculator carCalculator= CarRepository.GetCarCalculatorData(contentRootPath);
            //  var model = Data.CarRepository.GetCars();
            carCalculator.CSSLink = Path.Combine(contentRootPath, $"Content\\css\\bootstrap.css");
            var templatePath = Path.Combine(contentRootPath, $"Views\\Preview\\ShowTemplate.cshtml");
            string fileName = "CarComparison_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
            string filePath = Path.Combine(contentRootPath, "ReportTemplates", "PdfFiles", "ECalculator", fileName);
            string template = await _razorEngine.CompileRenderAsync(templatePath, carCalculator);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = "Car Calculator Document"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 12, Line = true, Center = "Sample of Car Calculator PDF document " },
                FooterSettings = { FontName = "Arial", FontSize = 12, Line = true, Right = "Page [page] of [toPage]" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            byte[] file = _pdfConverter.Convert(pdf);
            return file;
            // _pdfConverter.Convert(pdf);
            // return filePath;
        }
    }
}
