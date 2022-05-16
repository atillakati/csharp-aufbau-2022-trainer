
using Polymorphie.Core.Datatypes;
using System;

namespace Polymorphie.Fahrzeuge
{
    internal class Fahrrad : Fahrzeug
    {
        private readonly double _radDurchmesseInCm;

        public Fahrrad(string model, int bauJahr, double radDurchmesseInCm)
            : base(model, bauJahr, new Speed { Unit = SpeedUnit.MetersPerSecond, Value = 5 })
        {
            _radDurchmesseInCm = radDurchmesseInCm;
        }

        public double RadDurchmesseInCm => _radDurchmesseInCm;

        public override void DisplayInfos()
        {
            Console.WriteLine($"Model:           {Model} ({YearOfManufacture})");
            Console.WriteLine($"Rad-Durchmesser: {_radDurchmesseInCm:f1} Zoll ");
            Console.WriteLine($"Speed:           {CurrentSpeed.Value:f2} / {MaxSpeed.Value:f2} {SpeedUnit.GetUnitText()}");
            Console.WriteLine();
        }
    }
}
