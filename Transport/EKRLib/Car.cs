using System;
using System.Collections.Generic;
using System.Linq;
namespace EKRLib
{
    /// <summary>
    /// Класс для определения машины.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор для машины.
        /// </summary>
        /// <param name="model">Название модели.</param>
        /// <param name="power">Мощность в л.с.</param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Запуск двигателя (Звук мотора).
        /// </summary>
        /// <returns>Строка с моделью и звуком.</returns>
        public override string StartEngine() => $"{Model}: Vrooom";

        /// <summary>
        /// Переобпределенный метод ToString().
        /// </summary>
        /// <returns>Строка с описанием модели.</returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}
