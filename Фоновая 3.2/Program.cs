using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Вариант 1
namespace Фоновая_3._2 
{
    class Program
    {
        static void NewStrangeMassMaker (ref int[] a)
        {
            int[] NewA = new int[a.Length];
            int j = 0;
            foreach(int x in a)
                if (x < 0)
                    NewA[j++] = x;
            foreach(int x in a)
                if (x > 0)
                    NewA[j++] = x;
            a = NewA;
        }

        static void StrangeChanger(int[] a)
        {
            int min = MinSearcher(a);
            a[0] = min;
            for (int i = 1; i < a.Length - 1; i++)
            {
                a[i] += a[i + 1];
            }
            a[a.Length - 1] = min;
        }
        static int MinSearcher(int[] a)
        {
            int res = Int32.MaxValue;
            foreach (int x in a)
                if (x < res) res = x;
            return res;
            // или по-другому - return a.Min();
        }
        static void Typer(int[] a)
        {
            foreach(int x in a)
                Console.Write($"{x} ");
            Console.WriteLine();
        }
        static void inserter(int[] a)
        {
            string[] s = Console.ReadLine().Split();
            for (int i = 0; i < a.Length; i++)
                a[i] = Convert.ToInt32(s[i]);
        }
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во эллементов массива : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            inserter(a);
            Console.Write("Исходный массив : ");
            Typer(a);
            Console.WriteLine($"Минимальный эллемент массива : {MinSearcher(a)}");
            /*Console.WriteLine("При замене эллементов получилось (Задание 4) : "); 
            StrangeChanger(a);*/
            Console.Write("После странной сортировки массив выглядит так : ");
            NewStrangeMassMaker(ref a);
            Typer(a);
            Console.ReadKey();
        }
    }
}
