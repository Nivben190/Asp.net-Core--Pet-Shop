using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amirProject.Data;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace amirProject.Controllers
{
   

    public class AnimalController : Controller
    {
        private IAnimalServices animalServices;

        public AnimalController(IAnimalServices animalServices) => this.animalServices = animalServices;

        public IActionResult AddCommentToAnimal(string Comment, int id)
        {
            if (ModelState.IsValid)
            {
                var animalFound = animalServices.AddNewCommentToAnimal(Comment, id);
                return View("AnimalPage", animalFound);
            }
            else return View();
        }

        public IActionResult Index(string Category) => View(animalServices.GetAnimalsByCategory(Category));

        public IActionResult BackToAnimalPage() => View("AddNewAnimal");

        public IActionResult AnimalPage(int id)
        {
            var animalFound = animalServices.FindAnimalById(id);
            return View(animalFound);
          }
    }
}


