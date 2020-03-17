using System;

namespace Фоновая_2._3
{
    class Program
    {
        static bool prost(int a)
        {
            int k = 0;
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    k++;
                    break;
                }
            }
            if (k == 0) return true;
            else return false;
        }
        static void changer(ref int n, ref int m)
        {
            n = n - m;
            m = n + m;
            n = m - n;
        }
        static void BackGround(ref int n, ref int m, ref bool p)
        {
            int a = 0, b = 0;
            for (int i = n; i <= m; i++)
            {
                if (prost(i)) a = i;
                if (a - b == 2)
                {
                    n = b;
                    m = a;
                    p = true;
                    break;
                }
                b = a;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("m = ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write($"В диапазоне [{n}; {m}]");
            bool p = false;
            if (n > m) changer(ref n, ref m);
            BackGround(ref n, ref m, ref p);
            if (p) Console.WriteLine($@" существуют числа-близнецы
Новые значения: n = {n}, m = {m}");
            else Console.WriteLine($" нет чисел-близнецов");
            Console.ReadKey();
        }
    }
}
