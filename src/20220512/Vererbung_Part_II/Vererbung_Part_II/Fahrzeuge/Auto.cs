using System;
using Vererbung_Part_II.Core.Datatypes;

namespace Vererbung_Part_II.Fahrzeuge
{    
    internal class Auto : Fahrzeug
    {
        private Radio _autoRadio;

        /// <summary>
        /// Erzeugt eine default Instanz mit VW Golf als Modelbeschreibung, das aktuelle Jahr und maxSpeed = 180km/h
        /// </summary>
        public Auto()
            : base("VW Golf", DateTime.Now.Year, new Speed { Unit = SpeedUnit.KmPerHour, Value = 180 })
        {
            _autoRadio = new Radio();
        }
        
        public Auto(string model, int yearOfManufacture)
            : base(model, yearOfManufacture, new Speed { Unit= SpeedUnit.KmPerHour, Value=180})
        {
            _autoRadio = new Radio();
            _autoRadio.SenderName = "Hitradio V2";
        }

        public Auto(string model, int yearOfManufacture, Speed maxSpeed, string defaultSenderName) 
            :base(model, yearOfManufacture, maxSpeed)
        {                       
            _autoRadio = new Radio();
            _autoRadio.SenderName = defaultSenderName;
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
    }
}