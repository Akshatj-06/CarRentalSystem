using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.MyExceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException() : base("Car not found.")
        {
        }

        public CarNotFoundException(string message) : base(message)
        {
        }

        public CarNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
