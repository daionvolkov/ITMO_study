using System;

namespace Utils;

class Utils
{
    public static int Greater(int a, int b)  // Метод проверки на большее число
    {
        if(a> b)
            return a;
        else
            return b;
    }
    public static void Swap(ref int a, ref int b)   // Метод замены значений переменных 
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
public class Test
{
    static void Main()
    {
        int x, y, greater;
        
        Console.WriteLine("Enter first integer number: ");
        x = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second integer number: ");
        y = int.Parse(Console.ReadLine());

        greater = Utils.Greater(x, y);                      // Вызов метода проверки на большее меньшее число
        Console.WriteLine("The greater value is " + greater);

        Console.WriteLine("Numbers before swap: x = " + x + ", y = " + y);
        Utils.Swap(ref x, ref y);                           // Вызов метода заменой значений переменных   
        Console.WriteLine("Numbers after swap: x = " + x + ", y = " + y);

    }
}