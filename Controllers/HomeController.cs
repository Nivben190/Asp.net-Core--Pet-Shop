using System.Diagnostics;
using amirProject.Data;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace amirProject.Controllers;

public class HomeController : Controller
{
    private AnimalsContext _context;

    public HomeController(AnimalsContext context)
    {
        _context = context;

    }
    public List<Animal> GetTopTwoCommentedAnimals()
    {
        var animal = _context.Animals!.Include(c => c.Comments);
        var pets = animal!.OrderByDescending(p => p.Comments!.Count).Take(2).ToList();
        return pets;

    }

    public IActionResult Index()
    {
        
        return View(GetTopTwoCommentedAnimals());
    }

    public IActionResult Delete(int id)
    {
        var animal = _context.Animals!.Single(m => m.AnimalId == id);
        _context.Animals!.Remove(animal);
        _context.SaveChanges();
        return RedirectToAction("index");
    }


}

