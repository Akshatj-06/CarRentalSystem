using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
    public class Lease
    {
        public int leaseID { get; set; }
        public int customerID { get; set; }
        public int vehicleID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate{ get; set; }
        public string type { get; set; }
      
    }
}
