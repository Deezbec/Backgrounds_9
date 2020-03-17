using System;
//Вариант 7
namespace Фоновая_4._1
{
    class Ellips
    {
        private double EllipsMajorAxis;
        private double EllipsLessAxis;
        private Ellips()
        {
            this.EllipsMajorAxis = 10;
            this.EllipsLessAxis = 4;
        }
        private Ellips(double EllipsMajorAxis, double EllipsLessAxis)
        {
            this.EllipsMajorAxis = EllipsMajorAxis;
            this.EllipsLessAxis = EllipsLessAxis;
        }
        public static Ellips Ins()
        {
            Ellips MyOwnOne;
            Console.Write("Хотите ли вы задать Оси сами? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
            {
                double x = Ellips.Inserter(true), y = Ellips.Inserter(false);
                MyOwnOne = new Ellips(x, y);
            }
            else MyOwnOne = new Ellips();
            return MyOwnOne;
        }
        static double Inserter(bool statement)
        {
            double JustANumber = 0;
            do
            {
                try
                {
                    if (statement) Console.Write("Введите длину большей оси : ");
                    else Console.Write("Введите длину меньшей оси : ");
                    JustANumber = Convert.ToDouble(Console.ReadLine());
                    if (JustANumber < 0) throw new Exception("Было введено значение меньше 0");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка: {Error.Message}");
                }
            }
            while (JustANumber < 0);
            return JustANumber;
        }
        public double GetCompressionRatio { get { return this.GetHalfLessAxis / this.GetHalfMajorAxis; } }
        public double GetApofocusLength { get { return this.GetHalfMajorAxis * (1 + this.GetEccentricity); } }
        public double GetPerifocusLength { get { return this.GetHalfMajorAxis * (1 - this.GetEccentricity); } }
        private double GetEccentricity { get { return Math.Sqrt(1.00 - Math.Pow(GetHalfLessAxis, 2) / Math.Pow(GetHalfMajorAxis, 2)); } }
        public double GetHalfMajorAxis { get { return EllipsMajorAxis / 2; } }
        public double GetHalfLessAxis { get { return EllipsLessAxis / 2; } }
        public double GetFocalLength { get { return this.GetEccentricity * this.GetHalfMajorAxis; } }
        public double GetFocalParam { get { return Math.Pow(GetHalfLessAxis, 2) / GetHalfMajorAxis; } }
        public double GetArea
        {
            get
            {
                double Pi = 3.1415926535;
                double Area = Pi * GetHalfMajorAxis * GetHalfLessAxis;
                return Area;
            }
        }
        public double GetPerimeter
        {
            get
            {
            double Perimeter = 4 * (GetArea + Math.Pow((GetHalfMajorAxis - GetHalfLessAxis), 2)) /
                               (GetHalfMajorAxis + GetHalfLessAxis);
            return Perimeter;
            }
        }
        public double GetRad(double Angle)
        {
            double Rad = GetHalfLessAxis / (Math.Sqrt(1.00 - Math.Pow(GetEccentricity, 2) * Math.Pow(Math.Cos((Angle / 57.2958)), 2)));
            return Rad;
        }
        public double MajorAxis
        {
            get { return EllipsMajorAxis / 2; }
            set 
            {
                try
                {
                    if (value >= 0) EllipsMajorAxis = value;
                    else throw new Exception("Было введено число меньше 0");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка: {Error.Message}");
                }
            }
        }
        public double LessAxis
        {
            get { return EllipsLessAxis / 2; }
            set
            {
                try
                {
                    if (value >= 0) EllipsLessAxis = value;
                    else throw new Exception("Было введено число меньше 0");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка: {Error.Message}");
                }
            }
        }
        public bool Circle
        {
            get { if (EllipsLessAxis == EllipsMajorAxis) return true; else return false; }
        }
        public double GetMajorAxis { get { return this.EllipsMajorAxis; } }
        public double GetLessAxis { get { return this.EllipsLessAxis; } }
    }
    class Program
    {
        static void Actions(Ellips MyOwnOne)
        {
            Console.WriteLine($@"Большая ось равна {MyOwnOne.GetMajorAxis}
Меньшая ось равна {MyOwnOne.GetLessAxis}

Получить значение большей полуоси - 1
Получить значение меньшей полуоси - 2
Получить радиус эллипса - 3
Получить площадь эллипса - 4
Получить периметр эллипса - 5
Получить коэффициент сжатия - 6
Получить перифокусное расстояние - 7
Получить апофокусное расстояние - 8
Получить фокальное расстояние - 9
Получить фокальный параметр - 10");
        }
        static void RadFun(Ellips MyOwnOne)
        {
            Console.Write("Введите угол между большой полуостью и этим радиусом : ");
            double Angle = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Радиус эллипса равен {MyOwnOne.GetRad(Angle):F2}");
        }
        static void Main(string[] args)
        {
            string s;
            Ellips MyOwnOne = Ellips.Ins();
            Console.WriteLine($@"Большая ось равна {MyOwnOne.GetMajorAxis}
Меньшая ось равна {MyOwnOne.GetLessAxis}");
            Console.Write("Хотите ли вы изменить оси? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
            {
                Console.Write("Введите длину большей оси : ");
                MyOwnOne.MajorAxis = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину меньшей оси : ");
                MyOwnOne.LessAxis = Convert.ToDouble(Console.ReadLine());
            }
            if (MyOwnOne.Circle) Console.WriteLine("Данный эллипс является кругом");
            else                 Console.WriteLine("Данный эллипс не является кругом");
            Actions(MyOwnOne);
            while(true)
            {
                //Console.Clear();
                //Actions(MyOwnOne);
                s = Console.ReadLine();
                switch (s)
                {
                    case "1": Console.WriteLine($"Большая полуось равна {MyOwnOne.GetHalfMajorAxis:F2}"); /*Console.ReadKey();*/ break;
                    case "2": Console.WriteLine($"Меньшая полуось равна {MyOwnOne.GetHalfLessAxis:F2}"); /*Console.ReadKey();*/ break;
                    case "3": RadFun(MyOwnOne); /*Console.ReadKey();*/ break;
                    case "4": Console.WriteLine($"Площадь равна {MyOwnOne.GetArea:F2}"); /*Console.ReadKey();*/ break;
                    case "5": Console.WriteLine($"Периметр равен {MyOwnOne.GetPerimeter:F2}"); /*Console.ReadKey();*/ break;
                    case "6": Console.WriteLine($"Коэффициент сжатия равен {MyOwnOne.GetCompressionRatio:F2}"); /*Console.ReadKey();*/ break;
                    case "7": Console.WriteLine($"Перифокусное расстояние равно {MyOwnOne.GetPerifocusLength:F2}"); /*Console.ReadKey();*/ break;
                    case "8": Console.WriteLine($"Апофокусное расстояние равно {MyOwnOne.GetApofocusLength:F2}"); /*Console.ReadKey();*/ break;
                    case "9": Console.WriteLine($"Фокальное расстояние равно {MyOwnOne.GetFocalLength:F2}"); /*Console.ReadKey();*/ break;
                    case "10": Console.WriteLine($"Фокальный параметр равен {MyOwnOne.GetFocalParam:F2}"); /*Console.ReadKey();*/ break;
                }
            }
        }
    }
}
