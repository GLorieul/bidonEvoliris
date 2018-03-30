using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    class Wolf : Carnivore
    {
        public Wolf() { }

        public Wolf(string name, int age)
            :base(name, age)
        { }

        public override void eat()
        {
            Console.WriteLine("Eats a rat.");
        }

        public override void makeSound()
        {
            Console.Write("OOOOooooooohhhh! ");
        }
    }
}
