using MyWatchTogether.Data.Interfaces.Repositories;
using MyWatchTogether.Data.Interfaces.Services;
using MyWatchTogether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchTogether.Data.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public string Add(Playlist playlist)
        {
            return _playlistRepository.Add(playlist);
        }

        public void Delete(string id)
        {
            _playlistRepository.Delete(id);
        }

        public List<Playlist> GetAll()
        {
            return _playlistRepository.GetAll();
        }

        public Playlist GetById(string id)
        {
            return _playlistRepository.GetById(id);
        }

        public void Update(Playlist playlist)
        {
            _playlistRepository.Update(playlist);
        }
    }
}
