using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAndApi.Models;
using MongoAndApi.ViewModels;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoAndApi.Controllers
{
    public class NewsApiController : Controller
    {
        static readonly HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetNews()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("identity");
            var collection = db.GetCollection<Article>("articles");
            var response = await httpClient.GetAsync("https://newsapi.org/v2/everything?q=keyword&apiKey=55c4526152fa4646b8e4439e055a7258");
            var responseBody = await response.Content.ReadAsStringAsync();
            NewsApi myDeserializedClass = JsonConvert.DeserializeObject<NewsApi>(responseBody);

            int count = 0;
            foreach (var item in myDeserializedClass.articles)
            {
                collection.InsertOne(item);
                ++count;
                if (count > 9) break;
            }

            return RedirectToAction("Index", null);
        }

        public IActionResult ShowNews()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("identity");
            var collection = db.GetCollection<ViewArticle>("articles");
            NewsViewModel model = new ();

            model.articles = collection.AsQueryable().ToList();
            return View(model);
        }
    }
}
