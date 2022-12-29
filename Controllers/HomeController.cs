using LibrarySystem.Models;
using LibrarySystem.Presistence;
using LibrarySystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookDbContext Context;

        public HomeController(ILogger<HomeController> logger, BookDbContext context)
        {
            _logger = logger;
            Context = context;
        }

        public IActionResult Index()
        {
            using (Context)
            {
                var books = Context?.Books?
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.SubCategory)
                .ToList(); ;
                return View(books);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Question()
        {
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            var questions = await JsonSerializer.DeserializeAsync<StackOverflowQuestion>
                        (await client.GetStreamAsync("https://api.stackexchange.com/2.2/questions?page=1&pagesize=50&order=desc&sort=votes&site=stackoverflow"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            return View(questions);
        }
        public async Task<IActionResult> Book()
        {

            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            var books = await JsonSerializer.DeserializeAsync<BookResult>
                        (await client.GetStreamAsync($"https://localhost:7107/api/book/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return View(books!.data);
        }
        public async Task<IActionResult> QuestionDetails(int id)
        {

            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            var questions = await JsonSerializer.DeserializeAsync<StackOverflowQuestion>
                        (await client.GetStreamAsync($"https://api.stackexchange.com/2.2/questions/{id}?order=desc&sort=votes&site=stackoverflow"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            return View(questions);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}