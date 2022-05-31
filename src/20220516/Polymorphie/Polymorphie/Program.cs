using Polymorphie.Core.Datatypes;
using Polymorphie.Fahrzeuge;
using System.Collections.Generic;

namespace Polymorphie
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

        private static void ShowVehicleInfos(IEnumerable<Fahrzeug> vehicelList)
        {
            foreach (var vehicle in vehicelList)
            {
                vehicle.SpeedUp(new Speed { Value = 2, Unit = SpeedUnit.MetersPerSecond });
                vehicle.DisplayInfos();
            }
        }
    }
}
