using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace amirProject.Controllers
{
    public class AdminController : Controller
    {
        private IAnimalServices animalServices;
        private bool isLogged = false;

        public AdminController(IAnimalServices animalServices) => this.animalServices = animalServices;

        public IActionResult ShowLoginPage() => View("Login");

        public IActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {

                if (admin.Email == "nivniv66@gmail.com" && admin.Password == "nivniv66")
                {
                    isLogged = true;
                    return RedirectToAction("Index",admin);
                }
                else return View("Login");
            }
            return View("Login");
                


        }

        public IActionResult EditAnimal(int id) => View(animalServices.FindAnimalById(id));

        public IActionResult Index(Admin admin)
        {
            if (admin.Email!="nivniv66@gmail.com") return View("Login");

            return View(animalServices.GetAllAnimals().Animals!.Include(c => c.Categories));

        }

        public IActionResult DeleteAnimal(int id)
        {
            animalServices.DeleteService(id);
            return RedirectToAction("index");
        }

        public IActionResult AddNewAnimal(Animal animal,int categoryId)
        {
            animalServices.AddNewAnimal(animal, categoryId);
            return View("Index", animalServices.GetAllAnimals().Animals!);
        }

        public IActionResult UpdateAnimals(Animal Animal,int categoryId)
        {         
            animalServices.UpdateService((int)Animal.AnimalId!, Animal, categoryId);
            return RedirectToAction("index");
        }
    }
}

