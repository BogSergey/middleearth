using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class WoodenElf : Elf
    {
        public WoodenElf(String name, int power) : base(name, power)
        {
            this.power = 6;
        }
    }
}
