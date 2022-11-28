using System;
namespace WhatDay3;

class WhatDay
{
    enum MonthName { January, February, March, April, May, June, July, August, September, October, November, December };
    static void Main(string[] args)
    {
        string? line;
        int yearNum, dayNum, monthNum = 0;
        bool isLeapYear;
        List<int> DaysInMonths = new List<int>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        try
        {
            Console.Write("Enter the year: ");
            line = Console.ReadLine();
            yearNum = int.Parse(line);

            Console.Write("Please enter a day number between 1 and 365: ");
            line = Console.ReadLine();
            dayNum = int.Parse(line);


            if (dayNum < 1 || dayNum > 365) throw new ArgumentOutOfRangeException("Day out of range");
            foreach (int daysInMonth in DaysInMonths)
            {
                if (dayNum <= daysInMonth) break;
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }
            }
            MonthName temp = (MonthName)monthNum;
            string monthName = temp.ToString();
            Console.WriteLine("{0} {1}", dayNum, monthName);  // Вывод числа месяца

            // Проверка на високосный год
            isLeapYear = (yearNum % 4 == 0) && (yearNum % 100 != 0 || yearNum % 400 == 0);
            if (isLeapYear)
                Console.WriteLine(yearNum+ " is a leap year");
            else
                Console.WriteLine(yearNum + " is NOT a leap year");
           

      
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}