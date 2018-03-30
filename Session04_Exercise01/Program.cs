using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Session04 covers classes
/// Fri 30 March
namespace Session04_Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Playing with member variables
            Cow margerite = new Cow("Margerite");
            margerite.SetAge(-10);
            Console.WriteLine($"Age={margerite.GetAge()}");
            margerite.SetAge(20);
            Console.WriteLine($"Age={margerite.GetAge()}");
            margerite.Race = "Normande";
            Console.WriteLine($"Race={margerite.Race}");
            margerite.Weight = 150.0;
            Console.WriteLine();

            //Playing with *.ToString() method
            Cow bernadette = new Cow("Bernadette", 3);
            bernadette.Race = "Bleu blanc belge";
            bernadette.Weight = 200.0;
            Console.WriteLine(margerite.ToString());
            Console.WriteLine(bernadette.ToString());

            //Playing with operator overriding
            double totalMeat = margerite + bernadette;
            Console.WriteLine($"totalMeat = {totalMeat}kg");
            Console.WriteLine();

            //Playing with function overriding (parameter overriding)
            margerite.moo();
            margerite.moo(bernadette);
            Console.WriteLine();

            //Playing with collections 1/2: collection creation
            Zoo zoo = new Zoo();
            zoo.Cows.Add(margerite);
            zoo.Cows.Add(bernadette);
            zoo.Cows.Add(new Cow("Yolande"));
            foreach (Cow cow in zoo.Cows)
            {
                Console.WriteLine(cow.ToString());
            }
            Console.WriteLine();

            //Playing with collections 2/2: removing item
            //Can't remove list items with a foreach loop
            for (int index = 0; index < zoo.Cows.Count; index++)
            {
                Cow currentCow = zoo.Cows[index];
                if (currentCow.GetAge() >= 10)
                {
                    zoo.Cows.Remove(currentCow);
                    index--; //Do not forget otherwise next item in list is skipped
                }
            }
            foreach (Cow cow in zoo.Cows)
            {
                Console.WriteLine(cow.ToString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
