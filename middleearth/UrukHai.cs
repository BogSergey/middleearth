using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class UrukHai : Orc
    {
        public UrukHai(String name, int power) : base(name, power)
        {
            try
            {
                if (power > 12 || power < 10)
                {
                    throw new powerException("10-12");
                }
            }
            catch (powerException p)
            {
                Console.WriteLine(p.Message);
                power = 10;
            }
            this.power = power;
        }
    }
}
