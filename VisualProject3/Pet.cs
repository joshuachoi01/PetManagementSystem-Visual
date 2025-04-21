using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProject3
{
    internal abstract class Pet
    {
        //super class for pet
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract string MakeSound();

    }
}
