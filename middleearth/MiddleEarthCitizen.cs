using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class MiddleEarthCitizen
    {
        private String name;
        public int power;
        public virtual int Power
        {
            get { return power; }
            set { power = value; }
        }

        public MiddleEarthCitizen(String name, int power)
        {
            this.name = name;
            this.power = power;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            String str = this.name + " " + this.power;
            return str;
        }
    }
}
