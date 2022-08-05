using System;
using amirProject.Data;
using amirProject.Models;
using Microsoft.EntityFrameworkCore;

namespace amirProject.Repositery
{
    public class AnimalRepo:IAnimalServices
    {
        private AnimalsContext _context;

        public AnimalRepo(AnimalsContext context)
        {
            _context = context;
        }

        public Animal Find(int id)
        {
            var categories = _context.Animals!.Include(c => c.Categories).ThenInclude(c=>c.Animals!).ThenInclude(c=>c.Comments);            var animal = categories!.Single(m => m.AnimalId == id);
            return animal;
        }

        public List<Animal> GetAnimalsByCategory(string Category)
        {
            var animal = _context.Animals!.Include(c => c.Categories).Where(c=>c.Categories!.Name==Category);
            if (Category != null) return animal.ToList();
            else return _context.Animals!.ToList();
        }
         public AnimalsContext GetAllAnimals()
        {
            return _context;
        }
        public void AddNewAnimalService(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }
    }
}

