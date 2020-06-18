using System.Collections.Generic;

using Microsoft.AspNetCore.Http;

namespace Album_Web.Models
{
    public class FileUploadViewModel
    {
        public List<IFormFile> FormFiles { get; set; }
    }
}