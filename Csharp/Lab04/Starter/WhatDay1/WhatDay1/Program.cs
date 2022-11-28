using System;
using System.Runtime.Intrinsics.X86;

namespace WhatDay1;

class WhatDay
{
    enum MonthName { January, February, March, April, May, June, July, August, September, October, November, December };
    static void Main(string[] args)
    {
        int monthNum = 0;
        List<int> DaysInMonths = new List<int>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        Console.WriteLine("Enter a day number between 1 and 365");
        int dayNum = int.Parse(Console.ReadLine());


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

        /*
                for (int i = 0; i < 1; i++)
                {
                    if (dayNum <= 31)           // January
                    {                               
                        monthNum = 1;
                        break;
                    }
                    else dayNum -= 31;

                    if (dayNum <= 28)         // February
                    {
                        monthNum = 2;
                        break;
                    }
                    else dayNum -= 28;

                    if (dayNum <= 31)        // March
                    {
                        monthNum = 3;
                        break;
                    }
                    else dayNum -= 31;
                    if (dayNum <= 30)       // April
                    {
                        monthNum = 4;
                        break;
                    }
                    else dayNum -= 30;

                    if (dayNum <= 31)        // May
                    {
                        monthNum = 5;
                        break;
                    }
                    else dayNum -= 31;
                    if (dayNum <= 30)         // June
                    {
                        monthNum = 6;
                        break;
                    }
                    else dayNum -= 30;

                    if (dayNum <= 31)           // July
                    {
                        monthNum = 7;
                        break;
                    }
                    else dayNum -= 31;

                    if (dayNum <= 31)           // August
                    {
                        monthNum = 8;
                        break;
                    }
                    else dayNum -= 31;

                    if (dayNum <= 30)           // September
                    {
                        monthNum = 9;
                        break;
                    }
                    else dayNum -= 30;

                    if (dayNum <= 31)           // October
                    {
                        monthNum = 10;
                        break;
                    }
                    else dayNum -= 31;

                    if (dayNum <= 30)           // November
                    {
                        monthNum = 11;
                        break;
                    }
                    else dayNum -= 30;

                    if (dayNum <= 31)           // December
                    {
                        monthNum = 12;
                        break;
                    }
                    else dayNum -= 31;
                }

                MonthName temp = (MonthName)(monthNum-1);
                string monthName = temp.ToString();

                Console.WriteLine("{0} {1}", dayNum, monthName);
        */

        /* switch (monthNum)
         {
             case 1:
                 monthName = "January"; break;
             case 2:
                 monthName = "February"; break;
             case 3:
                 monthName = "March"; break;
             case 4:
                 monthName = "April"; break;
             case 5:
                 monthName = "May"; break;
             case 6:
                 monthName = "June"; break;
             case 7:
                 monthName = "Jule"; break;
             case 8:
                 monthName = "August"; break;
             case 9:
                 monthName = "September"; break;
             case 10:
                 monthName = "October"; break;
             case 11:
                 monthName = "November"; break;
             case 12:
                 monthName = "December"; break;
             default:
                 monthName = "not done yet"; break;
         }

         Console.WriteLine(dayNum.ToString() + " " + monthName);*/

    }
}
