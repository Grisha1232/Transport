namespace EKRLib
{
    abstract public class Transport
    {
        // приватные поля для хранения значений.
        private string model;
        private uint power;

        /// <summary>
        /// Модель транспорта.
        /// </summary>
        public string Model
        {
            get => model;
            set
            {
                if (value.ToUpper() != value || value.Length != 5 || HaveSpecialSimbols(value))
                    throw new TransportException($"Недопустимая модель {value}");
                else
                    model = value;
            }
        }
        /// <summary>
        /// Мощность транспорта в л.с.
        /// </summary>
        public uint Power
        {
            get => power;
            set
            {
                if (value < 20)
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                else
                    power = value;
            }
        }

        /// <summary>
        /// Конструктор для транспорта.
        /// </summary>
        /// <param name="model">Название модели.</param>
        /// <param name="power">Мощность в л.с.</param>
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Вспомогательный метод для определения не правильности заполнения названии модели.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True если есть специальные символы. False в противном случае</returns>
        private static bool HaveSpecialSimbols(string value)
        {
            for (int i = 0; i < 5; i++)
            {
                if (value[i] > 57 && value[i] < 65 || value[i] > 91)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Запуск двигателя (Звук мотора).
        /// </summary>
        /// <returns>Строка с моделью и звуком.</returns>
        abstract public string StartEngine();

        /// <summary>
        /// Переобпределенный метод ToString().
        /// </summary>
        /// <returns>Строка с описанием модели.</returns>
        public override string ToString() => $"Model: {Model}, Power: {Power}";
    }
}
