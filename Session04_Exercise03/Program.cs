using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> oldMcDonaldsFarm = new List<Animal>();
            oldMcDonaldsFarm.Add(new Cow("Margerite", 12));
            oldMcDonaldsFarm.Add(new Cow("Yolande", 4));
            oldMcDonaldsFarm.Add(new Cow("Bernadette", 15));
            oldMcDonaldsFarm.Add(new Wolf("John Snow", 3));
            oldMcDonaldsFarm.Add(new Horse("Maverick", 5));
            oldMcDonaldsFarm.Add(new Horse("Proud", 12));
            oldMcDonaldsFarm.Add(new Lion("Simba", 3));

            foreach (Animal elemAnimal in oldMcDonaldsFarm)
            {
                Console.WriteLine("Old MacDonald had a farm, EE - I - EE - I - O,");
                Console.WriteLine($"And on that farm he had {elemAnimal.Name}, EE-I-EE-I-O,");
                Console.Write($"With a ");
                elemAnimal.makeSound();
                elemAnimal.makeSound();
                Console.Write(" here and a ");
                elemAnimal.makeSound();
                elemAnimal.makeSound();
                Console.WriteLine(" there");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
