using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Classes
{
    internal class Car
    {
        /// <summary>
        /// id для возможного хранения в БД
        /// </summary>
        public Guid CarId { get; private set; }
        /// <summary>
        /// название
        /// </summary>
        public string Model { get; private set; }
        /// <summary>
        /// скорость
        /// </summary>
        public float Speed { get; private set; }
        /// <summary>
        /// средний расход топлива
        /// </summary>
        public float AvgConsumption { get; private set; }
        /// <summary>
        /// Тип ТС
        /// </summary>
        public typeCar TypeCar { get; protected set; }
        /// <summary>
        /// объем бака
        /// </summary>
        public float FullOilVolume { get; private set; }
        /// <summary>
        /// текущее количество топлива
        /// </summary>
        public float CurrentOilVolume { get; private set; }


        public Car(string model, float speed, float consumption, float fullVolume, float currentVolume) {
            Model = model;
            Speed = speed;
            AvgConsumption = consumption;
            FullOilVolume = fullVolume;
            CurrentOilVolume = currentVolume;
            CarId = Guid.NewGuid();
        }

        /// <summary>
        /// полный запас хода
        /// </summary>
        /// <returns>запасх хода при полном баке</returns>
        public virtual float DistanceOnFullVolume() {
            return calcDistance(FullOilVolume);
        }

        /// <summary>
        /// Запас хода для при текущем количестве топлива 
        /// </summary>
        /// <returns>запас хода</returns>
        public virtual float DistanceOnCurrentVolume() {
            
            return calcDistance(CurrentOilVolume);
        }

        /// <summary>
        /// базовый расчет расхода
        /// </summary>
        /// <param name="volume">объем</param>
        /// <returns>расход</returns>
        /// <exception cref="Exception">событие при делении на 0</exception>
        private float calcDistance(float volume) {
            float distance = 0;
            try
            {
                distance = volume / AvgConsumption * 100;
            }
            catch (DivideByZeroException ex)
            {
                throw new Exception(ex.Message);
            }
            return distance;
        }

        /// <summary>
        /// информация о запасе хода
        /// </summary>
        /// <returns>строковая информация</returns>
        public string PrintInfoFordistance() {
            return $"Запас хода при текущем уровне топлива: {DistanceOnCurrentVolume().ToString()}";
        }

        /// <summary>
        /// Время в пути
        /// </summary>
        /// <param name="distance">Дистанция</param>
        /// <returns>Время</returns>
        /// <exception cref="Exception">ошибка деления на 0</exception>
        public float RoadTime(float distance) {
            float time = float.NaN;
            if (distance > DistanceOnCurrentVolume()) {
                return time;
            }
            try
            {
                time = distance / Speed;
            }
            catch (DivideByZeroException ex) {
                throw new Exception(ex.Message);
            }
            return time;
        }
    }

    /// <summary>
    /// сделано для возможного интегрирования БД
    /// </summary>
    enum typeCar { 
        RaceCar,
        MotorCar,
        TruckCar
    }
}
