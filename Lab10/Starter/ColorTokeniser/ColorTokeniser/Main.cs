using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTokeniser;

public class Application
{
    public static void Main(string[] args)
    {
        try
        {
            InnerMain(args);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void InnerMain(string[] args)
    {
        SourceFile source = new SourceFile(args[0]);


    }
}
