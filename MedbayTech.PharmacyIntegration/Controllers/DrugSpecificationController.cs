using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Pharmacies.Model;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugSpecificationController : Controller
    {

        public DrugSpecificationController() { }

        [HttpPost]
        public IActionResult Post(DrugSpecDTO drug)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            document.Info.Title = drug.Name + " specification";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.Regular);

            gfx.DrawString(drug.Name, font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height / 4),
                XStringFormats.Center);

            gfx.DrawString(drug.Description, font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height / 2),
                XStringFormats.Center);
            // TODO(Jovan): Use global variable?
            string filename = "DrugSpecifications" + Path.DirectorySeparatorChar + drug.Name.Replace(" ", "") + ".pdf";
            document.Save(filename);
            return Ok();
        }
    }
}
