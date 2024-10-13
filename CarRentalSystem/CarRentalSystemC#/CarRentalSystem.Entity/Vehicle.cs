using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
    public class Vehicle
    {
        public int vehicleID { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public DateTime year { get; set; }
        public int dailyRate { get; set; }
        public string status { get; set; }
        public int passangerCapacity { get; set; }
        public int engineCapacity { get; set; }
    }
}
