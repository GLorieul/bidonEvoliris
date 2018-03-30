using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    class Lion : Carnivore
    {
        public Lion() { }

        public Lion(string name, int age)
            :base(name, age)
        { }

        public override void eat()
        {
            Console.WriteLine("Eats a whole dear");
        }

        public override void makeSound()
        {
            Console.Write("Rooooaaarrrr!!! ");
        }
    }
}
