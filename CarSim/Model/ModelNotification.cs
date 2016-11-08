using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSim.Model
{
    public class ModelNotification
    {
        public delegate void DataHandler();

        public event DataHandler ModelChanged;

        public void OnModelChanged()
        {
            ModelChanged?.Invoke();
        }
    }
}
