using Microsoft.VisualBasic;
using System;
using System.Runtime.Serialization.Formatters;
using System.Transactions;

namespace HomeWork_1
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            // ----------------- Задача 1 - Количество квадратов в прямоугольнике ----------------- 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задача 1 - Количество квадратов в прямоугольнике и площадь остатка прямоугольника");
            Console.ForegroundColor = ConsoleColor.White;                        
            Console.Write("\nВведите ширину прямоугольника в целых кв.см. -> ");
            int width = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения ширины прямоугольника
            Console.Write("Введите высоту прямоугольника в целых кв.см. -> ");
            int height = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения высоты прямоугольника
            Console.Write("Введите размер стороны квадрата в целых кв.см. -> ");
            int square = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения стороны квадрата
            Console.WriteLine();
            if (square > width || square > height) // Квадрат не вписывается в прямоугольник
            {                
                Console.Write("Квадрат со стороной ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(square);                                
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write(" см. невозможно разместить в прямоугольнике размером ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(width + " x " + height);                                                                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" см.");
            }
            else // Квадрат вписывается в прямоугольник
            {
                // Переменная для хранения кол-ва квадратов в прямоугольнике (c приведением типа double в тип int)
                int quantity = (width / square) * (height / square);
                Console.Write("В прямоугольник размером ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(width + " x " + height);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" см. можно выписать ");                                               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(quantity);                
                Console.ForegroundColor= ConsoleColor.White;                
                Console.Write(" квадрата(-ов) со стороной ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(square);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" см.");
                Console.Write("Площадь остатка (незанятой части) прямоугольника = ");
                Console.ForegroundColor = ConsoleColor.Green;
                // Формула расчёта остатка площади прямоугольника после вписывания в него квадратов
                Console.Write(width * height - quantity * square * square);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" кв.см");
            }
            
            // ------------------------------- Задача 2 - Вклад -------------------------------------- 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 2 - Вклад");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nИзначальный размер вклада = 10000 гривен. Процент на вклад зачисляется ежемесячно!\n");
            Console.Write("Введите ежемесячный процент (от 0 до 25 невключительно) -> ");
            double per_cent = Convert.ToDouble(Console.ReadLine()); // Переменная для хранения процента
            while (per_cent <= 0 || per_cent >= 25) // Цикл проверки введённого пользователем значения
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода! Процент от 0 до 25 невключительно!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите ежемесячный процент ещё один раз -> ");
                per_cent = Convert.ToDouble(Console.ReadLine());
            }
            float deposit = 10000; // Переменная для хранения размера вклада (float для отсекания больших разрядов знаков после запятой)
            int couter = 0; // Счётчик кол-ва месяцев
            while (deposit < 11000) // Цикл расчёта 
            {
                deposit *= (float)(1 + per_cent / 100); // С явным приведением типа
                ++couter;
            }
            Console.Write("\nВклад превысит 11000 гривен через ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(couter);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" месяца(-ев), окончательный вклад = ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(deposit);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" гривен.");
            
            // ----------------------------- Задача 3 - Вывод чисел ----------------------------------- 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 3 - Вывод чисел в диапазоне пользователя");
            Console.ForegroundColor = ConsoleColor.White;                      
            Console.Write("\nВведите начало диапазона (целое положительное число, не равное нулю) -> ");
            int start = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения начала диапазона
            Console.Write("Введите конец диапазона (целое положительное число, не равное нулю) -> ");
            int end = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения конца диапазона
            while (end <= start)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Конец диапазона не может быть равным или меньшим началу! Введите данные ещё раз!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите начало диапазона (целое положительное число, не равное нулю) -> ");
                start = Exam(Convert.ToInt32(Console.ReadLine()));
                Console.Write("Введите конец диапазона (целое положительное число, не равное нулю) -> ");
                end = Exam(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine(); // Цикл вывода чисел из диапазоан в консоль по условию задачи
            for (int i = start; i <= end; ++i)
            {
                for (int j = 0; j < i; ++j)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
                        
            // ----------------------------- Задача 4 - Отображение числа -----------------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 4 - Отображение числа");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nВведите целое положительное число, не равное нулю -> ");
            int number = Exam(Convert.ToInt32(Console.ReadLine())); // Переменная для хранения числа
            string text = Convert.ToString(number); // Число в формате строки            
            char[] tmp = new char[text.Length]; // Массив символов для временного хранения отображённых символов
            for (int i = text.Length - 1; i >= 0; i--) // Цикл записи символов строки в обратном порядке в массив символов
                tmp[text.Length - 1 - i] = text[i];
            text = ""; // Чистим строку 
            foreach (char c in tmp) // Цикл перезаписи строки отображёнными символами
                text += c;                
            int final = Convert.ToInt32(text); // Переменная для хранения итогового (отображённого) числа                       
            Console.Write("Отображённое число = ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(final);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        // Функция проверки и корректировки введённого пользователем значения (для задачь 1, 3 и 4)
        static int Exam(int num)
        {
            while (num <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода! Значение не может быть отрицательным или равным нулю!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите число ещё один раз -> ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return num;
        }
    }
}