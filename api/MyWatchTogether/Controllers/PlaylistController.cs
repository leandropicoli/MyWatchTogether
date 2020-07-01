using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MyWatchTogether.Data.Interfaces.Services;
using MyWatchTogether.Models;

namespace MyWatchTogether.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public List<Playlist> GetAll()
        {
            return _playlistService.GetAll();
        }

        [HttpGet]
        public Playlist GetById(string id)
        {
            return _playlistService.GetById(id);
        }

        [HttpPut]
        public string Add(Playlist playlist)
        {
            return _playlistService.Add(playlist);
        }

        [HttpPost]
        public Playlist Update(Playlist playlist)
        {
            try
            {
                _playlistService.Update(playlist);
                return playlist;
            }
            catch (Exception e)
            {
                throw e;  
            }
        }
    }
}