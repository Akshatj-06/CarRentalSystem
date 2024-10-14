﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.MyExceptions
{
    using System;

    namespace CarRentalSystem.MyExceptions
    {
        public class LeaseNotFoundException : Exception
        {
            public LeaseNotFoundException() : base("Lease not found.")
            {
            }

            public LeaseNotFoundException(string message) : base(message)
            {
            }

            public LeaseNotFoundException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }

}
