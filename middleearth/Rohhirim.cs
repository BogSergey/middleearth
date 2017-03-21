using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Rohhirim : Human, FirstStrike
    {
        public Rohhirim(String name, int power, Horse horse)
            : base(name, power)
        {
            this.OwnHorse = horse;
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

        public void FirstStrike()
        {
        }
    }
}
