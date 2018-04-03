using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    class Trainer : Person
    {
        public Company company { get; set; }

        public Trainer() { }
        public Trainer(string firstName, string surname, Company company)
            :base(firstName, surname)
        {
            this.company = company;
        }
    }
}
