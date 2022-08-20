using System;
using amirProject.Data;
using amirProject.Models;

namespace amirProject.Repositery
{
    public interface IAnimalServices
    {
        public Animal AddNewCommentToAnimal(string Comment, int id);
       void UpdateService(int id,Animal animal, int categoryId);
       void DeleteService(int id);
        List<Animal> GetAnimalsByCategory(string Category);
        AnimalsContext GetAllAnimals();
        public Animal FindAnimalById(int id);
        public void AddNewAnimal(Animal animal, int categoryId);
        public List<Animal> GetTopTwoCommentedAnimals();
    }
}

