using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    abstract class Person
    {
        public string firstName { get; set; }
        public string surname { get; set; }

        public Person() { }
        public Person(string firstName, string surname)
        {
            this.firstName = firstName;
            this.surname = surname;
        }

        public override string ToString()
        {
            return $"My name is {firstName} {surname}";
        }
    }
}
