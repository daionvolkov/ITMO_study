using System;
namespace Utils;

class Utils
{
    public static int Greater(int a, int b)             //Метод проверки на большее число
    {
        if (a > b)
            return a;
        else
            return b;
    }
    public static void Swap(ref int a, ref int b)       //Метод замены переменных
    {
        int temp;
        temp = a;
        a = b;
        b = temp;
    }
    public static bool Factorial(int n, out int answer) //Метод расчета факториала
    {
        int f;
        bool ok = true;

        if (n < 0)
            ok = false;
        try
        {
            checked
            {
                f = 1;
                for (int i = 2; i <= n; ++i)
                {
                    f = f * i;
                }
            }
        }
        catch (Exception)
        {
            f = 0;
            ok = false;
        }
        answer = f;
        return ok;
    }
    public static bool RecursiveFactorial(int n, out int f)
    {
        bool ok = true;
        if (n < 0)
        {
            f = 0;
            ok = false;
        }
        if (n <= 1)
            f = 1;
        else
        {
            try
            {
                int pf;
                checked
                {
                    ok = RecursiveFactorial(n - 1, out pf);
                    f = n * pf;
                }
            }
            catch (Exception)
            {
                f = 0;
                ok = false;
            }
        }
        return ok;
    }
    public static void Reverse(ref string s)            //Метод развората строки
    {
        string sRev = "";

        for (int i = s.Length-1; i >= 0 ; i--)
            sRev = sRev + s[i];
        
        s = sRev;
    }
}

