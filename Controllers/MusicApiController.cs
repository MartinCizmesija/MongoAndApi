using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAndApi.Models;
using MongoAndApi.ViewModels;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoAndApi.Controllers
{
    public class MusicApiController : Controller
    {
        static readonly HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetArtist()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("identity");
            var collection = db.GetCollection<MusicApi>("artists");
            var response = await httpClient.GetAsync("http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=Leonard Cohen&api_key=f2af2ac7e77d67dd7c2d06757c0b9e8a&format=json");
            var responseBody = await response.Content.ReadAsStringAsync();
            MusicApi myDeserializedClass = JsonConvert.DeserializeObject<MusicApi>(responseBody);

            collection.InsertOne(myDeserializedClass);

            return RedirectToAction("Index");
        }

        public IActionResult ShowArtists()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("identity");
            var collection = db.GetCollection<MusicApi>("artists");
            ArtistsViewModel model = new();

            model.artists = collection.AsQueryable().ToList();
            return View(model);
        }
    }
}
