using System;
using System.IO;
//Вариант 3
namespace Фоновая_4._2
{
    enum Months { Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь }
    class MatrixWeather
    {
        static Random rand = new Random();
        private int month;
        private int day;
        private int[,] temperature;
        private MatrixWeather()
        {
            day = 3;
            month = 1;
            temperature = RandInput();
        }
        private MatrixWeather(int month, int day)
        {
            this.day = day;
            this.month = month;
            temperature = RandInput();
        }
        public static MatrixWeather input()
        {
            MatrixWeather MyWeather;
            int x, y;
            Console.Write("Хотите ли вы задать день сами? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
            {
                x = action(true); y = action(false);
                MyWeather = new MatrixWeather(x, y);
            }
            else MyWeather = new MatrixWeather();
            return MyWeather;
        }
        static int action(bool f)
        {
            bool flag = true;
            int res;
            do
            {
                try
                {
                    if (f) Console.Write("Введите месяц : ");
                    else Console.Write("Введите день : ");
                    res = Convert.ToInt32(Console.ReadLine());
                    if (f) if (res < 1 || res > 12) throw new Exception("Не существует такого месяца"); else flag = false;
                    else if (res < 1 || res > 7) throw new Exception("Не существует такого дня"); else flag = false;
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка : {Error.Message}"); res = 0;
                    flag = true;
                }
            }
            while (flag);
            return res;
        }
        private int[,] RandInput()
        {
            int[,] res;
            if (month == 2 && day == 1) res = new int[4, 7];
            else
            {
                if ((month == 2 && day != 1) || (day <= 5 && month != 2)) res = new int[5, 7];
                else res = new int[6, 7];
            }
            int k = 0;
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++, k++)
                {
                    if (this.month == 12 || this.month <= 2) res[i, j] = rand.Next(-10, 1);
                    if (this.month > 2 && this.month <= 5) res[i, j] = rand.Next(-1, 19);
                    if (this.month > 5 && this.month <= 8) res[i, j] = rand.Next(12, 30);
                    if (this.month > 8 && this.month <= 11) res[i, j] = rand.Next(-3, 16);
                }
            }
            return res;
        }
        public void Output()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine((Months)month);
            int k = 0;
            int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Пн\tВт\tСр\tЧт\tПт\tСб\tВс");
            for (int i = 0; i < (this.day - 1); i++) { Console.Write("\t"); k++; }
            for (int i = 1; i <= Monthsn[this.month]; i++, k++)
            {
                if (k % 7 == 0 && i != 1) Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red; Console.Write($"{i:D2}");
                Console.ResetColor(); Console.Write($"  {this.temperature[k / 7, k % 7]}\t");
            }
            Console.WriteLine();
        }
        public int max(out int num, out int temp)
        {
            int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int max = 0, k = 0; num = 0; temp = 0;
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    k++;
                    if (i == 0 && j == 0) j = day - 1;
                    if (k > Monthsn[month]) break;
                    if (j == temperature.GetLength(1) - 1)
                    {
                        if (Math.Abs(temperature[i, j] - temperature[i + 1, 0]) > max)
                        {
                            max = Math.Abs(temperature[i, j] - temperature[i + 1, 0]);
                            temp = temperature[i, j];
                            num = k;
                        }
                    }
                    else
                    {
                        if (Math.Abs(temperature[i, j] - temperature[i, j + 1]) > max)
                        {
                            max = Math.Abs(temperature[i, j] - temperature[i, j + 1]);
                            temp = temperature[i, j];
                            num = k;
                        }
                    }
                }
            }
            return max;
        }
        private void MoverRight()
        {
            int temp1 = temperature[0, temperature.GetLength(1) - 1], temp2;
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                temp2 = temperature[i, temperature.GetLength(1) - 1];
                for (int j = temperature.GetLength(0); j > 0; j--)
                    temperature[i, j] = temperature[i, j - 1];
                temperature[i, 0] = temp1;
                temp1 = temp2;
            }
        }
        private void MoverLeft()
        {
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                if (i != 0) temperature[i - 1, temperature.GetLength(1) - 1] = temperature[i, 0];
                for (int j = 0; j < temperature.GetLength(0); j++)
                    temperature[i, j] = temperature[i, j + 1];
            }
        }
        private void Adder(int[,] main, int[,] second)
        {
            for (int i = 0; i < main.GetLength(0); i++)
                for (int j = 0; j < main.GetLength(1); j++) if (i < second.GetLength(0) && j < second.GetLength(1)) second[i, j] = main[i, j];
        }
        public int Month
        {
            get { return month; }
            set
            {
                try { if (value < 1 || value > 12) throw new Exception("Не существует такого месяца"); else { month = value; temperature = RandInput(); Output(); } }
                catch (Exception Error) { Console.WriteLine($"Ошибка : {Error.Message}"); }
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int t = day;
                try
                {
                    int[,] NewOne = new int[6, 7];
                    Adder(temperature, NewOne);
                    temperature = NewOne;
                    if (value < 1 || value > 7) throw new Exception("Не существует такого дня");
                    else
                    {
                        day = value;
                        if (day > t) for (; t < day; t++) MoverRight();
                        else for (; t > day; t--) MoverLeft();
                        if (day + Monthsn[month] - 1 == 28)
                        {
                            NewOne = new int[4, 7];
                            Adder(temperature, NewOne);
                            temperature = NewOne;
                        }
                        if (day + Monthsn[month] - 1 > 28 && day + Monthsn[month] - 1 <= 35)
                        {
                            NewOne = new int[5, 7];
                            Adder(temperature, NewOne);
                            temperature = NewOne;
                        }
                        if (day + Monthsn[month] - 1 > 35)
                        {
                            NewOne = new int[6, 7];
                            Adder(temperature, NewOne);
                            temperature = NewOne;
                        }
                    }
                    Output();
                }
                catch (Exception Error) { Console.WriteLine($"Ошибка : {Error.Message}"); }
            }
        }
        public int[,] Temperature { get { return temperature; } }
        public int ZeroDays
        {
            get
            {
                int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int k = 0, l = 0;
                for (int i = 0; i < (this.day - 1); i++) k++;
                for (int i = 1; i <= Monthsn[this.month]; i++, k++) if (this.temperature[k / 7, k % 7] == 0) l++;
                return l;
            }
        }
        public int SchoolDays
        {
            get
            {
                int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                return Monthsn[month] - (Monthsn[month] + day - 1) / 7;
            }
        }
        public static bool operator <(MatrixWeather First, MatrixWeather Second)
        {
            if (First.month < Second.month) return true;
            else return false;
        }
        public static bool operator >(MatrixWeather First, MatrixWeather Second)
        {
            if (First.month > Second.month) return true;
            else return false;
        }
        public static MatrixWeather operator ++(MatrixWeather Main)
        {
            Main.Day = Main.day + 1;
            return Main;
        }
        public static MatrixWeather operator --(MatrixWeather Main)
        {
            Main.Day = Main.day - 1;
            return Main;
        }
        public static bool operator true(MatrixWeather Main)
        {
            if (Main.ZeroDays == 0) return true;
            else return false;
        }
        public static bool operator false(MatrixWeather Main)
        {
            if (Main.ZeroDays != 0) return true;
            else return false;
        }
        int[] MassCreater
        {
            get
            {
                int k = 0, l = 0;
                int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int[] mass = new int[Monthsn[Month]];
                for (int i = 0; i < (this.day - 1); i++) k++;
                for (int i = 1; i <= Monthsn[this.month]; i++, k++, l++) mass[l] = this.temperature[k / 7, k % 7];
                return mass;
            }
        }
        public static bool operator &(MatrixWeather First, MatrixWeather Second)
        {
            int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Monthsn[First.Month] < Monthsn[Second.Month]) Monthsn[0] = Monthsn[First.Month];
            else Monthsn[0] = Monthsn[Second.Month];
            int[] massFirst = First.MassCreater, massSecond = Second.MassCreater;
            for (int i = 0; i < Monthsn[0]; i++)
            {
                if (massFirst[i] != massSecond[i]) return false;
            }
            return true;
        }
        public int this[int i, int j]
        {
            get
            {
                int[] Monthsn = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                try
                {
                    if (Day < i && j == 1) throw new Exception("Ошибка: день не существует");
                    if (i * j - day > Monthsn[Month]) throw new Exception("Ошибка: день не существует");
                    if (i * j - day <= Monthsn[Month]) return temperature[i, j];
                    return -1000;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    return -1000;
                }
            }
            set
            {
                try
                {
                    if (value < 50 && value > -50) temperature[i, j] = value;
                    else throw new Exception("Невозможная температура");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка : {Error.Message}");
                }
            }
        }
    }
    class Program
    {
        static void Changings(MatrixWeather MyOwn)
        {
            do
            {
                Console.Write("Хотите ли вы изменить месяц? ");
                if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да") { Console.Write("Введите месяц : "); MyOwn.Month = Convert.ToInt32(Console.ReadLine()); }
                Console.Write("Хотите ли вы изменить день? ");
                if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да") { Console.Write("Введите день : "); MyOwn.Day = Convert.ToInt32(Console.ReadLine()); }
                Console.Write("Хотите ли вы изменить что-нибудь ещё раз? ");
            }
            while (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да");
        }
        static void Main(string[] args)
        {
            int num, temp, day, month;
            MatrixWeather MyOwn = MatrixWeather.input(), SecondOne;
            MyOwn.Output();
            Console.WriteLine($@"
Самый большой суточный скачок температуры — {MyOwn.max(out num, out temp)}, 
он произошел в {num} день, температура которго составляла {temp}");
            Console.WriteLine($"Количество дней в дневнике — {MyOwn.SchoolDays}");
            Console.WriteLine($"Количество дней с температурой 0 — {MyOwn.ZeroDays}");
            Changings(MyOwn);
            Console.WriteLine("Теперь же вам придется создать еще один дневник");
            SecondOne = MatrixWeather.input();
            SecondOne.Output();
            if (MyOwn > SecondOne && SecondOne < MyOwn) Console.WriteLine("Первый дневник описывает месяц, идущий раньше того, который описывает второй");
            else Console.WriteLine("Первый дневник описывает месяц, идущий позже того, который описывает второй");
            Console.WriteLine("Сейчас 1ый дневник будет перемещен на 1 день влево");
            MyOwn--;
            Console.WriteLine("Сейчас 2ой дневник будет перемещен на 1 день вправо");
            SecondOne++;
            if (SecondOne) Console.WriteLine("Во 2ом дневнике нет ни одниго дня с t = 0");
            else Console.WriteLine("Во 2ом дневнике есть хотя бы 1 день с t = 0");
            if (MyOwn & SecondOne) Console.WriteLine("Дневники совпадают поэлементно");
            else Console.WriteLine("Дневники не совпадают поэлементно");
            do
            {
                Console.Write("Хотите посмотреть значение любого дня 1ого дневника? ");
                if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
                {
                    try
                    {
                        Console.Write("Введите день недели : ");
                        if (!Int32.TryParse(Console.ReadLine(), out day)) throw new Exception("Буквы — не цифры!");
                        Console.Write("Введите неделю : ");
                        if (!Int32.TryParse(Console.ReadLine(), out month)) throw new Exception("Буквы — не цифры!");
                        Console.WriteLine($"Значение дня {MyOwn[--day, --month]}");
                    }
                    catch (Exception Error)
                    {
                        Console.WriteLine($"Ошибка : {Error.Message}");
                    }
                }
                Console.Write("\nХотите изменить значение любого дня 1ого дневника? ");
                if(Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
                {
                    try
                    {
                        int number;
                        Console.Write("Введите день недели : ");
                        if (!Int32.TryParse(Console.ReadLine(), out day)) throw new Exception("Буквы — не цифры!");
                        Console.Write("Введите неделю : ");
                        if (!Int32.TryParse(Console.ReadLine(), out month)) throw new Exception("Буквы — не цифры!");
                        Console.Write("Введите новое значение : ");
                        if (!Int32.TryParse(Console.ReadLine(), out number)) throw new Exception("Буквы — не цифры!");
                        MyOwn[--day, --month] = number;
                        Console.WriteLine($"Получилося!");
                        MyOwn.Output();
                    }
                    catch (Exception Error)
                    {
                        Console.WriteLine($"Ошибка : {Error.Message}");
                    }
                }
                Console.Write("Хотите еще что-нибудь сделать со значениями 1ого дневника? ");
            }
            while (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да");
            Console.ReadKey();
        }
    }
}