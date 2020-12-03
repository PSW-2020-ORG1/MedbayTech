using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpFileSharingController : Controller
    {

        // This is the most popular/well-known upload method formatting the data you send as a set of key/value pairs.
        [HttpPost]
        public async Task<IActionResult> PostFormData([FromForm] IFormFile file)
        {
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var content = await sr.ReadToEndAsync();
                return Ok(content);
            }
        }



        //  ----- Second method -----
        [HttpPost]
        public async Task<IActionResult> PostFiles(ICollection<IFormFile> files)
        {
            try
            {
                System.Console.WriteLine("You received the call!");
                long size = files.Sum(f => f.Length);

                // full path to file in temp location
                var filePath = Path.GetTempFileName();
                var fileName = Path.GetTempFileName();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                            //formFile.CopyToAsync(stream);
                        }
                    }
                }

                // process uploaded files
                // Don't rely on or trust the FileName property without validation.
                //Displaying File Name for verification purposes for now -Rohit

                return Ok(new { count = files.Count, fileName, size, filePath });
            }
            catch (Exception exp)
            {
                System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);
                string message = $"file / upload failed!";
                return Json(message);
            }
        }


    }
}
