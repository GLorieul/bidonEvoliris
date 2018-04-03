using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["a"] = 2;
            dic.Add("b", 3);
            foreach(KeyValuePair<string,int> entry in dic)
            { Console.WriteLine($"{entry.Key} : {entry.Value}"); }

            Participant john = new Participant("John", "smith");
            Participant carlos = new Participant("Carlos", "Santana");

            Company cognitic = new Company("Cognitic");
            Company schoolOfLife = new Company("School of Life");

            Trainer popole = new Trainer("Popole", "Copain", cognitic);
            Trainer bugs = new Trainer("Bugs", "Bunny", schoolOfLife);

            Training badass = new Training("How to become a badass", popole);
            Training swear = new Training("How to swear like a god", popole);
            Training carrot = new Training("La culture de la carotte au fil des siècles", bugs);

            badass.AddParticipant(john);
            swear.AddParticipant(john, carlos);

            Console.WriteLine(john);

            Console.ReadLine();
        }
    }
}
