using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePdfSample.Models;
using AspNetCorePdfSample.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePdfSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {       

        private readonly IPDFService _pdfService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PdfController(IPDFService pdfService, IHostingEnvironment hostingEnvironment)
        {
            _pdfService = pdfService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("Generate")]
        public async Task<IActionResult> Generate()
        {
            var file = await _pdfService.GeneratePdf(_hostingEnvironment.ContentRootPath);
            return File(file, "application/pdf");
        }
    }
}