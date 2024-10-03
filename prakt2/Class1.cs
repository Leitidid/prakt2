using System;
using System.IO;

namespace libmas
{
    public static class ArrayHelper
    {
        public static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    array[i] = number;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    i--; // Повторяем ввод для текущего элемента
                }
            }
        }

        public static void ClearArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public static void SaveArrayToFile(int[] array, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in array)
                {
                    writer.WriteLine(number);
                }
            }
        }

        public static int[] LoadArrayFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new int[0];
            }

            int[] array = new int[File.ReadAllLines(filePath).Length];
            int i = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    array[i++] = int.Parse(reader.ReadLine());
                }
            }

            return array;
        }
    }
}