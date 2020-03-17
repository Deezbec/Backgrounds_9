using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Вариант 3
namespace Фоновая_3._3
{
    class Program
    {
        static int[][] InputArray(int n)
        {
            int[][] mass;
            mass = new int[n][];
            int m;
            string[] s;
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write("ВВедите количество элементов в {0} строке : ", i + 1);
                m = Convert.ToInt32(Console.ReadLine());
                mass[i] = new int[m];
                Console.Write("Введите элементы массива (в 1 строку) : ");
                s = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                    mass[i][j] = Convert.ToInt32(s[j]);
            }
            return mass;
        }
        static void Output(int[][] mass)
        {
            foreach(int[] x in mass)
            {
                foreach (int xx in x) Console.Write($"{xx} ");
                Console.WriteLine();
            }
        }
        static void MFinder(int[][] mass, out int[] mass2)
        {
            int max = 0;
            for (int i = 0; i < mass.Length; i++) if (mass[i].Length > max) max = mass[i].Length;
            mass2 = new int[max];
            Console.Write("Первые элементы столбцов массива, кратные 2ум : ");
            for(int i = 0; i < mass.Length; i++)
            {
                for(int j = 0; j < mass[i].Length; j++)
                {
                    if (mass[i][j] % 2 == 0 && mass2[j] == 0) mass2[j] = mass[i][j];
                }
            }
            foreach (int x in mass2) Console.Write($"{x} ");
            Console.WriteLine();
        }
        static void Zipper(ref int[][] mass)
        {
            int k = 0;
            int summzero = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                foreach (int x in mass[i]) if (x == 0) summzero++;
                if (summzero > mass[i].Length / 2) k++;
                summzero = 0;
            }
            int[][] newmass = new int[mass.Length - k][];
            for (int i = 0, j = 0; i < mass.Length; i++)
            {
                foreach (int x in mass[i]) if (x == 0) summzero++;
                if (summzero <= mass[i].Length / 2) {newmass[j] = new int[mass[i].Length]; newmass[j] = mass[i]; j++; }
                summzero = 0;
            }
            mass = newmass;
        }
        static void Mover(int[][] mass)
        {
            int s, temp;
            while(1 == 1)
            {
                Console.Write("Введите номер строки для сдвига : ");
                s = Convert.ToInt32(Console.ReadLine()) - 1;
                temp = mass[s][mass[s].Length - 1];
                for(int i = mass[s].Length - 1; i > 0; i--)
                    mass[s][i] = mass[s][i - 1];
                mass[s][0] = temp;
                foreach (int x in mass[s]) Console.Write($"{x} ");
                Console.WriteLine();
                Console.Write("Хотите повторить сдвиг? ");
                if (Console.ReadLine() != "да") break;
            }
        }
        static void Main(string[] args)
        {
            int[][] mass;
            Console.Write("ВВедите количество строк массива : ");
            int n = Convert.ToInt32(Console.ReadLine());
            mass = InputArray(n);
            Console.WriteLine("Ваш массив : ");
            Output(mass);
            int[] mass2;
            MFinder(mass, out mass2);
            Mover(mass);
            Console.WriteLine("Массив полсе уплотнения : ");
            Zipper(ref mass);
            Output(mass);
            Console.ReadKey();
        }
    }
}
