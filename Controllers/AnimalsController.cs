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
        public AnimalController(IAnimalServices animalServices)
        {

            this.animalServices = animalServices;

        }
        public IActionResult AddComment(string Comment,int id)
        {
           var animalFound= animalServices.Find(id);
           animalFound.Comments!.Add(new Comment { Content = Comment });
           animalServices.GetAllAnimals().SaveChanges();
          return View("AnimalPage", animalFound);
        }
        public IActionResult Index(string Category)
        {
            return View(animalServices.GetAnimalsByCategory(Category));
        }

        public IActionResult BackToAnimalPage(int id)
        {
            return View("AddNewAnimal");
        }


     

        public IActionResult AnimalPage(int id)
        {
            var animalFound = animalServices.Find(id);

           return View(animalFound);
          }
   
       

    }
}


