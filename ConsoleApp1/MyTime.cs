namespace ConsoleApp1
{
    public class MyTime
    {
        private int hour;
        private int minute;
        private int second;

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value <= 23 && value >= 0)
                {
                    hour = value;
                }
                else 
                {
                    throw new System.ArgumentException("Некоректно введені дані");
                }
            }

        }
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    minute = value;
                }
                else
                {
                    throw new System.ArgumentException("Некоректно введені дані");
                }
            }

        }
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    second = value;
                }
                else 
                {
                    throw new System.ArgumentException("Некоректно введені дані");

                }
            }

        }
        public MyTime(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;

        }
        public override string ToString()
        {
            return $"Time: {Hour}:{Minute:D2}:{Second:D2}";
        }
        public int ToSecSinceMidnight(MyTime t)
        {
            return t.Hour * 3600 + t.Minute * 60 + t.Second;
        }
        public int ToSecSinceMidnight()
        {
            return Hour * 3600 + Minute * 60 + Second;
        }
        public MyTime FromSecSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t %= secPerDay;
            // приводимо t до проміжку, можливого в межах однієї доби,
            // враховуючи, що початкове значення t може бути й від’ємним
            if (t < 0)
                t += secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }

        public MyTime AddSeconds(int s)
        {
            int r = ToSecSinceMidnight();
            int totalSeconds = r + s;
            return FromSecSinceMidnight(totalSeconds);
        }
        public MyTime AddOneSecond()
        {
            int totalSeconds = ToSecSinceMidnight() + 1;
            return FromSecSinceMidnight(totalSeconds);
        }
        public MyTime AddOneMinute()
        {
            int totalSeconds = ToSecSinceMidnight() + 60;
            return FromSecSinceMidnight(totalSeconds);
        }
        public MyTime AddOneHour()
        {
            int totalSeconds = ToSecSinceMidnight() + 3600;
            return FromSecSinceMidnight(totalSeconds);
        }
        public int Difference( MyTime mt2)
        {
            int sec1 = ToSecSinceMidnight();
            int sec2 = ToSecSinceMidnight(mt2);

            return sec1 - sec2;
        }
        public bool IsInRange(MyTime start, MyTime finish)
        {
            int secStart = ToSecSinceMidnight(start);
            int secFinish = ToSecSinceMidnight(finish);
            int secT = ToSecSinceMidnight();

            if (secStart < secFinish)
                return secT >= secStart && secT <= secFinish;
            else
                return secT >= secStart || secT <= secFinish;
        }

        // метод перевіряє чи належить введений час проміжку 
        // із урахування якщо : 8:00:00 то пара розпочалась 
        //але якщо 9:20:00 то це буде вважатися перервою між 1-ю та 2-ю парами 
        static bool IsInRangeForLesson(int start, int finish, int t)
        {
            if (start < finish)
            {
                return t >= start && t < finish;
            }
            else
                return t >= start || t < finish;
        }
        public string WhatLesson()
        {
            //Розклад дзвінків
            // 1 пара 8:00/9:20
            // 2 пара 9:40/11:00
            // 3 пара 11:20/12:40
            // 4 пара 13:00/14:20
            // 5 пара 14:40/16:00
            // 6 пара 16:20/17:40


            MyTime durationTime = new MyTime(1, 20, 0);//тривалість пари
            MyTime startLesson = new MyTime(8, 0, 0);// початок першої пари
            MyTime lessonsAlreadyOver = new MyTime(0, 0, 0);//до цоьго часу пари ще вважаються що скінчились



            int myTime = ToSecSinceMidnight();// час який ми ввели переводим в секунди
            int lessonDuration = ToSecSinceMidnight(durationTime);
            int count = 1;
            int twentyMinAInSecond = 60 * 20;// 20 хвилин перерви
            int lessonStart = ToSecSinceMidnight(startLesson);


            for (int i = 1; i < 7; i++)
            {
                int lessonEnd = lessonStart + lessonDuration;//кінець пари
                if (IsInRangeForLesson(lessonStart, lessonEnd, myTime))//дивимось чи входить введений час у проміжок між початком пари і її кінцем
                {
                    return $"{count}-а пара";
                }
                else if (IsInRangeForLesson(lessonEnd, lessonEnd + twentyMinAInSecond, myTime) && count != 6)//дивимось чи введений час у проміжку між парами(перерва)
                {
                    return $"перерва мiж {count}-ю i {count + 1}-ю";
                }
                count++;
                lessonStart += lessonDuration + twentyMinAInSecond;//початок пари
            }

            if (IsInRangeForLesson(ToSecSinceMidnight(lessonsAlreadyOver), ToSecSinceMidnight(startLesson), myTime)) //дивимось чи належить проміжку між 00:00:00 до 8:00:00
            {
                return "пари ще не почались";
            }
            else// if (IsInRangeForLesson(lessonStart, ToSecSinceMidnight(lessonsAlreadyOver), myTime))
            {
                return "пари вже закiнчились";
            }
        }
    }
}
