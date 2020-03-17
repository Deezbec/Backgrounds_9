using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Вариант 3
namespace Фоновая_3._1
{
    class Program
    {
        static void Unpacking(string a, ref string w)
        {
            int j = 0;
            if (w.Length >= a.Length)
            {
                for (int i = 0; i < a.Length; i++, j++)
                {
                    if (a[i] == '?')
                    {
                        a = a.Remove(i, 1);
                        a = a.Insert(i, w[j].ToString());
                    }
                    if (a[i] == '*')
                    {
                        if (i + 1 != a.Length)
                        {
                            if (a[i + 1] != '?')
                            {
                                a = a.Replace("*", w.Substring(j, w.IndexOf(a[i + 1]) - j));
                                j += w.IndexOf(a[i + 1]) - j - 1;
                            }
                            else
                            {
                                int h = i;
                                while (a[h + 1] == '?') h++;
                                a = a.Replace("*", w.Substring(j, w.IndexOf(a[h + 1]) - j - 1));
                            }
                        }
                        else a = a.Replace("*", w.Substring(j));
                    }
                }
            }
            if (a.Equals(w)) w = "YES";
            else w = "NO";
        }
        static void prov(ref string num)
        {
            if (num[0] == '8') num = num.Remove(0, 1);
            if (num.Contains("+7")) num = num.Remove(0, 2);
            if (num.Contains('(')) num = num.Remove(num.IndexOf('('), 1);
            if (num.Contains(')')) num = num.Remove(num.IndexOf(')'), 1);
            while(num.Contains('-'))
                num = num.Remove(num.IndexOf('-'), 1);
            if (num.Length < 10) num = num.Insert(0, "495");
        }
        static void Main(string[] args)
        {
            Console.Write("Номер задания : ");
            int j = Convert.ToInt32(Console.ReadLine());
            switch (j)
            {
                case 1:
                    {
                        string num1 = Console.ReadLine(),
                        num2 = Console.ReadLine(),
                        num3 = Console.ReadLine(),
                        num4 = Console.ReadLine();
                        Console.WriteLine();
                        prov(ref num1);
                        prov(ref num2);
                        prov(ref num3);
                        prov(ref num4);
                        if (num2.Equals(num1)) Console.WriteLine("YES");
                        else Console.WriteLine("NO");
                        if (num3.Equals(num1)) Console.WriteLine("YES");
                        else Console.WriteLine("NO");
                        if (num4.Equals(num1)) Console.WriteLine("YES");
                        else Console.WriteLine("NO");
                        break;
                    }
                case 2:
                    {
                        string main = Console.ReadLine(),
                        w1 = Console.ReadLine(),
                        w2 = Console.ReadLine(),
                        w3 = Console.ReadLine(),
                        w4 = Console.ReadLine(),
                        w5 = Console.ReadLine();
                        Unpacking(main, ref w1);
                        Unpacking(main, ref w2);
                        Unpacking(main, ref w3);
                        Unpacking(main, ref w4);
                        Unpacking(main, ref w5);
                        Console.WriteLine($@"
{w1}
{w2}
{w3}
{w4}
{w5}");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
