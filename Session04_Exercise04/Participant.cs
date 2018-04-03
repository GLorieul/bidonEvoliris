using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    class Participant : Person
    {
        private List<Training> _trainingsRegisteredTo = new List<Training>();

        public Participant() { }

        public Participant(string firstName, string surname)
            :base(firstName, surname)
        { }

        public void RegisterToTraining(Training training)
        {
            _trainingsRegisteredTo.Add(training);
            training.participants.Add(this);
        }

        public void RegisterToTraining(params Training[] training)
        {
            foreach(Training oneTraining in training)
            { RegisterToTraining(oneTraining); }
        }

        public override string ToString()
        {
            string message = base.ToString() + ", and I'm participating to\n";
            foreach(Training eachTraining in _trainingsRegisteredTo)
            {
                message += "\t" + eachTraining.name + "\n";
            }
            return message;
        }
    }
}
