using Polymorphie.Core.Datatypes;
using System;

namespace Polymorphie.Fahrzeuge
{
    internal abstract class Fahrzeug
    {
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

        public abstract string Model { get; }

        public abstract SpeedUnit SpeedUnit { get; }
        

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


        public abstract void DisplayInfos();

        public abstract void SpeedUp(Speed delta);
                    
        

    }
}
