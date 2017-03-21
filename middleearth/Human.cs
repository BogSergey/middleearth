using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Human : MiddleEarthCitizen
    {
        public Human(String name, int power) : base(name, power)
        {
            try
            {
                if (power > 8 || power < 7)
                {
                    throw new powerException("7-8");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 7;
            }
            this.power = power;
        }
    }
}
