using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Album_Web.Models
{
    public class FileUploadViewModel
    {
        public List<IFormFile> FormFile { get; set; }
    }
}
