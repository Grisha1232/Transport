using System;
using System.IO;
using System.Text;
using EKRLib;

namespace mainProgram
{
    internal class Program
    {
        static readonly Random random = new();
        static void Main()
        {
            do
            {
                Transport[] transports = new Transport[random.Next(6, 10)];
                GenerateMassTransport(transports);
                
                string separator = Path.DirectorySeparatorChar.ToString();
                string beforeFileName = ".." + separator + ".." + separator + ".." + separator + ".." + separator;
                string carsFileName = "Cars.txt";
                string motorBoatsFileName = "MotorBoats.txt";

                // Проверка на существующий файл и изменение название если существует.
                CheckFileExistanceForCars(beforeFileName, ref carsFileName);
                CheckFileExistanceForBoats(beforeFileName, ref motorBoatsFileName);
                
                // Создание строк для записи в отдельные файлы
                string toCarsFile = "";
                string toMotorBoatsFile = "";
                SetDataToWrite(transports, ref toCarsFile, ref toMotorBoatsFile);

                // Запись в файлы.
                WriteDataInFiles(carsFileName, toCarsFile, motorBoatsFileName, toMotorBoatsFile);
                
                Console.WriteLine($"Данные о созданых транспортах были записаны в файлы {carsFileName.Replace(beforeFileName, "")} и {motorBoatsFileName.Replace(beforeFileName, "")}.");
                Console.WriteLine("Нажмите любую клавишу, чтобы повторить, или ESC для выхода из программы.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Генерация правильной модели машины или лодки.
        /// </summary>
        /// <returns>Строка содержащая название модели.</returns>
        private static string GenerateModel()
        {
            string model = "";
            for (int i = 0; i < 5; i++)
            {
                if (random.Next(0, 2) == 1)
                    model += (char)random.Next(48, 58);
                else
                    model += (char)random.Next(65, 91);
            }
            return model;
        }

        /// <summary>
        /// Вспомогательный метод для генерации массива.
        /// </summary>
        /// <param name="transports">Массив.</param>
        private static void GenerateMassTransport(Transport[] transports)
        {
            // Генерация массива транспортом.
            for (int i = 0; i < transports.Length; i++)
            {
                string model = GenerateModel();
                // Выбор генерации (Машина или моторная лодка).
                if (random.Next(0, 2) == 1)
                {
                    try
                    {
                        transports[i] = new Car(model, (uint)random.Next(10, 100));
                    }
                    catch (TransportException exception)
                    {
                        Console.WriteLine(exception.Message);
                        i--;
                        continue;
                    }
                }
                else
                {
                    try
                    {
                        transports[i] = new MotorBoat(model, (uint)random.Next(10, 100));
                    }
                    catch (TransportException exception)
                    {
                        Console.WriteLine(exception.Message);
                        i--;
                        continue;
                    }
                }
                Console.WriteLine(transports[i].StartEngine());
            }
        }

        /// <summary>
        /// Проверка на существование файла для Машин
        /// </summary>
        /// <param name="beforeFileName">Директория</param>
        /// <param name="fileName">Название файла</param>
        private static void CheckFileExistanceForCars(string beforeFileName, ref string fileName)
        {
            int versionCar = 1;
            while (File.Exists(beforeFileName + fileName))
            {
                fileName = $"Cars{versionCar}.txt";
                versionCar++;
            }
            fileName = beforeFileName + fileName;
        }

        /// <summary>
        /// Проверка на существование файла для Моторных лодок
        /// </summary>
        /// <param name="beforeFileName">Директория</param>
        /// <param name="fileName">Название файла</param>
        private static void CheckFileExistanceForBoats(string beforeFileName, ref string fileName)
        {
            int versionBoat = 1;
            while (File.Exists(beforeFileName + fileName))
            {
                fileName = $"MotorBoats{versionBoat}.txt";
                versionBoat++;
            }
            fileName = beforeFileName + fileName;
        }

        /// <summary>
        /// Запись данных в файлы.
        /// </summary>
        /// <param name="carsFileName">Путь файла для машин.</param>
        /// <param name="toCarsFile">Данные для записи машин.</param>
        /// <param name="motorBoatsFileName">Путь файла для моторных лодок.</param>
        /// <param name="toMotorBoatsFile">Данные для записи моторных лодок.</param>
        private static void WriteDataInFiles(string carsFileName, string toCarsFile, string motorBoatsFileName, string toMotorBoatsFile)
        {
            using (FileStream carsFile = new(carsFileName, FileMode.CreateNew))
            using (FileStream motorsFile = new(motorBoatsFileName, FileMode.CreateNew))
            {
                carsFile.Write(Encoding.Unicode.GetBytes(toCarsFile));
                motorsFile.Write(Encoding.Unicode.GetBytes(toMotorBoatsFile));
            }
        }

        /// <summary>
        /// Сортировка данных на машины и моторные лодки.
        /// </summary>
        /// <param name="transports">Массив с транспортом.</param>
        /// <param name="toCarsFile">Ссылка куда записать данные машин.</param>
        /// <param name="toMotorBoatsFile">Ссылка куда записать данные моторных лодок.</param>
        private static void SetDataToWrite(Transport[] transports, ref string toCarsFile, ref string toMotorBoatsFile)
        {
            foreach (var transport in transports)
            {
                if (transport is Car)
                    toCarsFile += transport.ToString() + "\n";
                else
                    toMotorBoatsFile += transport.ToString() + "\n";
            }
        }
    }
}
