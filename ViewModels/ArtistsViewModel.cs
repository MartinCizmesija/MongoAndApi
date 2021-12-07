using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoAndApi.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAndApi.ViewModels
{
    [BsonIgnoreExtraElements]
    public class ArtistsViewModel
    {
        public List<MusicApi> artists { get; set; }
    }
}
