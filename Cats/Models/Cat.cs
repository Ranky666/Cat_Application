using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cats.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cats.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; } // Порода
        public int Price { get; set; }
    }
   
}
