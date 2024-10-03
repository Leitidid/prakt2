using System;
using System.IO;

namespace libmas
{
    public static class masHelp
    {
        public static void zapolneniemas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    mas[i] = num;
                }
                else
                {
                    Console.WriteLine("ошибка");
                    i--; // Повторяем ввод
                }
            }
        }

        public static void ochistkamas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        }

        public static void Savemas(int[] mas, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (int num in mas)
                {
                    writer.WriteLine(num);
                }
            }
        }

        public static int[] Loadmas(string file)
        {
            if (!File.Exists(file))
            {
                return new int[0];
            }

            int[] mas = new int[File.ReadAllLines(file).Length];
            int i = 0;
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    mas[i++] = int.Parse(reader.ReadLine());
                }
            }

            return mas;
        }
    }
}