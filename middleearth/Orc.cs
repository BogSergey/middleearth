using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Orc : MiddleEarthCitizen
    {
        public Wolf OwnWolf { get; set; }

        public class Wolf : MiddleEarthCitizen
        {
            public Wolf(String name, int power)
                : base(name, power)
            {
            }
        }

        public Orc(String name, int power)
            : base(name, power)
        {
        }

        public Orc(String name, int power, Wolf wolf) : base(name, power)
        {
            this.OwnWolf = wolf;

            try
            {
                if (power > 10 || power < 8)
                {
                    throw new powerException("8-10");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 8;
            }
            this.power = power;
        }
    }
}
