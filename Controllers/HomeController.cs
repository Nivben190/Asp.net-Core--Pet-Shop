using System.Diagnostics;
using amirProject.Data;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace amirProject.Controllers;

public class HomeController : Controller
{
    private IAnimalServices animalServices;

    public HomeController(IAnimalServices animalServices) => this.animalServices = animalServices;

    public IActionResult Index() => View(animalServices.GetTopTwoCommentedAnimals());


}

