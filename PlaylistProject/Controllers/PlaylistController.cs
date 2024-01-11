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
            {//(originally was) Name = myPlaylist.PlaylistName. changed to Id=
                CreatedAt = DateTime.Now,
                Name = playlistName,
                Genre = genre
            };

            int newPlaylistId;
            try
            {
                _playlistRepository.CreatePlaylist(playlist);
                // PUT BREAKPOINTS HERE LINE 55
                //Will need to return the id of the new playlist. see learndapper query
                //selecting scarlar-values

                return RedirectToAction("Index", "Playlists");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToPage("/Error");
                //throw & delete line below

            }

        }

    }

}


/*
 * (ending at line 17, I have defined a controller class named PlaylistController. 
 * This class has two private fields (_playlistRepository and _songRepository) 
 * injected through its constructor. 
 * These repositories will be responsible for interacting with the data storage in mySQL for playlists and songs. 
 * The Songs property is a list of Song objects, 
 * used to store and pass song data within the controller.

 */
