using System;
using System.IO;
using System.Threading.Tasks;

using Album_Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Album_Web.Controllers
{
    [Authorize]
    public class FileController : ControllerBase
    {

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(FileUploadViewModel model)
        {
            foreach (var formFile in model.FormFiles)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(/*Directory.GetCurrentDirectory()*/Environment.CurrentDirectory, formFile.FileName);
                    using var stream = System.IO.File.Create(filePath);
                    await formFile.CopyToAsync(stream);
                }
            }
            return Ok();
        }
    }
}