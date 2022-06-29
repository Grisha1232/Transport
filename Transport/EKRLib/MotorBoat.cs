namespace EKRLib
{
    /// <summary>
    /// Класс для определения моторной лодки.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор для моторной лодки.
        /// </summary>
        /// <param name="model">Название модели.</param>
        /// <param name="power">Мощность в л.с.</param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Запуск двигателя (Звук мотора).
        /// </summary>
        /// <returns>Строка с моделью и звуком.</returns>
        public override string StartEngine() => $"{Model}: Brrrbrr";

        /// <summary>
        /// Переобпределенный метод ToString().
        /// </summary>
        /// <returns>Строка с описанием модели.</returns>
        public override string ToString() => "MotorBoat. " + base.ToString();
    }
}
