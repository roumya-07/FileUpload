using FileUploadWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        Uri baseAdd = new Uri("http://localhost:49171/api");

        HttpClient client;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }   

        [HttpPost]
        public async Task<IActionResult> Create(FileUploadEntity FU)
        {
            string[] files = FU.Photo.Split('\\');
            FU.Photo = "Photo/" + files[files.Length - 1];
            string data = JsonConvert.SerializeObject(FU);
            HttpResponseMessage response;
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            response = client.PutAsync(client.BaseAddress + "/FU/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Photo");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }
    }
}
