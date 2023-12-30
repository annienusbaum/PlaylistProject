using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistProject.Models;
using PlaylistProject.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: /<controller>/
        public IActionResult Index(string genre)
        {
            Songs = new List<Song>();
            try
            {
                Songs = _songRepository.GetSongsByGenre(genre);
            }   catch (Exception e)
            {
                    Console.WriteLine(e);
                throw;
            }
            return View(Songs);

            }
        }
    }


