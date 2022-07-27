using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Classes
{
    internal class TruckCar : Car
    {
        /// <summary>
        /// максимальная грузоподъемность
        /// </summary>
        public float Capacity { get; private set; }
        /// <summary>
        /// груз(с проверкой)
        /// </summary>
        public float Weight { get => Weight; set { Weight = (value > Capacity) ? Capacity : value; } }

        public TruckCar(string model, float speed, float consumption, float fullVolume, float currentVolume, float capacity) : base(model, speed, consumption, fullVolume, currentVolume)
        {
            TypeCar = typeCar.TruckCar;
            Capacity = capacity;
        }


        public override float DistanceOnFullVolume()
        {
            float fullDistance = base.DistanceOnFullVolume();
            for (int i = 0; i < Weight; i++)
            {
                fullDistance *= 0.94f;
            }
            return fullDistance;
        }

        public override float DistanceOnCurrentVolume()
        {
            float fullDistance = base.DistanceOnCurrentVolume();
            for (int i = 0; i < Weight; i++)
            {
                fullDistance *= 0.94f;
            }
            return fullDistance;
        }
    }
}
