using MongoDB.Driver;
using MyWatchTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchTogether.Data
{
    public class DbContext
    {
        private IMongoDatabase db;

        public DbContext()
        {
            db = new MongoClient("mongodb://localhost:27017").GetDatabase("watchT");
        }

        public IMongoCollection<Playlist> Playlist
        {
            get
            {
                return db.GetCollection<Playlist>("Playlist");
            }
        }
    }
}
