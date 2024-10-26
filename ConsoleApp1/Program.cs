using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyTime time_2 = new MyTime(8, 10, 16);
            MyTime time_1 = new MyTime(23, 59, 59);


            Console.WriteLine(time_1);
            Console.WriteLine(time_2);
            Console.WriteLine();

            int secondsSinceMidnight1 = time_1.ToSecSinceMidnight();
            int secondsSinceMidnight2 = time_2.ToSecSinceMidnight();


            Console.WriteLine($"Час у секундах time_1:{secondsSinceMidnight1}");
            Console.WriteLine($"Час у секундах time_2:{secondsSinceMidnight2}");
            Console.WriteLine();
            Console.WriteLine($"Перетворена кількість секунд у час у форматі MyTime: {time_1.FromSecSinceMidnight(secondsSinceMidnight1)} ");
            Console.WriteLine($"Перетворена кількість секунд у час у форматі MyTime: {time_2.FromSecSinceMidnight(secondsSinceMidnight1)} ");
            Console.WriteLine();
            Console.WriteLine("Робота методу AddOneSecond:");

            MyTime oneSecondAdded1 = time_1.AddOneSecond();
            MyTime oneSecondAdded2 = time_2.AddOneSecond();
            Console.WriteLine($"Додано 1 секунду до time_1:{oneSecondAdded1}");
            Console.WriteLine($"Додано 1 секунду до time_2:{oneSecondAdded2}");


            Console.WriteLine();


            Console.WriteLine("Робота методу AddSeconds:");
            MyTime SecondAdded1 = time_1.AddSeconds(455);
            MyTime SecondAdded2 = time_2.AddSeconds(-50);

            Console.WriteLine($"Додано 455 секунд до time1:{SecondAdded1}");
            Console.WriteLine($"Додано -50 секунд до time2:{SecondAdded2}");

            Console.WriteLine();

            Console.WriteLine("Робота методу AddOneMinute:");
            MyTime minuteAdded1 = time_1.AddOneMinute();
            MyTime minuteAdded2 = time_2.AddOneMinute();
            Console.WriteLine($"Додано 1 хвилину до time_1:{minuteAdded1}");
            Console.WriteLine($"Додано 1 хвилину до time_2:{minuteAdded2}");

            Console.WriteLine();

            Console.WriteLine("Робота методу AddOneHour:");
            MyTime hourAdded2 = time_2.AddOneHour();
            Console.WriteLine($"Додано 1 годину до time_2:{hourAdded2}");

            Console.WriteLine();

            Console.WriteLine("Робота методу Difference:");
            /*MyTime mt1 = time_1;
            MyTime mt2 = time_2;*/

            MyTime mt1 = new MyTime(12, 30, 30);
            MyTime mt2 = new MyTime(10, 15, 15);
            Console.WriteLine(mt1);
            Console.WriteLine(mt2);
            Console.WriteLine($"Difference between mt1 and mt2: {mt1.FromSecSinceMidnight(mt1.Difference(mt2))}");
            Console.WriteLine($"Difference between mt1 and mt2: {(mt1.Difference(mt2))}");

            Console.WriteLine();

            Console.WriteLine("Робота методу IsInRange:");
            MyTime start = new MyTime(22, 0, 0);
            MyTime finish = new MyTime(6, 0, 0);
            MyTime time_3 = new MyTime(23, 30, 40);
            MyTime time_4 = new MyTime(12, 34, 56);

            Console.WriteLine("start: " + start);
            Console.WriteLine("finish: " + finish);
            Console.WriteLine("time_3: " + time_3);
            Console.WriteLine("time_4: " + time_4);
            Console.WriteLine();

            Console.WriteLine($"Is time_3 in range? {time_3.IsInRange(start, finish)}");
            Console.WriteLine($"Is time_4 in range? {time_4.IsInRange(start, finish)}");
            Console.WriteLine();

            do
            {
                Console.WriteLine("Введіть час у форматі годин хвилин секунд або 'stop' для завершення програми:");
                string input = Console.ReadLine();
                if (input.ToLower() == "stop")
                {
                    break;
                }
                string[] timeArr = input.Split(' ');
                if (timeArr.Length != 3)
                {
                    Console.WriteLine("Некоректний формат часу. Спробуйте ще раз.");
                    continue;
                }
                try
                {
                    int h = int.Parse(timeArr[0]);
                    int m = int.Parse(timeArr[1]);
                    int s = int.Parse(timeArr[2]);
                    MyTime time = new MyTime(h, m, s);
                    Console.WriteLine(time + " " + time.WhatLesson());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некоректне введення чисел. Спробуйте ще раз.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);



        }
    }
}
