﻿using System;
using MedbayTech.Pharmacies.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

namespace MedbayTech.Pharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            // TODO(Jovan): Fix hardcoded data!!!!!
            var config = new SftpConfig
            {
                Host = "192.168.0.20",
                Port = 2222,
                Username = "psw",
                Password = "psw"
            };
            string localFile = "GeneratedPrescription/2406978890046_Brufen_7_12_2020.txt";
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


        [HttpGet("prescription/{path?}")]
        public IActionResult GetPrescription( string path)
        {

            var config = new SftpConfig
            {
                Host = "192.168.0.20",
                Port = 2222,
                Username = "psw",
                Password = "psw"
            };
            string localFile = "GeneratedPrescription/" + path + ".txt";
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
