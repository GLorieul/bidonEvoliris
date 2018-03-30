using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    class Cow : Herbivore
    {
        public Cow() { }

        public Cow(string name, int age)
            :base(name, age)
        { }

        public override void eat()
        {
            Console.WriteLine("Eats grass.");
        }

        public override void makeSound()
        {
            Console.Write("Moooooooo! ");
        }
    }
}
