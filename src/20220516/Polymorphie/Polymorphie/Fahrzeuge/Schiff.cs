using Polymorphie.Core.Datatypes;
using System;

namespace Polymorphie.Fahrzeuge
{
    internal class Schiff : Fahrzeug
    {
        private readonly double _frachtraumGroesseInKubikMeter;

        public Schiff(double frachtraumGroesseInKubikMeter, string model, int yearOfManufacture, Speed maxSpeed)
            : base(model, yearOfManufacture, maxSpeed)
        {
            _frachtraumGroesseInKubikMeter = frachtraumGroesseInKubikMeter;
        }

        public double FrachtraumGroesseInKubikMeter => _frachtraumGroesseInKubikMeter;


        public override void DisplayInfos()
        {
            Console.WriteLine($"Model: {Model} ({YearOfManufacture})");
            Console.WriteLine($"Speed: {CurrentSpeed.Value:f2} / {MaxSpeed.Value:f2} {SpeedUnit.GetUnitText()}");
            Console.WriteLine($"Frachtraum: {_frachtraumGroesseInKubikMeter:f2} m³");
            Console.WriteLine();
            
        }
    }
}
