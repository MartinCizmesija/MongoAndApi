using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace MongoAndApi.Models
{
    // MusicApi myDeserializedClass = JsonConvert.DeserializeObject<MusicApi>(myJsonResponse); 
    [BsonIgnoreExtraElements]
    public class Image
    {
        [JsonProperty("#text")]
        public string Text { get; set; }
        public string size { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Stats
    {
        public string listeners { get; set; }
        public string playcount { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Artist
    {
        public string name { get; set; }
        public string url { get; set; }
        public List<Image> image { get; set; }
        public string mbid { get; set; }
        public string streamable { get; set; }
        public string ontour { get; set; }
        public Stats stats { get; set; }
        public Similar similar { get; set; }
        public Tags tags { get; set; }
        public Bio bio { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Similar
    {
        public List<Artist> artist { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Tag
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Tags
    {
        public List<Tag> tag { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Link
    {
        [JsonProperty("#text")]
        public string Text { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Links
    {
        public Link link { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Bio
    {
        public Links links { get; set; }
        public string published { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class MusicApi
    {
        public Artist artist { get; set; }
    }

}
