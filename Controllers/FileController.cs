using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Album_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Album_Web.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(FileUploadViewModel files)
        {
            long size = files.FormFile.Sum(f => f.Length);

            foreach (var formFile in files.FormFile)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok();
        }
    }
}