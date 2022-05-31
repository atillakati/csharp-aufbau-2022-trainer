
using Interfaces_GL.Core.Datatypes;
using System;

namespace Interfaces_GL.Fahrzeuge
{
    internal class Fahrrad : Fahrzeug, IRentable
    {
        private readonly double _radDurchmesseInCm;
        private bool _isAvailable;
        private decimal _pricePerHour;

        public Fahrrad(string model, int bauJahr, double radDurchmesseInCm)
            : base(model, bauJahr, new Speed { Unit = SpeedUnit.MetersPerSecond, Value = 5 })
        {
            _radDurchmesseInCm = radDurchmesseInCm;

            _isAvailable = true;
            _pricePerHour = 15.0m;
        }

        public double RadDurchmesseInCm => _radDurchmesseInCm;

        public bool IsAvailable 
        {
            get => _isAvailable; 
            set => _isAvailable = value;         
        }

        public decimal PricePerHour 
        { 
            get => _pricePerHour;
            set => _pricePerHour = value;
        }

        public decimal CalculateRentPrice(TimeSpan rentDuration)
        {
            return _pricePerHour * (decimal)rentDuration.TotalHours;
        }
    }
}
