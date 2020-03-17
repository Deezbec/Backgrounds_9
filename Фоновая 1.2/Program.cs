using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фоновая_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToSingle(Console.ReadLine());
            double y = Convert.ToSingle(Console.ReadLine());
            double U;
            if (x <= 4)
            {
                if ((x * x + y * y) <= (x + y) * (x + y))
                    U = Math.Sqrt(Math.Abs(x + y)) - 1;
                else
                {
                    if (x >= 0)
                    {
                        if (y <= 4)
                        {
                            if (y >= -4)
                                U = (Math.Sqrt(Math.Abs(x + y)) - 1);
                            else U = x / Math.Pow(y, 2);
                        }
                        else U = x / Math.Pow(y, 2);
                    }
                    else U = x / Math.Pow(y, 2);
                }
            }
            else
                U = x / Math.Pow(y, 2);
            Console.WriteLine("{0:f2}", U);
            Console.ReadKey();
        }
    }
}
