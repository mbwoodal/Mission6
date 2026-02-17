using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        ViewBag.Ratings = _context.Movies
            .Select(x => x.Rating)
            .Distinct()
            .OrderBy(x => x)
            .ToList();
        
        return View("NewMovie", new Movie());
    }
    
    [HttpPost]
    public IActionResult NewMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Ratings = _context.Movies
                .Select(x => x.Rating)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            return View("Index", movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            
            ViewBag.Ratings = _context.Movies
                .Select(x => x.Rating)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            
            return View(movie);
        }
    }

    public IActionResult ViewMovies()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
            
        ViewBag.Ratings = _context.Movies
            .Select(x => x.Rating)
            .Distinct()
            .OrderBy(x => x)
            .ToList();
        
        return View("NewMovie", movieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieToDelete = _context.Movies
            .Single(x => x.MovieId == id);

        return View(movieToDelete);
    }
    
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }
}