using System;
using System.Runtime.Serialization;

namespace EKRLib
{
    /// <summary>
    /// Custom Exception для транспорта.
    /// </summary>
    public class TransportException : Exception
    {
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор с одним параметром.
        /// </summary>
        /// <param name="message">Сообщение для вывода.</param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструктор с двумя параметрами.
        /// </summary>
        /// <param name="message">Сообщение для вывода.</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public TransportException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Конструктор с двумя параметрами.
        /// </summary>
        /// <param name="info">Информация о сериализации.</param>
        /// <param name="context">Поток.</param>
        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
