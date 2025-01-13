using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galette.Class
{
     class ParticipantManager
    {
        private List<string> participants;

        public ParticipantManager()
        {
            participants = new List<string>();
        }
        public void AddParticipant(string name)
        {
            participants.Add(name);
        }
        public string RemoveRandomParticipant(Randomizer randomizer)
        {
            if (participants.Count == 0) return null; 
            int index = randomizer.GetRandomNumber(participants.Count);
            string participant = participants[index];
            participants.RemoveAt(index);
            return participant;
        }
        public bool HasParticipants()
        {
            return participants.Count > 0;
        }

        public int Count()
        {
            return participants.Count;
        }
        public string GetRandomParticipant(Randomizer randomizer)
        {
            if (participants.Count == 0) return null; 

            int index = randomizer.GetRandomNumber(participants.Count); 
            return participants[index]; 
        }
    }
}
