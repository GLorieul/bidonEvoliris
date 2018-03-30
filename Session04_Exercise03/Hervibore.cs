using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    abstract class Herbivore : Animal
    {
        public Herbivore() { }

        public Herbivore(string name, int age)
            :base(name, age)
        { }
    }
}
