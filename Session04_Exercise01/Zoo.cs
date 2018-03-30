using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise01
{
    class Zoo
    {
        public Zoo()
        {
            Cows = new List<Cow>();
        }

        public List<Cow> Cows { get; set; }
    }
}
