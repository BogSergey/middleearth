using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Wizard : MiddleEarthCitizen, FirstStrike
    {
        public Wizard(String name, Horse horse) : base(name, 20)
        {
            {
                this.OwnHorse = horse;
            }
        }

        public override int Power
        {
            get
            {
                return (OwnHorse != null ? power + OwnHorse.Power : power);
            }
            set { power = value; }
        }

        protected Horse horse1;
        public Horse OwnHorse
        {
            get { return horse1; }
            set { horse1 = value; }
        }

        public void setPower(int power)
        {
            this.power = power;
        }

        public int getPower()
        {
            return this.power;
        }

        public void FirstStrike()
        {
        }
    }
}
