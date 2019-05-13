using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePdfSample.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePdfSample.Controllers
{
    public class PreviewController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public PreviewController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ShowTemplate()
        {
            var model = CarRepository.GetCarCalculatorData(_hostingEnvironment.ContentRootPath);
            return View(model);
        }
    }
}