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
    public class SongController : Controller
    {
        private readonly ISongRepository repo;

        public SongController(ISongRepository repo)
        {
            this.repo = repo;
        }
    }
}

//return RedirectToAction("Songs");
//the method called Index corresponds with the Index View I created
//Each method in our SongsController will correspond to a particular View that we have created.
//this controller IActionResult is connecting the model to the view -
//repo.GetSongs // getting the song and store it in song, if it's null,
//it will return song not found otherewise we pass song to our view