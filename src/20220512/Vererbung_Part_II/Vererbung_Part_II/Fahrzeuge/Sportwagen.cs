using Vererbung_Part_II.Core.Datatypes;

namespace Vererbung_Part_II.Fahrzeuge
{
    internal class Sportwagen : Auto
    {
        private int _cylinderCount;

        public Sportwagen(string model, int yearOfManufacture, Speed maxSpeed, int cylinderCount)
            :base(model, yearOfManufacture, maxSpeed, "TopFastHitsOnTheRoad")
        {
            _cylinderCount = cylinderCount;
        }

        public int CylinderCount => _cylinderCount;
        

    }
}
