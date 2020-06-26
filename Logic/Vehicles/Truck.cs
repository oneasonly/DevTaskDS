using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Truck : Vehicle
    {
        public Truck()
        {
            MaxSpeed = 200;
            Weight = 30000;
            Name = "Truck";
        }
    }
}
