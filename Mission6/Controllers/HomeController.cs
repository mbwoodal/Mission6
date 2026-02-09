using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

// using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;

    public HomeController(MovieContext temp)
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult NewMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult NewMovie(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "The movie could not be added.");
            return View(movie);
        }

        try
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Movie added successfully!";
            return RedirectToAction("Index");
        }
        catch
        {
            ModelState.AddModelError("", "The movie could not be added due to a system error.");
            return View(movie);
        }
    }

    
}