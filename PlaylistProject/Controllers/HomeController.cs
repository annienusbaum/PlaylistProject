﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlaylistProject.Models;

namespace PlaylistProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    [BindProperty]
    public string Genre { get; set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitFormOnPost() //action for form submission
    {
        return RedirectToAction("Index", "Playlist", new { Genre = Genre });
    }


    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

