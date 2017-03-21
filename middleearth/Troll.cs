using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Troll : MiddleEarthCitizen
    {
        public Troll(String name, int power) : base(name, power)
        {
            try
            {
                if (power > 15 || power < 11)
                {
                    throw new powerException("11-15");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 11;
            }
            this.power = power;
        }
    }
}
