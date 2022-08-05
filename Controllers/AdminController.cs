using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace amirProject.Controllers
{
    public class AdminController : Controller
    {
        private IAnimalServices animalServices;


        public AdminController(IAnimalServices animalServices)
        {
            this.animalServices = animalServices;

        }
        public IActionResult EditAnimal(int id)
        {
            return View(animalServices.Find(id));
        }
        public IActionResult Index()
        {
            return View(animalServices.GetAllAnimals().Animals!);
        }
        public IActionResult Delete(int id)
        {
            animalServices.DeleteService(id);
            return RedirectToAction("index");
        }
        public IActionResult AddNewAnimals(int id)
        {
            animalServices.AddNewAnimalService(new Animal { Name = "yonatan", AnimalId = 91 });
            return RedirectToAction("index");
        }
        public IActionResult UpdateAnimals(Animal Animal )
        {         
            animalServices.UpdateService((int)Animal.AnimalId!, Animal);
            return RedirectToAction("index");
        }
    }
}

