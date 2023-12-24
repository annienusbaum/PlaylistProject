using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using PlaylistProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaylistProject.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongsRepository repo;

        public SongsController(ISongsRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var songs = repo.GetAllSongs();

            return View(songs);
        }

        public IActionResult ViewSong(int id)
        {
            var songs = repo.GetSong(id);

            return View(songs);
        }

        public IActionResult AddToPlaylist()
        {
            return RedirectToPage("Playlist");
        }

        public IActionResult UpdateSong(int id)
        {
            Song song = repo.GetSong(id);
            if (song == null)
            {
                return View("SongNotFound");
            }
            return View(song);
        }

        public IActionResult UpdateSongsToDatabase(Song song)
        {
            repo.UpdateSong(song);

            return RedirectToAction("ViewSong", new { id = song.SongID });
        }

        public IActionResult DeleteSong(Song songs)
        {
            repo.DeleteSong(songs);
            return RedirectToAction("Index");
        }
    }
}

//return RedirectToAction("Songs");
//the method called Index corresponds with the Index View I created
//Each method in our SongsController will correspond to a particular View that we have created.
//this controller IActionResult is connecting the model to the view -
//repo.GetSongs // getting the song and store it in song, if it's null, it will return song not found otherewise we pass song to our view