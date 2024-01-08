using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaylistProject.Models;
using PlaylistProject.Repository;

namespace PlaylistProject.Controllers;

public class MyPlaylistController : Controller
{
    private readonly IMySongRepository _mySongRepository;
    private readonly IPlaylistRepository _playlistRepository;

    public MyPlaylistController(IMySongRepository mySongRepository, IPlaylistRepository
    playlistRepository)
    {
        _mySongRepository = mySongRepository;
        _playlistRepository = playlistRepository;
    }

    public IActionResult Index(int playlistId, string playlistName)
    {//query the songs for the given playlistId(MySongs table)
     //-- do a JOIN on the SongId and FILTER by playlistId var songs = new List<Song>();
        var songs = new List<Song>();

        try
        {
            songs = _mySongRepository.GetSongsByPlaylistId(playlistId); //commented out before updatedv on 1/8
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        ViewData["PlaylistId"] = playlistId;

        return View(new Models.MyPlaylist()
        {
            Songs = songs,
            PlaylistName = playlistName
        });
    }

    [HttpPost] //stateless
    public IActionResult UpdatePlaylistOnPost(string playlistName)
    {//update the playlist name in the database
        var playlist = new Playlist()
        {
            ModifiedAt = DateTime.Now,
            Name = playlistName
        };
        try
        {
            _playlistRepository.UpdatePlaylist(playlist);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return RedirectToAction("UpdateSuccessful");
    }

    [HttpPost] //stateless
    public IActionResult DeletePlaylistOnPost(int playlistId)
    {       // Delete the playlist from the database
        try
        {
            _playlistRepository.DeletePlaylist(playlistId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return RedirectToAction("DeleteSuccessful");
    }

    public IActionResult UpdateSuccessful()
    {
        return View("UpdateSuccessful");
    }

    public IActionResult DeleteSuccessful()
    {
        return View("DeleteSuccessful");
    }
}

// Line 37 - ViewData["PlaylistId"] = playlistId;
// The reason we add this value to the view data so that we can use the id
// for delete and update actions (HTTP is stateless) // see:
// https://en.wikipedia.org/wiki/Stateless_protocol
// return the songs to the View