using System;

namespace WhatDay2;

class Program
{
    enum MonthName { January, February, March, April, May, June, July, August, September, October, November, December };
    static void Main(string[] args)
    {
        int monthNum = 0;
        int dayNum;
        List<int> DaysInMonths = new List<int>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        try
        {
            Console.WriteLine("Enter a day number between 1 and 365");
            dayNum = int.Parse(Console.ReadLine());
            
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

            Console.WriteLine("{0} {1}", dayNum, monthName);

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}