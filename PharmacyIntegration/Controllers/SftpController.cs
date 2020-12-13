using System;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            // TODO(Jovan): Fix hardcoded data
            var config = new SftpConfig
            {
                Host = "192.168.1.7",
                Port = 2222,
                Username = "psw",
                Password = "psw"
            };
            string localFile = "test.txt";
            using var client = new SftpClient(config.Host, config.Port, config.Username, config.Password);
            try
            {
                client.Connect();
                using var s = System.IO.File.OpenRead(localFile);
                Console.WriteLine(localFile);
                client.UploadFile(s, "test.txt");
                return Ok($"Finished uploading file [{localFile}] to [{"."}]");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message + $"Failed in uploading file [{localFile}] to [{"."}]");
            }
            finally
            {
                client.Disconnect();
            }
        }
    }
}
