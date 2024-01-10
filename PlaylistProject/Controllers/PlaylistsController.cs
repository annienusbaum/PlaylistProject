using Microsoft.AspNetCore.Mvc;
using PlaylistProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaylistProject.Controllers;

public class PlaylistsController : Controller
{
    private readonly IPlaylistRepository _playlistRepository;
    private readonly ILogger<PlaylistController> _logger;

    public PlaylistsController(IPlaylistRepository playlistRepository, ILogger<PlaylistController> logger)
    {
        _playlistRepository = playlistRepository;
    }
    // GET: /<controller>/
    public IActionResult Index()
    {
        var myPlaylists = new List<Playlist>();
        try
        {
            myPlaylists = _playlistRepository.GetPlaylists().ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        myPlaylists = myPlaylists.Where(p => !string.IsNullOrEmpty(p.Name)).ToList();

        return View(myPlaylists);
    }
}

