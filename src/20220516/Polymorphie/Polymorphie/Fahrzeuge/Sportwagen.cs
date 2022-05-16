using Polymorphie.Core.Datatypes;
using System;

namespace Polymorphie.Fahrzeuge
{
    internal class Sportwagen : Auto
    {
        private int _cylinderCount;

        public Sportwagen(string model, int yearOfManufacture, Speed maxSpeed, int cylinderCount)
            : base(model, yearOfManufacture, maxSpeed, "TopFastHitsOnTheRoad")
        {
            _cylinderCount = cylinderCount;
        }

        public int CylinderCount => _cylinderCount;

        public override void DisplayInfos()
        {
            Console.WriteLine($"Anzahl Zylinder: {_cylinderCount}");
            base.DisplayInfos();            
        }

    }
}
