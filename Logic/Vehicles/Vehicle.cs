using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// base class of vehicle
    /// </summary>
    public class Vehicle
    {
        public Vehicle()
        {
            MaxSpeed = 150;
            Weight = 50;
        }
        public int MaxSpeed { get; }
        public double Weight { get; }
    }
}
