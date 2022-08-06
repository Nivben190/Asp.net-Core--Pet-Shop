using System;
using amirProject.Data;
using amirProject.Models;

namespace amirProject.Repositery
{
    public interface IAnimalServices
    {
       void UpdateService(int id,Animal animal);
       void DeleteService(int id);
       void AddNewAnimalService(Animal animal);
        List<Animal> GetAnimalsByCategory(string Category);
        AnimalsContext GetAllAnimals();
        public Animal Find(int id);
        public void AddNewAnimalF(string AnimalName, int Age, string PicName, string Desc);

    }
}

