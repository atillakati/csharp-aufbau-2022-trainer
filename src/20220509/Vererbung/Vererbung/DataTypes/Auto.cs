using System;

namespace Vererbung.DataTypes
{
    internal class Auto
    {
        private string _model;
        private int _yearOfManufacture;
        private Speed _currentSpeed;
        private Speed _maxSpeed;
        private SpeedUnit _speedUnit;

        private Radio _autoRadio;

        public Auto(string model, int yearOfManufacture, Speed maxSpeed)
        {
            _model = model;
            _yearOfManufacture = yearOfManufacture;
            _maxSpeed = maxSpeed;
            _speedUnit = maxSpeed.Unit;

            _currentSpeed = new Speed { Value = 0, Unit = _speedUnit };

            _autoRadio = new Radio();
        }


        public Speed MaxSpeed
        {
            get { return _maxSpeed; }

        }

        public Speed CurrentSpeed
        {
            get { return _currentSpeed; }
        }

        public SpeedUnit SpeedUnit
        {
            get { return _speedUnit; }
            //set { _speedUnit = value; }
        }

        public int YearOfManufacture
        {
            get { return _yearOfManufacture; }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _model = value;
                }
            }
        }

        public double RadioFrequency
        {
            get { return _autoRadio.Frequency; }
        }

        public void ChangeRadioPower(bool isOn)
        {
            if (isOn)
            {
                _autoRadio.ChangeState(PowerState.On);
            }
            else
            {
                _autoRadio.ChangeState(PowerState.Off);
            }
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

        public void DisplayInfos()
        {
            Console.WriteLine($"Model: {_model} ({_yearOfManufacture})");
            Console.WriteLine($"Speed: {_currentSpeed.Value:f2} / {_maxSpeed.Value:f2} {_speedUnit.GetUnitText()}");
            Console.WriteLine();
        }
    }
}