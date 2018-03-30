using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise01
{
    class Cow
    {
        //Simple member variable
        private string name;

        //C++-style setter and getter
        //Considered bad practice in C# !
        private int age;

        public void SetAge(int age)
        {
            if (age >= 0)
            {
                this.age = age;
            }
        }

        public int GetAge()
        {
            return this.age;
        }

        //C#-style property with default getter and setter
        public string Race { get; set; }

        //C#-style property with custom getter and setter
        private double weight;

        public double Weight
        {
            get { return weight; }

            set { weight = (value > 0.0) ? value : 0.0; }
        }

        // Default constructor is implicitly deleted
        // => Explicitly declare default constructor
        public Cow() { }

        //Explicit constructor
        public Cow(string name, int age)
        {
            SetAge(age);
            this.name = name;
        }

        //Overriding constructor
        public Cow(string name)
        {
            this.name = name;
        }

        //Overloading of "+" operator
        public static double operator +(Cow cowA, Cow cowB)
        {
            return cowA.Weight + cowB.Weight;
        }

        //Overriding of default ToString() method
        public override string ToString()
        {
            //Developper-friendly syntax but slow
            //return "This is " + name  +", she is a " + Race + " cow, is " + age + " years old and weights " + weight "kg";
            return $"This is {name}, she is a {Race} cow, is {age} years old and weights {weight}kg";

            //Not so much a nice syntax but much faster
            //StringBuilder sb = new StringBuilder("This is ");
            //sb.Append(name);
            //sb.Append(", she is a ");
            //sb.Append(Race);
            //sb.Append("cow is ");
            //sb.Append(age);
            //sb.Append(" years old and weights");
            //sb.Append(Weight);
            //sb.Append("kg");
            //return sb.ToString();
        }

        //Argument overriding
        public void moo()
        {
            Console.WriteLine($"Moooo! said {this.name}");
        }

        public void moo(Cow other)
        {
            Console.WriteLine($"Moooo! said {this.name} to {other.name}");
        }
    }
}
