using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PlaylistProject.Models;
using PlaylistProject.Repository;

namespace PlaylistProject.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMySongRepository _songRepository;
        public List<Song> Songs { get; set; }

        public PlaylistController(IPlaylistRepository playlistRepository,
        IMySongRepository songRepository)
        {
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
        }

        [HttpGet]
        public IActionResult Index(string genre)
        {
            Songs = new List<Song>();
            try
            {
                Songs = _songRepository.GetSongsByGenre(genre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View(new MyPlaylist() { Songs = Songs });

        }

        [HttpPost]
        public IActionResult SavePlaylistOnPost(string playlistName, string genre)

        {
            //Save the playlist
            Playlist playlist = new Playlist()
            {
                CreatedAt = DateTime.Now,
                Name = playlistName,
                Genre = genre
            };

            int newPlaylistId;
            try
            {
                _playlistRepository.CreatePlaylist(playlist);


                return RedirectToAction("Index", "Playlists");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToPage("/Error");

            }

        }

    }

}

