using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Goblin : MiddleEarthCitizen
    {
        public Goblin(String name, int power) : base(name, power)
        {
            try
            {
                if (power > 5 || power < 2)
                {
                    throw new powerException("2-5");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 2;
            }
            this.power = power;
        }
    }
}
