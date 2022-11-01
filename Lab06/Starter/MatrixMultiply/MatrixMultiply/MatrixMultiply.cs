using System;
using System.Security.Cryptography;

class MatrixMultiply
{
    public static void Main()
    {
        int[,] arr1 = new int[2, 2];
/*      arr1[0, 0] = 1;
        arr1[0, 1] = 2;
        arr1[1, 0] = 3;
        arr1[1, 1] = 4;*/
        
        int[,] arr2 = new int[2, 2];
/*      arr2[0, 0] = 5;
        arr2[0, 1] = 6;
        arr2[1, 0] = 7;
        arr2[1, 1] = 8;*/
        
        int[,] result; = new int[2, 2];

        Input(arr1);                                                                    //Вызов метода введения значений первого массива
        Input(arr2);                                                                    //Вызов метода введения значений второго массива

        result = Multiply(arr1, arr2);                                                  //Вызов метода перемножения массивов

        /*      result[0, 0] = arr1[0, 0] * arr2[0, 0] + arr1[0, 1] * arr2[1, 0];       // Расчет результата без метода
                result[0, 1] = arr1[0, 0] * arr2[0, 1] + arr1[0, 1] * arr2[1, 1];
                result[1, 0] = arr1[1, 0] * arr2[0, 0] + arr1[1, 1] * arr2[1, 0];
                result[1, 1] = arr1[1, 0] * arr2[0, 1] + arr1[1, 1] * arr2[1, 1];*/

        /*   Console.Write(result[0, 0]);                                                // Вывод результата без цикла
             Console.WriteLine(" " + result[0, 1]);
             Console.Write(result[1, 0]);
             Console.WriteLine(" " + result[1, 1]);*/


        Output(result);                                                                 //вызов  метода вывода результата
    }
    static void Output(int[,] result)
    {
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write("{0} ", result[i, j]);
            }
            Console.WriteLine();
        }
    }
    static int[,] Multiply(int[,] arr1, int[,] arr2)
    {
        int[,] result = new int[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result[i, j] += arr1[i, 0] * arr2[0, j] + arr1[i, 1] * arr2[1, j];
            }
        }
        return result;
    }
    static void Input(int[,] dst)
    {
        for (int r = 0; r < 2; r++)
        {
            for (int c = 0; c < 2; c++)
            {
                Console.Write("Enter value for [{0},{1}] : ", r, c);
                string s = Console.ReadLine();
                dst[r, c] = int.Parse(s);
            }
        }
        Console.WriteLine();
    }
}