 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amirProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace amirProject.Data
{
    public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }

        public virtual DbSet<Category>? categories { get; set; }
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sources = new string[]
                   {
                "https://www.computerhope.com/jargon/e/error.png",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Lion_waiting_in_Namibia.jpg/800px-Lion_waiting_in_Namibia.jpg",
                "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/golden-retriever-royalty-free-image-506756303-1560962726.jpg",
                "https://www.birdlife.org/wp-content/uploads/2021/06/Eagle-in-flight-Richard-Lee-Unsplash-1-edited-scaled.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/White_shark.jpg/800px-White_shark.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                "https://cdn.britannica.com/05/203605-050-59F5FB39/chameleon-on-branch.jpg",
                "https://www.imf.org/-/media/Images/IMF/FANDD/article-image/2019/December/chami-index.ashx",
                "http://www.dvarhamefarsem.co.il/Hot/20710/Rashit.JPG",
                "https://whnt.com/wp-content/uploads/sites/20/2022/05/GettyImages-1171368832.jpg?w=960&h=540&crop=1",
                "https://whnt.com/wp-content/uploads/sites/20/2022/05/GettyImages-1171368832.jpg",
                "https://img.apmcdn.org/9fe734b0a7596f13b98ccd5152262fe7d590ce4d/widescreen/a6c353-20220405-screech-owl-1000.jpg",
                   };

            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Birds" },
                new { CategoryId = 3, Name = "Fish" },
                new { CategoryId = 4, Name = "Amphibians" },
                new { CategoryId = 5, Name = "reptiles" }
                );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, CategoryId = 1, Age = 5, Name = "Lion", PictureSrc = sources[1],Description="The King Of Animals" },
                new Animal { AnimalId = 2, CategoryId = 1, Age = 2, Name = "Dog", PictureSrc = sources[2], Description = "Man Best Friend" },
                new Animal { AnimalId = 3, CategoryId = 2, Age = 12, Name = "Eagle", PictureSrc = sources[3], Description = "King Of Birds" },
                new Animal { AnimalId = 4, CategoryId = 3, Age = 3, Name = "Shark", PictureSrc = sources[4]  ,Description = "Swim in the big Ocean wild and free" },
                new Animal { AnimalId = 5, CategoryId = 1, Age = 4, Name = "Cat", PictureSrc = sources[5] , Description = "Shity Animals" },
                new Animal { AnimalId = 6, CategoryId = 5, Age = 1, Name = "Chameleon", PictureSrc = sources[6], Description = "they have crests or horns on the backs,of their skulls, long, sticky tongues, and uniquely-shaped feet" },
                new Animal { AnimalId = 7, CategoryId = 3, Age = 15, Name = "Whale", PictureSrc = sources[7], Description = "Big Mammal With lovely voice" },
                new Animal { AnimalId = 8, CategoryId = 2, Age = 2, Name = "Pigeon", PictureSrc = sources[8], Description = "Pigeons are gentle, plump, small-billed birds with a skin saddle (" },
                new Animal { AnimalId = 9, CategoryId = 5, Age = 4, Name = "Alligator", PictureSrc = sources[9], Description = "You Will not want to get close to him..." },
                new Animal { AnimalId = 10, CategoryId = 2, Age = 9, Name = "Owl", PictureSrc = sources[10], Description = "Animal Of The night" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1, Content = "king of animals" },
                new { CommentId = 2, AnimalId = 2, Content = "the man's best friend" },
                new { CommentId = 3, AnimalId = 1, Content = "Simba is his brother" },
                new { CommentId = 4, AnimalId = 5, Content = "licks itself" },
                new { CommentId = 5, AnimalId = 6, Content = "can change colors" },
                new { CommentId = 6, AnimalId = 7, Content = "the biggest fish in the world" },
                new { CommentId = 7, AnimalId = 9, Content = "you don't want to mess with this guy..." },
                new { CommentId = 8, AnimalId = 10, Content = "the smartest bird" }
                );
        }
    }
}

