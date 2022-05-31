using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_GL
{
    //public abstract class Rentable
    //{
    //    public abstract bool IsAvailable { get; set; }

    //    public abstract decimal PricePerHour { get; set; }

    //    public abstract decimal CalculateRentPrice(TimeSpan rentDuration);

    //}


    internal interface IRentable
    {
        bool IsAvailable { get; set; }

        decimal PricePerHour { get; set; }

        decimal CalculateRentPrice(TimeSpan rentDuration);
    }
}
