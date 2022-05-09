using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vererbung.DataTypes;

namespace Vererbung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myCar = new Auto("BadMobil V8", 2020, new Speed { Unit = SpeedUnit.KmPerHour, Value = 190.0 });

            myCar.DisplayInfos();

            myCar.ChangeRadioPower(true);
            
        }

        //static void Main(string[] args)
        //{
        //    var myCar = new Auto("BadMobil V2", 1980, new Speed { Value = 1, Unit = SpeedUnit.Mach });

        //    myCar.DisplayInfos();

        //    //Beschleunigen um 59 mph
        //    myCar.SpeedUp(new Speed 
        //    { 
        //        Value = 59, 
        //        Unit = SpeedUnit.MilesPerHour
        //    });
        //    myCar.DisplayInfos();

        //    //Beschleunigen um 150 km/h
        //    myCar.SpeedUp(new Speed
        //    {
        //        Value = 150,
        //        Unit = SpeedUnit.KmPerHour
        //    });
        //    myCar.DisplayInfos();

        //    //konvertierung von Einheit x nach km/h
        //    var mySpeed = myCar.CurrentSpeed
        //                            .ConvertTo()
        //                            .ConvertFrom(SpeedUnit.KmPerHour);

        //    //manuelle Ausgabe
        //    Console.WriteLine($"Speed: {mySpeed.Value:f2} {mySpeed.Unit.GetUnitText()}");
        //}
    }
}
