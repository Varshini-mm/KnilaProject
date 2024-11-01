using KnilaProject.Model.Models;
using KnilaProject.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace KnilaProjectUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;

        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> BookDashBoard()
        {
            try
            {
                string apiUrl = _configuration["ApiSettings:ApiUrl"];
                using HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/api/Book/GetAllBooks");
                response.EnsureSuccessStatusCode();
                // Get the response body as a string
                string responseBody = await response.Content.ReadAsStringAsync();
                // Deserialize the string into a list of Book models
                List<BookEntity> books = JsonConvert.DeserializeObject<List<BookEntity>>(responseBody);
                return Json(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}