using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    class Horse : Herbivore
    {
        public Horse() { }

        public Horse(string name, int age)
            :base(name, age)
        { }

        public override void eat()
        {
            Console.WriteLine("Eats hay");
        }

        public override void makeSound()
        {
            Console.Write("Iiiihihiihih! ");
        }
    }
}
