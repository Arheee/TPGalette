using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using galette.Class;

namespace galette.Class
{
     class Randomizer
    {
        private Random random;

        public Randomizer()
        {
            random = new Random();
        }

        public int GetRandomNumber(int max)
        {
            return random.Next(max);
        }
    }
}
