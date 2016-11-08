using System.Globalization;
using CarSim.Model;
using CarSim.Services;
using Microsoft.Practices.Prism.Mvvm;

namespace CarSim.ViewModel
{
    public class ViewModel: BindableBase
    {
        private double _speedometerAngle;

        private double _tachometerAngle;

        private string _speedString;

        private string _rpmString;

        private readonly Car _car = new Car();

        public ViewModel()
        {
            _car.ModelChanged += Car_NewDataAvailable;
            int refreshRate = 300; //ms
            new CarDataService(_car, refreshRate);
        }

        private void Car_NewDataAvailable()
        {
            // The speedometer has different scaling > 80 km/h
            if (_car.Speed < 80)
            {
                // Mapping angle for range 0-80 km/h
                SpeedometerAngle = 130*(_car.Speed)/100 - 130;
            }
            else
            {
                // Mapping angle for range 80-260 km/h
                SpeedometerAngle = 130 * (_car.Speed) / 160 - 81.25;
            }

            // Mapping 0-10'000 rpm to -130/130 degrees
            TachometerAngle = 260*(_car.Rpm)/10000 - 130; 

            SpeedString = _car.Speed.ToString(CultureInfo.InvariantCulture);
            RpmString = _car.Rpm.ToString(CultureInfo.InvariantCulture);

        }

        public double SpeedometerAngle
        {
            get { return _speedometerAngle; }
            set { SetProperty(ref _speedometerAngle, value); }
        }

        public double TachometerAngle
        {
            get { return _tachometerAngle; }
            set { SetProperty(ref _tachometerAngle, value); }
        }

        public string SpeedString
        {
            get { return _speedString; }
            set { SetProperty(ref _speedString, value); }
        }

        public string RpmString
        {
            get { return _rpmString; }
            set { SetProperty(ref _rpmString, value); }
        }
    }
}
