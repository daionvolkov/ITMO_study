using System;

namespace Utils;


public class Test
{
    static void Main()
    {
        int x, y, greater, f;
        bool okay;
        
        Console.WriteLine("Enter first integer number: ");
        x = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second integer number: ");
        y = int.Parse(Console.ReadLine());

        greater = Utils.Greater(x, y);                      // Вызов метода проверки на большее меньшее число
        Console.WriteLine("The greater value is " + greater);

        Console.WriteLine("Numbers before swap: x = " + x + ", y = " + y);
        Utils.Swap(ref x, ref y);                           // Вызов метода заменой значений переменных   
        Console.WriteLine("Numbers after swap: x = " + x + ", y = " + y);

        Console.WriteLine("Enter number for factorial: ");
        x = int.Parse(Console.ReadLine());

        okay = Utils.Factorial(x, out f);                   // Вывод метода расчета факториала 
        if (okay)
            Console.WriteLine("Factorial "+ x + " is " + f);
        else
            Console.WriteLine("Cant complite factorial");


    }
}

class Utils
{
    public static int Greater(int a, int b)  // Метод проверки на большее число
    {
        if (a > b)
            return a;
        else if (a == b)
            return 0;
        else
            return b;
    }
    public static void Swap(ref int a, ref int b)   // Метод замены значений переменных 
    {
        int temp = a;
        a = b;
        b = temp;
    }
    public static bool Factorial(int n, out int result)
    {
        int k, f;
        bool okay = true;

        if (n < 0)
            okay = false;
        try
        {
            checked
            {
                f = 1;
                for (k = 2; k <= n; k ++ )
                    f = f * k;
            }
        }
        catch(Exception ex)
        {
            f = 0;
            okay = false;
            Console.WriteLine(ex.Message);
        }
        result = f;
        return okay;
    }
}