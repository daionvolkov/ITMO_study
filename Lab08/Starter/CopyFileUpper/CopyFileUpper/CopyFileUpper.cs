using System;

class CopyFileUpper
{
    static void Main()
    {
        string? sFrom, sTo;
        StreamReader srFrom;
        StreamWriter swTo;

        Console.Write("Copy from:");
        sFrom = Console.ReadLine();

        Console.Write("Copy to:");
        sTo = Console.ReadLine();

        Console.WriteLine("Copy from {0} to {1}", sFrom, sTo);

        try
        {
            srFrom = new StreamReader(sFrom);
            swTo = new StreamWriter(sTo);

            while (srFrom.Peek() != -1)
            {
                string sBuffer = srFrom.ReadLine();
                sBuffer = sBuffer.ToUpper();
                swTo.WriteLine(sBuffer);
            }
            swTo.Close();
            srFrom.Close();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found");
            Console.WriteLine(ex.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception");
            Console.WriteLine(e.Message);
        }
    }
}
