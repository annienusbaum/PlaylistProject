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
        public IActionResult SavePlaylistOnPost(string playlistName)

        {//Save the playlist
            var playlist = new Playlist()
            {//(originally was) Name = myPlaylist.PlaylistName. changed to Id=
                CreatedAt = DateTime.Now,
                Name = playlistName
            };

            int newPlaylistId;
            try
            {
                newPlaylistId = _playlistRepository.CreatePlaylist(playlist); // PUT BREAKPOINTS HERE LINE 55
                //Will need to return the id of the new playlist. see learndapper query
                //selecting scarlar-values
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw & delete line below
                return RedirectToPage("Error");
            }
            //Get the song ids submitted with the form
            if (Request.Form.TryGetValue("song.SongID", out var songIds)) //PUT BREAKPOINT HERE AT 66
            {
                var mySongs = new List<MySong>();
                foreach (var songId in songIds) //make sure that each song id is of type int
                {
                    if (int.TryParse(songId, out var id))
                    {//Add the new song to my MySongs
                        mySongs.Add(new MySong() { PlaylistId = newPlaylistId, SongId = id });
                    }
                    //Save my songs to the MySongs table
                    //loop - insert data into the loop
                    //foreach - passing in a list into mysongs and a list in
                    try
                    {
                        //_songRepository.AddSongs(mySongs);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    return RedirectToAction("Index", "MyPlaylist", new { PlaylistId = playlist.Id, PlaylistName = playlist.Id }); // try playlist.Name? originally in Will's guide
                }
                //something went wrong reload the page.
                return RedirectToAction("Index");
            }

            return RedirectToPage("Error");
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
