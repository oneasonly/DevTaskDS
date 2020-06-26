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
            Name = "Vehicle";
        }
        /// <summary>
        /// in kilometers per hour
        /// </summary>
        public int MaxSpeed { get; protected set; }
        /// <summary>
        /// in kilograms
        /// </summary>
        public double Weight { get; protected set; }
        public string Name { get; protected set; }
    }
}
