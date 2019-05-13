using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePdfSample.Models
{
    public interface IPDFService
    {        Task<byte[]> GeneratePdf(string contentRootPath);
    }
}
