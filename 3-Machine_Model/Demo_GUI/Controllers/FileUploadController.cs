
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Demo_GUI.Filters;
using Demo_GUI.Helpers;

namespace Demo_GUI.Controllers
{
    public class FileUploadController : Controller
    {

        public ActionResult UploadSmallFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSmallFile(IFormFile file)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableFormValueModelBinding]
        [RequestSizeLimit(100000000)]
        public async Task<IActionResult> UploadStreamingFile()
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Request.StreamFile(stream);
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok();
        }
    }

}