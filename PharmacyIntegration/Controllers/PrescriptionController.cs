using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Service;
using Backend.Examinations.Service.Interfaces;
using Backend.Examinations.Model;
using System.IO;
using System.Net;
using Backend.Reports.DTO;
using QRCoder;
using System.Security.Policy;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace PharmacyIntegration.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        IPrescriptionSearchService prescriptionSearchService;

        public PrescriptionController(IPrescriptionSearchService prescriptionSearchService)
        {
            this.prescriptionSearchService = prescriptionSearchService;
        }

        [HttpGet]
        public IEnumerable<Prescription> Get()
        {
            return prescriptionSearchService.GetAll();
        }

        [HttpPost]
        public IActionResult SendPrescription(Prescription prescription)
        {
            string fileName = prescriptionSearchService.GeneratePrescription(prescription);
            WebClient webClient = new WebClient();
            FileMetadata fileInfo = new FileMetadata();
            fileInfo.Filename = fileName;
            fileInfo.URL = "http://schnabel.herokuapp.com/pswupload";
            byte[] responseArray = webClient.UploadFile(fileInfo.URL, fileInfo.Filename);
            string ur = webClient.Encoding.GetString(responseArray).ToString();

            GenerateQRCode(prescription);
            
            return Ok(webClient.Encoding.GetString(responseArray));
            //return Ok();
        }
        private void GenerateQRCode(Prescription prescription)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(prescription.GetStringForSharing(), QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(10);

            using (var ms = new MemoryStream(qrCodeAsPngByteArr))
            {
                var qrCodeImage = new Bitmap(ms);
                qrCodeImage.Save("qrcode.png", ImageFormat.Png);  
            }
        }

    }
}
