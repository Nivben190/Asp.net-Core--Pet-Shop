using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace amirProject.Models
{
    public class Animal
    {
        public int? AnimalId { get; set; }

        [StringLength(15)]
        public string? Name { get; set; }

        [Range(0, 120)]
        public int? Age { get; set; }

        public string? PictureSrc { get; set; }

        [StringLength(30)]
        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public Category? Categories { get; set; }



    }
}
    


