using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    class Training
    {
        public string name { get; set; }
        public Trainer trainer { get; set; }
        public List<Participant> participants { get; set; } = new List<Participant>();
        public TimeSpan timeSpan { get; set; }
        private Dictionary<Participant, Mark> marks { get; set; }
        
        public Training() { }
        public Training(string name)
        { this.name = name; }
        public Training(string name, Trainer trainer)
            :this(name)
        { this.trainer = trainer; }

        public void AddParticipant(Participant participant)
        { participant.RegisterToTraining(this); }

        public void AddParticipant(params Participant[] participants)
        {
            foreach(Participant participant in participants)
            { AddParticipant(participant); }
        }

        public void GiveMark(Participant participant, Mark mark)
        {
            bool isAParticipant = participants.Contains(participant);
            if (isAParticipant)
            { marks[participant] = mark; }
            else
            {
                Console.WriteLine($"{participant.firstName} {participant.surname}"
                    + " does not participate to the training and hence no marks"
                    + " can be given to him/her.");
            }
        }

        public void GiveMark(Dictionary<Participant, Mark> marks)
        {
            foreach(KeyValuePair<Participant, Mark> entry in marks)
            { GiveMark(entry.Key, entry.Value); }
        }
    }
}
