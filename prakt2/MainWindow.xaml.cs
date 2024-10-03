using System;
using System.Windows;
using libmas;
using libmas_task;
using Microsoft.Win32;

namespace ProductCalculatorApp
{
    public partial class MainWindow : Window
    {
        private int[] numbers;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tb1.Text, out int n))
            {
                numbers = new int[n];
                tb2.Text = ""; // Очищаем для ввода чисел
                tb3.Text = ""; // Очищаем для результата

                //  заполнению массива
                bt1.IsEnabled = false;
                bt2.IsEnabled = true;
                tb2.IsEnabled = true;
                tb2.Focus();
            }
            else
            {
                MessageBox.Show("ошибка");
            }
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            
            string[] inputNumbers = tb2.Text.Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(inputNumbers[i], out int number))
                {
                    numbers[i] = number;
                }
                else
                {
                    MessageBox.Show("ошибка");
                    return; // Выходим из обработки события
                }
            }

            // Переходим к следующему шагу: вычислению произведения
            bt2.IsEnabled = false;
            bt3.IsEnabled = true;
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            // Вычисляем произведение
            int proizvedenie = ProizvedCalc.CalculateProizved3(numbers);
            tb3.Text = $"{proizvedenie}";

            // Переходим к следующему шагу: выводу результатов
            bt3.IsEnabled = false;
            bt4.IsEnabled = true;
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            // Выводим числа
            string numbersString = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersString += $"{numbers[i]} ";
            }
            tb4.Text = numbersString;

            // Дополнительные кнопки для сохранения и загрузки
            bt5.IsEnabled = true;
            bt6.IsEnabled = true;
        }

        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            if (numbers != null)
            {
                // Сохраняем данные в файл
                if (saveFileDialog.ShowDialog() == true)
                {
                    masHelp.Savemas(numbers, saveFileDialog.FileName);
                    MessageBox.Show("сохранен");
                }
            }
        }

        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                // Загружаем данные из файла
                numbers = masHelp.Loadmas(openFileDialog.FileName);

                // Обновляем текстовые поля
                tb1.Text = numbers.Length.ToString();
                bt1.IsEnabled = false;
                bt2.IsEnabled = false;
                bt3.IsEnabled = true;
                bt5.IsEnabled = true;
                bt6.IsEnabled = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string developer = "Дудина Екатерина";
            int job = 2;
            string task = " Ввести n целых чисел. Найти произведение чисел < 3. Результат вывести на экран";

            MessageBox.Show($"Разработчик: {developer}\nНомер работы: {job}\nЗадание: {task}",
                "О программе");
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}