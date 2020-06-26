using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Car : Vehicle
    {
        public Car()
        {
            MaxSpeed = 300;
            Weight = 2000;
            Name = "Car";
        }
    }
}
