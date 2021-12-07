using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAndApi.ViewModels
{
    [BsonIgnoreExtraElements]
    public class NewsViewModel
    {
        public List<ViewArticle> articles { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class ViewArticle
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }



    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
