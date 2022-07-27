using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Classes
{
    internal class MotorCar : Car
    {
        /// <summary>
        /// максимальное число пассажиров
        /// </summary>
        public int MaxPassengers { get; private set; }
        /// <summary>
        /// число пассажиров(с проверкой)
        /// </summary>
        public int Passengers { get => Passengers; set { Passengers = (value > MaxPassengers) ? MaxPassengers : value; } }
        public MotorCar(string model, float speed, float consumption, float fullVolume, float currentVolume, int maxPassengers) : base(model, speed, consumption, fullVolume, currentVolume)
        {
            TypeCar = typeCar.MotorCar;
            this.MaxPassengers = maxPassengers;
        }

        public override float DistanceOnFullVolume()
        {
            float fullDistance = base.DistanceOnFullVolume();
            for (int i = 0; i < Passengers; i++) {
                fullDistance *= 0.94f;
            }
            return fullDistance;
        }

        public override float DistanceOnCurrentVolume()
        {
            float fullDistance = base.DistanceOnCurrentVolume();
            for (int i = 0; i < Passengers; i++)
            {
                fullDistance *= 0.94f;
            }
            return fullDistance;
        }



    }
}
