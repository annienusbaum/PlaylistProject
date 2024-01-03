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
        public IActionResult SavePlaylistOnPost(MyPlayList myPlayList)
        {
            var playlist = new Playlist()
            {
                Name = myPlayList.Playlist.PlaylistName,
                CreatedAt = DateTime.Now
            };

            int newPlaylistId;
            try
            {
                newPlaylistId = _playlistRepository.CreatePlaylist(playlist);
                 catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (Request.Form.TryGetValue("song.SongID", out var songIds))
            {
                var mySongs = new List<MySong>();
                foreach (var songId in songIds)
                {
                    if (int.TryParse(songId, out var id))
                    {
                        mySongs.Add(new MySong() { PlaylistId = newPlaylistId, SongId = id });
                    }

                    try
                    {
                        _songRepository.AddSongs(mySongs);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    return RedirectToAction("Index", "MyPlaylist", new { PlaylistId = playlist.Id, PlaylistName = playlist.Name });
                }

                return RedirectToAction("Index");
            }
        }
    }

}


/*
 * (ending at line 17, I have defined a controller class named PlaylistController. 
 * This class has two private fields (_playlistRepository and _songRepository) 
 * injected through its constructor. 
 * These repositories will be responsible for interacting with the data storage (presumably a database) for playlists and songs. 
 * The Songs property is a list of Song objects, 
 * presumably used to store and pass song data within the controller.
public IActionResult UpdateProduct(int id)
{
    Product prod = repo.GetProduct(id);
    if (prod == null)
    {
        return View("ProductNotFound");
    }
    return View(prod);
}

 */
