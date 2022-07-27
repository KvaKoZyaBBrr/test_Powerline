using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Classes
{
    internal class RaceCar : Car
    {
        public RaceCar(string model, float speed, float consumption, float fullVolume, float currentVolume) : base(model, speed, consumption, fullVolume, currentVolume)
        {
            TypeCar = typeCar.RaceCar;
        }
    }
}
