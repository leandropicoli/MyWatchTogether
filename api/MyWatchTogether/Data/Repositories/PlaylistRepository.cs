using MongoDB.Bson;
using MongoDB.Driver;
using MyWatchTogether.Data.Interfaces.Repositories;
using MyWatchTogether.Data;
using MyWatchTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWatchTogether.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DbContext _dbContext;

        public PlaylistRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(Playlist playlist)
        {
            _dbContext.Playlist.InsertOne(playlist);

            return playlist.Id;
        }

        public void Delete(string id)
        {
            _dbContext.Playlist.DeleteOne(Builders<Playlist>.Filter.Eq(x => x.Id, id));
        }

        public List<Playlist> GetAll()
        {
            return _dbContext.Playlist.Find(x => true).ToList();
        }

        public Playlist GetById(string id)
        {
            return _dbContext.Playlist.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Playlist playlist)
        {
            if (playlist.Id != null)
            {
                var filter = Builders<Playlist>.Filter.Eq(x => x.Id, playlist.Id);
                var update = Builders<Playlist>.Update
                    .Set(x => x.Name, playlist.Name)
                    .Set(x => x.Urls, playlist.Urls);

                _dbContext.Playlist.UpdateOne(filter, update);
            }
            else
            {
                _dbContext.Playlist.InsertOne(playlist);
            }
        }
    }
}
