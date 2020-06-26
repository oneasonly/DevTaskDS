using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Bus : Vehicle
    {
        public Bus()
        {
            MaxSpeed = 150;
            Weight = 15000;
            Name = "Bus";
        }
    }
}
