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
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace MedbayTech.Pharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionSearchService prescriptionSearchService;

        public PrescriptionController(IPrescriptionSearchService prescriptionSearchService)
        {
            this.prescriptionSearchService = prescriptionSearchService;
        }

        [HttpGet]
        public IEnumerable<PrescriptionForSendingDTO> Get()
        {
            return prescriptionSearchService.GetAll();
        }

        [HttpPost]
        public IActionResult SendPrescription(PrescriptionForSendingDTO prescription)
        {
            if (prescription.Pharmacy == null)
                return BadRequest();

            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
            if (prescription.Pharmacy.ToLower().Contains("local") && stage.Contains("development"))
            {
                return SendPrescriptionSFTP(prescription);
            }
            else
            {
                return SendPrescriptionHTTP(prescription);
            }
                
        }

        private IActionResult SendPrescriptionSFTP(PrescriptionForSendingDTO prescription)
        {
            string fileName = prescriptionSearchService.GeneratePrescription(prescription);
            try
            {


                using HttpClient client = new HttpClient();

                string response = "";
                StringContent content = new StringContent(JsonConvert.SerializeObject(fileName), Encoding.UTF8, "application/json");
                var task = client.GetAsync("http://localhost:50202/api/Sftp/prescription/"+prescription.FileName())
                    .ContinueWith((taskWithResponse) =>
                    {
                        var message = taskWithResponse.Result;
                        var json = message.Content.ReadAsStringAsync();
                        json.Wait();
                        response = json.Result;
                    });
                task.Wait();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        private IActionResult SendPrescriptionHTTP(PrescriptionForSendingDTO prescription)
        {
            string fileName = prescriptionSearchService.GeneratePrescription(prescription);
            GenerateQRCode(prescription);
            WebClient webClient = new WebClient();
            FileMetadata fileInfo = new FileMetadata();
            fileInfo.Filename = fileName;
            fileInfo.URL = "http://schnabel.herokuapp.com/pswupload";

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

    }
}
