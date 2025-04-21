using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProject3
{
    internal class Cat : Pet
    {   
        //enum for cat breeds
        public enum CatBreed { Tabby, Manx, MainCoon}
        public CatBreed Breed { get; set; }
        public override string MakeSound() => "Meow!";
        
    }
}
