using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Pharmacies;

namespace MedbayTech.Pharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionSearchService prescriptionSearchService;
        private readonly IMailService mailService;
        private readonly IPharmacyService pharmacyService;

        public PrescriptionController(IPrescriptionSearchService prescriptionSearchService, IMailService mailService, IPharmacyService pharmacyService)
        {
            this.prescriptionSearchService = prescriptionSearchService;
            this.mailService = mailService;
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public IEnumerable<PrescriptionForSendingDTO> Get()
        {
            return prescriptionSearchService.GetAll();
        }

        [HttpPost]
        public IActionResult SendPrescription(PrescriptionForSendingDTO prescription)
        {
            string fileName = prescriptionSearchService.GeneratePrescription(prescription);
            GenerateQRCode(prescription);
            WebClient webClient = new WebClient();
            FileMetadata fileInfo = new FileMetadata();
            fileInfo.Filename = fileName;
            fileInfo.URL = "http://schnabel.herokuapp.com/pswupload";

            SendMail();

            Console.WriteLine("Trying to send response...");
            byte[] responseArray = webClient.UploadFile(fileInfo.URL, fileInfo.Filename);
            string ur = webClient.Encoding.GetString(responseArray).ToString();
            return Ok(webClient.Encoding.GetString(responseArray));

        }

        [HttpGet("qrcode")]
        public IActionResult GetQrcode()
        {
            if (Directory.GetFiles("GeneratedPrescription").Contains("GeneratedPrescription" + Path.DirectorySeparatorChar + "qrcode.png"))
            {
                return Ok("GeneratedPrescription" + Path.DirectorySeparatorChar + "qrcode.png");       
            }
            return Ok("Not found!");
        }

        private void GenerateQRCode(PrescriptionForSendingDTO prescription)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(prescription.ToString(), QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(5);
            Console.WriteLine("Generating QR code");
            using (var ms = new MemoryStream(qrCodeAsPngByteArr))
            {
                var qrCodeImage = new Bitmap(ms);
                qrCodeImage.Save("GeneratedPrescription" + Path.DirectorySeparatorChar + prescription.FileName() + "qrcode.png", ImageFormat.Png);
            }
            Console.WriteLine("Generated QR code");
        }

        private void SendMail()
        {
            MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = "jankovicpharmacy@gmail.com", Subject = "Message from Medbay hospital", Body = "New prescription from MedbayTech hospital!" };
            mailService.SendMailAsync(mailRequest).Wait();
        }

    }
}
