using System;
using System.Timers;
using CarSim.Model;

namespace CarSim.Services
{
    public class CarDataService
    {
        private readonly Car _car;

        public CarDataService(Car car, int refreshRate)
        {
            _car = car;

            _car.Speed = 130.0; // init speed value
            _car.Rpm = 5000; // init rpm value

            var timer = new Timer(refreshRate);
            timer.Elapsed += RefreshData;
            timer.Enabled = true;
        }

        private void RefreshData(object s, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            _car.Speed = rnd.Next(Math.Max(30, (int)_car.Speed - 15), Math.Min(260, (int) _car.Speed + 15)); // Incremental random 0 - 260 km/h
            _car.Rpm = rnd.Next(Math.Max(1000, (int)_car.Rpm - 500), Math.Min(10000, (int)_car.Rpm + 500)); //Incremental random 0 - 10'000 rpm
        }
    }
}
