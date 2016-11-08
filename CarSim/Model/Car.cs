
using System;
using System.Collections.Generic;

namespace CarSim.Model
{
    public class Car: ModelNotification
    {
        private double _speed;
        private double _rpm;

        public double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;

                OnModelChanged();
            }
        }

        public double Rpm
        {
            get { return _rpm; }
            set
            {
                _rpm = value;

                OnModelChanged();
            }
        }
    }
}
