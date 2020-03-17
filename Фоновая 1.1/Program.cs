using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фоновая_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine()),
                b = Convert.ToInt32(Console.ReadLine()),
                c = Convert.ToInt32(Console.ReadLine());
            double d;
            d = Math.Pow((c + b), (1.0 / 3.0)) + Math.Sin(a / (double)4) +
                Math.Sqrt((a + b + 4) / 2) + Math.Pow(c, 2);
            Console.WriteLine("{0:F2}", d);
            Console.ReadKey();
        }
    }
}
