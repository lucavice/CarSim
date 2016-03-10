
using System;
using System.Collections.Generic;

namespace CarSim.Model
{
    public class Car
    {
        private double _speed;
        private double _rpm;

        public double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;

                NewDataAvailable?.Invoke();
            }
        }

        public double Rpm
        {
            get { return _rpm; }
            set
            {
                _rpm = value;

                NewDataAvailable?.Invoke();
            }
        }

        public delegate void DataHandler();

        public event DataHandler NewDataAvailable;

    }
}
