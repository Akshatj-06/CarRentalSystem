using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
    public class Payment
    {
        public int paymentID { get; set; }
        public int leaseID { get; set; }
        public DateTime paymentDate { get; set; }
        public int amount{ get; set; }
    }
}
