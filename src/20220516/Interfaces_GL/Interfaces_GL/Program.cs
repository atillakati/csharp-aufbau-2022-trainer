using Interfaces_GL.Core.Datatypes;
using Interfaces_GL.Fahrzeuge;
using System;
using System.Collections.Generic;


namespace Interfaces_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fahrzeugListe = new Fahrzeug[]
            {
                new Auto(),
                new Sportwagen("Spider", 2020, new Speed{Unit = SpeedUnit.KmPerHour, Value=250}, 8),
                new Fahrrad("KTM SuperSpeed", 2000, 50.0),
                new Schiff(500.5, "MegaTransporter", 1950, new Speed{Value= 8, Unit= SpeedUnit.MetersPerSecond}),
            };

            ShowVehicleInfos(fahrzeugListe);
        }

        private static void DisplayRentPrice(IRentable rentable)
        {
            Console.WriteLine($"Available:               {rentable.IsAvailable}");
            Console.WriteLine($"Price offer for 2 hours: {rentable.CalculateRentPrice(TimeSpan.FromHours(2.0))}");
        }

        private static void ShowVehicleInfos(IEnumerable<Fahrzeug> vehicelList)
        {
            foreach (var vehicle in vehicelList)
            {
                if (vehicle is IRentable rentableVehicle)
                {                    
                    DisplayRentPrice(rentableVehicle);
                }

                vehicle.SpeedUp(new Speed { Value = 2, Unit = SpeedUnit.MetersPerSecond });
                vehicle.DisplayInfos();                
            }
        }
    }
}
