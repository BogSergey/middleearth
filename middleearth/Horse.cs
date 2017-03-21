using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Horse : MiddleEarthCitizen
    {
        public Horse(String name, int power)
            : base(name, power)
        {
            try
            {
                if (power > 5 || power < 4)
                {
                    throw new powerException("4-5");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 4;
            }
            this.power = power;
        }
    }
}
