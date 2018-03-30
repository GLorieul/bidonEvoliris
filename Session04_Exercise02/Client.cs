using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise02
{
    class Client : Person
    {
        //We use a string instead of int because
        // - No need for maths operator
        // - Prevents overflow
        // - Handles client numbers starting with '0'
        public string NumClient { get; set; }

        //Will call Person() even if :base() is not explicitly specified
        public Client()
        {
            Console.WriteLine("Now within Client.Client(void)");
        }

        public Client(string numClient, string firstName, string surname)
            : base(firstName, surname)
        {
            Console.WriteLine("Now within Client.Client(string, string, string)");
            NumClient = numClient;
        }

        public override void PresentYourself()
        {
            Console.WriteLine($"NumClient={NumClient}");
        }

        public override void roll()
        {
            Console.WriteLine("Do a barrel roll!");
        }
    }
}
