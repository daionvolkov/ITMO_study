using System;

namespace Greeting;

class Program
{
    static void Main(string[] args)
    {
        string? name;

        Console.WriteLine("Please enter your name");
        name = Console.ReadLine();
        Console.WriteLine("Hello {0}", name);
    }
}
