using System;


namespace FileDetails;

class FileDetails
{
    
    static void Main()
    {
        string [] args = { "FileDetails" };

      /*  Console.WriteLine(args.Length);
        foreach (string arg in args)
        {
            Console.WriteLine(arg);
        }*/
        string fileName = args[0];

        FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(file);
         
        int size = (int)file.Length;                
        char[] contents = new char[size];

        for (int i = 0; i < size; i++)
            contents[i] = (char)reader.Read();
         
        foreach (char el in contents)
            Console.Write(el);
            Console.WriteLine("\n");

        Summarize(contents);
    }

    static void Summarize(char[] contents)
    {
        int vowels = 0, consonants = 0, lines = 0;

        foreach (char el in contents)
        {
            if (Char.IsLetter(el))
            {
                if ("AEIOUaeiou".IndexOf(el) != -1)
                    vowels++;
                else
                    consonants++;
            }
            else if (el == '\n')
                lines++;
        }
        Console.WriteLine("Total of characters: {0}", contents.Length);
        Console.WriteLine("Total of vowels : {0}", vowels);
        Console.WriteLine("Total of consonants: {0}", consonants);
        Console.WriteLine("Total of lines : {0}", lines);
    }
}