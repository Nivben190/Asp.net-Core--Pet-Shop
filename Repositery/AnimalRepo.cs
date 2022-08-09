using System;
using amirProject.Data;
using amirProject.Models;
using Microsoft.EntityFrameworkCore;

namespace amirProject.Repositery
{
    public class AnimalRepo:IAnimalServices
    {
        private AnimalsContext _context;

        public AnimalRepo(AnimalsContext context) => _context = context;

        public Animal AddNewCommentToAnimal(string Comment, int id)
        {
            var animalFound = FindAnimalById(id);
            animalFound.Comments!.Add(new Comment { Content = Comment });
            GetAllAnimals().SaveChanges();
            return animalFound;
        }

        public List<Animal> GetTopTwoCommentedAnimals()
        {
            var animal = _context.Animals!.Include(c => c.Comments);
            var pets = animal!.OrderByDescending(p => p.Comments!.Count).Take(2).ToList();
            return pets;

        }

        public void AddNewAnimal(string AnimalName,int Age,string PicName,string Desc)
        {
            var animalList = _context.Animals!.ToArray();
            int id = (int)(animalList[animalList.Length - 1].AnimalId! + 1);
            _context.Animals!.Add(new Animal { AnimalId = id, Age = Age, Name = AnimalName,CategoryId=1, Description = Desc, PictureSrc = PicName });
            _context.SaveChanges();
        }

        public Animal FindAnimalById(int id)
        {
            var categories = _context.Animals!.Include(c => c.Categories).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Comments);
            var animal = categories!.Single(m => m.AnimalId == id);
            return animal;
        }

        public List<Animal> GetAnimalsByCategory(string Category)
        {
            var animal = _context.Animals!.Include(c => c.Categories).Where(c=>c.Categories!.Name==Category);
            if (Category != null && Category !="Show All") return animal.ToList();
            else return _context.Animals!.ToList();
        }

        public AnimalsContext GetAllAnimals()
        {
            return _context;
        }

        public void DeleteService(int id)
        {
            var animal = _context.Animals!.Single(m => m.AnimalId == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }

        public void UpdateService(int id,Animal animal)
        {
            var animalFound = _context.Animals!.Single(m => m.AnimalId == id);
            _context.Animals!.Update(animalFound);
            animalFound.Name=animal.Name;
            animalFound.Age = animal.Age;
            animalFound.Description = animal.Description;
            animalFound.PictureSrc = animal.PictureSrc;

            _context.SaveChanges();
        }
    }
}

