using AudioUploadApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioUploadApp.Controllers
{
    public class AudioUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(AudioFile model)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.Combine("wwwroot/uploads", model.File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                ViewBag.Message = "Файл успешно загружен!";
                return View("Index");
            }

            return View("Index", model);
        }
    }
}
