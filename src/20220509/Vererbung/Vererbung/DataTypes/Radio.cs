using System;

namespace Vererbung.DataTypes
{
    internal class Radio
    {
        private double _frequency;
        private string _senderName;
        private PowerState _powerState;


        public Radio()
        {
            _frequency = 99.5;
            _senderName = "Hitradio";
            _powerState = PowerState.Off;
        }


        public PowerState PowerState
        {
            get { return _powerState; }
        }

        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }


        public void ChangeState(PowerState newPowerState)
        {
            if(_powerState != PowerState.Defective)
            {
                _powerState = newPowerState;
            }
        }

        public void DisplayInfos()
        {
            Console.WriteLine($"Radiopower: {_powerState}");
            Console.WriteLine($"Sender: {_senderName} [{_frequency} MHz]");
        }
    }
}