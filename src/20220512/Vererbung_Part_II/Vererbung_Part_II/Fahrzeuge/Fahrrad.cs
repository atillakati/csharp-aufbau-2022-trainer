
using Vererbung_Part_II.Core.Datatypes;

namespace Vererbung_Part_II.Fahrzeuge
{
    internal class Fahrrad : Fahrzeug
    {
        private readonly double _radDurchmesseInCm;

        public Fahrrad(string model, int bauJahr, double radDurchmesseInCm)
            :base(model, bauJahr, new Speed { Unit = SpeedUnit.MetersPerSecond, Value=5})
        {
            _radDurchmesseInCm = radDurchmesseInCm;
        }

        public double RadDurchmesseInCm => _radDurchmesseInCm;
    }
}
