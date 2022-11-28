using System;


namespace TestDisplay
{
    internal class Test
    {
        static void Main()
        {
            int num = 65;
            string msg = "A String";
            Coordinate c = new Coordinate(21.0, 68.0);

            Utils.Display(num);
            Utils.Display(msg);
            Utils.Display(c);
        }
    }
}
