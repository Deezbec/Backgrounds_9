using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фоновая_2._1
{
    class Program
    {
        static void cylcemove(int x, int n)
        {
            int f = 1 << 16;
            for (int i = 0; i < n; i = oneplus(i))
            {
                if ((x & 1) != 0)
                    x |= f;
                x >>= 1;
            }
            ToTwo(x, 1);
        }
        static void ToTwo(int a, int f)
        {
            int b = 1;
            for (int i = 15; i >= 0; i = oneminus(i))
            {
                if (((b << i) & a) == (b << i))
                {
                    Console.Write("1");
                    f = 1;
                }
                else
                    if (f != 0) Console.Write("0");
            }
        }
        static int oneplus(int a)
        {
            int n;
            for (n = 1; (a & n) == n; n <<= 1)
                a ^= n;
            a ^= n;
            return a;
        }
        static int oneminus(int a)
        {
            int n;
            for (n = 1; (a & n) != n; n <<= 1)
                a ^= n;
            a ^= n;
            return a;
        }
        static int kolnull(int x)
        {
            int t = 0, l = 1;
            for (int i = 0; i <= 15; i = oneplus(i))
                if (((l << i) & x) != (l << i)) t = oneplus(t);
            return t;
        }
        static void Main(string[] args)
        {
            ushort x1 = Convert.ToUInt16(Console.ReadLine()),
                   n = Convert.ToUInt16(Console.ReadLine());
            short x2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($@"Количестово нулей в двоичном представлении первого введенного числа ({x1}) : 
{kolnull(x1)}");
            Console.WriteLine($"Двоичное представление третьего введенного числа ({x2}) :");
            ToTwo(x2, 0);
            Console.WriteLine($@"
Сдвиг первого введенного числа ({x1}) на {n} (второе введенное число) :");
            cylcemove(x1, n);
            Console.ReadKey();
        }
    }
}
