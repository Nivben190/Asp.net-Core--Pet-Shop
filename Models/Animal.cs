using System;
namespace amirProject.Models
{
    public class Animal
    {
        public int? AnimalId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? PictureSrc { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public Category? Categories { get; set; }



    }
}
    


