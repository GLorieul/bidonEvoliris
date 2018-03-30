using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise02
{
    abstract class Person
    {
        public Person() { }

        public Person(string firstName, string surname)
        {
            Console.WriteLine("Now within Person.Person(string, string)");
            FirstName = firstName;
            Surname = surname;
        }

        public virtual void PresentYourself()
        {
            Console.WriteLine($"FirstName={FirstName}, Surname={Surname}");
        }

        public abstract void roll();

        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
