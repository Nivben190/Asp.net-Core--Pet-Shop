using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amirProject.Data;
using amirProject.Models;
using amirProject.Repositery;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult Index(string MyCategory)
        {
            return View(animalServices.GetAnimalsByCategory(MyCategory));
        }

        public IActionResult BackToAnimalPage(string MyCategory)
        {
            return View("AddNewAnimal");
        }


        public IActionResult AddNewAnimalAction(string AnimalName,int Age,string Desc,string PicName)
        {
            var length = animalServices.GetAllAnimals().Animals!.ToList().Count;
            animalServices.GetAllAnimals()!.Add(
                new Animal {AnimalId= length+1, CategoryId = 1 ,Age=Age,Name=AnimalName,Description=Desc,PictureSrc= "https://cdn.britannica.com/05/203605-050-59F5FB39/chameleon-on-branch.jpg" });
            animalServices.GetAllAnimals().SaveChanges();
            return View("Index", animalServices.GetAllAnimals().Animals);
        }

        public IActionResult AnimalPage(int id)
        {

           return View(animalServices.Find(id));
          }
   
       

    }
}


