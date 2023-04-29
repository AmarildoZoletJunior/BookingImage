using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingImage.Service.Exceptions
{
    public class NotFind : Exception
    {
        public NotFind(string message) : base(message) 
        {

        }

    }
}
