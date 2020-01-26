using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cats.Models;

namespace Cats.Models
{
    public static class SampleData
    {
        public static void Initialize(CatContext context)
        {
            if (!context.Cats.Any())
            {
                context.Cats.AddRange(
                    new Cat
                    {
                        Name = "Барсик",
                        Breed = "Британец",
                        Price = 600
                    },
                    new Cat
                    {
                        Name = "Мурзик",
                        Breed = "Вислоухий",
                        Price = 550
                    },
                    new Cat
                    {
                        Name = "Пушистик",
                        Breed = "Обыкновенный",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
