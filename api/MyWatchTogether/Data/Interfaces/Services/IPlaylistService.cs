using MyWatchTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchTogether.Data.Interfaces.Services
{
    public interface IPlaylistService
    {
        Playlist GetById(string id);
        List<Playlist> GetAll();
        string Add(Playlist playlist);
        void Update(Playlist playlist);
        void Delete(string id);
    }
}
