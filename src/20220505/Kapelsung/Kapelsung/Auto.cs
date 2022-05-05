namespace Kapelsung
{
    internal class Auto
    {
        private string _model;
        private int _yearOfManufacture;
        private int _currentSpeed;
        private int _maxSpeed;

        public Auto(string model, int yearOfManufacture, int maxSpeed)
        {
            _model = model;
            _yearOfManufacture = yearOfManufacture;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
        }

        public int MaxSpeed
        {
            get { return _maxSpeed; }
            
        }

        public int CurrentSpeed
        {
            get { return _currentSpeed; }            
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
    }
}