using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProject3
{
    internal class Dog : Pet
    {
        //enum for dog breeds
        public enum DogBreed { Corgi, Heeler, PitBull}
        public DogBreed Breed { get; set; }
        public override string MakeSound() => "Woof!";
       
    }
}
