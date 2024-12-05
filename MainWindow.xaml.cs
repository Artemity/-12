using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace практика_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer; // Таймер для обновления отображения времени и даты
        public MainWindow()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Отображает информационное сообщение о приложении и его функциональности
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программу подготовил студент группы ИСП-31 Лотаков Артемий\nПрактическая 12 Вариант 13\nРеализовать расчет задачи:\n• Даны координаты трех вершин треугольника: (x1, y1), (x2, y2), (x3, y3). Найти его периметр и площадь, используя окнолу для расстояния между двумя точками на плоскости (см. задание 12). Для нахождения площади треугольника со сторонами a, b, c использовать окнолу Герона: S = p( p − a)( p − b)( p − c) где p = (a + b + c)/2 —полупериметр.\n• Дано трехзначное число. Найти сумму и произведение его цифр.", "О программе");
        }

        /// <summary>
        /// Закрывает приложение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Очищает все текстовые поля и результаты для задачи 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            x1Text.Clear();
            y1Text.Clear();
            x2Text.Clear();
            y2Text.Clear();
            x3Text.Clear();
            y3Text.Clear();
            perimeterOut.Clear();
            squareOut.Clear();
        }

        /// <summary>
        /// Очищает все текстовые поля и результаты для задачи 2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear2_Click(object sender, RoutedEventArgs e)
        {
            numberText.Clear();
            sumOut.Clear();
            compositionOut.Clear();
        }

        /// <summary>
        /// Обработчик нажатия кнопки для расчета периметра и площади треугольника.
        /// </summary>
        private void FirstTask()
        {
            if (double.TryParse(x1Text.Text, out double x1) && double.TryParse(y1Text.Text, out double y1) && double.TryParse(x2Text.Text, out double x2) && double.TryParse(y2Text.Text, out double y2) && double.TryParse(x3Text.Text, out double x3) && double.TryParse(y3Text.Text, out double y3))
            {
                // Вычисление стороны треугольника
                double sideA = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));//Это вычисление длины стороны (sideA)
                double sideB = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                double sideC = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

                // Вычисление периметра и площади
                double perimeter = Math.Round(sideA + sideB + sideC, 2);
                double p = (sideA + sideB + sideC) / 2;//нахождения полупериметра треугольника
                double square = Math.Round(Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC)), 2);//Это вычисление площади треугольника с использованием формулы Герона и округление результата до двух десятичных знаков после запятой.
                
                // Отображение результатов
                perimeterOut.Text = perimeter.ToString();
                squareOut.Text = square.ToString();
            }

            else
            {
                MessageBox.Show("Введены неверные координаты");
            }
        }
        
        /// <summary>
        /// Событие кнопки рассчета для первого задания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask1_Click(object sender, RoutedEventArgs e)
        {
            FirstTask();
        }

        /// <summary>
        /// Обработчик нажатия кнопки для расчета суммы и произведения цифр трехзначного числа.
        /// </summary>
        private void SecondTask()
        {
            if (int.TryParse(numberText.Text, out int number) && number < 1000 && number > 99)
            {
                int sum = (number / 100) + (number / 10 % 10) + (number % 10);
                int composition = number / 100 * (number / 10 % 10) * (number % 10);
                sumOut.Text = sum.ToString();
                compositionOut.Text = composition.ToString();
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
            }
        }

        /// <summary>
        /// Событие кнопки рассчета для второго задания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask2_Click(object sender, RoutedEventArgs e)
        {
            SecondTask();
        }

        /// <summary>
        /// Очищает результаты для задачи 1 при изменении вводимых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Task1_TextChanged(object sender, TextChangedEventArgs e)
        {
            perimeterOut.Clear();
            squareOut.Clear();
        }

        /// <summary>
        /// Очищает результаты для задачи 2 при изменении вводимых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Task2_TextChanged(object sender, TextChangedEventArgs e)
        {
            sumOut.Clear();
            compositionOut.Clear();
        }

        /// <summary>
        /// Обработчик события загрузки окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }

        /// <summary>
        /// Обработчик события тиков таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;//Создание объекта
            time.Text = d.ToString("HH:mm:ss");
            date.Text = d.ToString("dd.MM.yyyy");
        }
    }
}