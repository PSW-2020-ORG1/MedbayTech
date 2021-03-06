﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Pharmacies.Application.DTO
{
    public class FileMetadata
    {
        public string Filename { get; set; }
        public string URL { get; set; }

        public FileMetadata() { }
        public FileMetadata(string filename, string url)
        {
            Filename = filename;
            URL = url;
        }
    }
}
