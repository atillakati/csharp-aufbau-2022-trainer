using System;
using Vererbung_Part_II.Core.Datatypes;

namespace Vererbung_Part_II.Fahrzeuge
{
    internal class Fahrzeug
    {
        private string _model;
        private Speed _currentSpeed;
        private Speed _maxSpeed;
        private SpeedUnit _speedUnit;
        private int _yearOfManufacture;
        private ConsoleColor _color;

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Fahrzeug(string model, int yearOfManufacture, Speed maxSpeed, ConsoleColor color)
        {
            _color = color;
            _model = model;
            _yearOfManufacture = yearOfManufacture;
            _maxSpeed = maxSpeed;
            _speedUnit = maxSpeed.Unit;

            _currentSpeed = new Speed { Value = 0, Unit = _speedUnit };
        }


        public Fahrzeug(string model, int yearOfManufacture, Speed maxSpeed)
        {
            _color = ConsoleColor.White;
            _model = model;
            _yearOfManufacture = yearOfManufacture;
            _maxSpeed = maxSpeed;
            _speedUnit = maxSpeed.Unit;

            _currentSpeed = new Speed { Value = 0, Unit = _speedUnit };            
        }

        public string Model
        {
            get { return _model; }            
        }

        public SpeedUnit SpeedUnit
        {
            get { return _speedUnit; }
            //set { _speedUnit = value; }
        }

        public Speed MaxSpeed
        {
            get { return _maxSpeed; }

        }

        public Speed CurrentSpeed
        {
            get { return _currentSpeed; }
        }

        public int YearOfManufacture
        {
            get { return _yearOfManufacture; }
        }


        public void DisplayInfos()
        {
            Console.WriteLine($"Model: {_model} ({_yearOfManufacture})");
            Console.WriteLine($"Speed: {_currentSpeed.Value:f2} / {_maxSpeed.Value:f2} {_speedUnit.GetUnitText()}");            
            Console.WriteLine();
        }

        public void SpeedUp(Speed delta)
        {
            var deltaWithDefaultUnit = delta.ConvertTo();
            var currentSpeedWithDefaultUnit = _currentSpeed.ConvertTo();
            var maxSpeedWithDefaultUnit = _maxSpeed.ConvertTo();

            var newSpeed = currentSpeedWithDefaultUnit.Value + deltaWithDefaultUnit.Value;

            if (newSpeed <= maxSpeedWithDefaultUnit.Value && newSpeed >= 0)
            {
                currentSpeedWithDefaultUnit = new Speed { Value = newSpeed, Unit = SpeedUnit.MetersPerSecond };

                _currentSpeed = currentSpeedWithDefaultUnit.ConvertFrom(_speedUnit);
            }
        }

    }
}
