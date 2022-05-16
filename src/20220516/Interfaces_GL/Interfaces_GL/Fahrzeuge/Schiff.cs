using Interfaces_GL.Core.Datatypes;

namespace Interfaces_GL.Fahrzeuge
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
    }
}
