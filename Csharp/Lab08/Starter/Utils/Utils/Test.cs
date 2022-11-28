using System;

namespace Utils;

class Test
{
    static void Main(string[] args)
    {
        string? message;

        Console.WriteLine("Enter string to reverse: ");
        message = Console.ReadLine();
        Utils.Reverse(ref message);             //Вызов метода зазворота строки 

        Console.WriteLine(message);
    }

    
}
