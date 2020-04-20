using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фоновая_5._1
{
    enum BodyType { Седан = 1, Купе, Хэчбек, Универсал, Кабриолет };
    class TransMeans
    {
        string name;
        protected int fuelWastingPerHundred;
        int fuaelVol;
        public TransMeans()
        {
            name = "Toyota";
            fuelWastingPerHundred = 100;
            fuaelVol = 1000;
        }
        public TransMeans(string name, int fW, int fV)
        {
            this.name = name;
            this.fuelWastingPerHundred = fW;
            this.fuaelVol = fV;
        }
        public string GetName { get { return name; } }
        public float Distance { get { return (float)fuaelVol / ((float)fuelWastingPerHundred / 100); } }
        public float FuelForDistance(float distance) { return (distance * ((float)fuelWastingPerHundred) / 100); }
    }
    class Car : TransMeans
    {
        int bodyType;
        int maxPeople;
        int peopleInCar;
        public Car(): base()
        {
            this.bodyType = 0;
            this.maxPeople = 5;
            this.peopleInCar = 5;
        }
        public Car(string name, int fW, int fV, int bT, int mP, int pIC) : base(name, fW, fV)
        {
            this.bodyType = bT;
            this.maxPeople = mP;
            this.peopleInCar = pIC;
        }
        public float peoplePercent() { return (float)peopleInCar / ((float)maxPeople / 100); }
        public int GetBody { get { return bodyType; } }
        public int GetPeopleInCar
        {
            get { return peopleInCar; }
            set
            {
                try
                {
                    if (value > maxPeople) throw new Exception("Кол-во людей превышает максимальной для данной машины");
                    if (value < 0) throw new Exception("Людей не может быть меньше 0");
                    peopleInCar = value;
                    Console.WriteLine("Успешно!");
                }
                catch (Exception Error) { Console.WriteLine($"Ошибка : {Error.Message}"); }
            }
        }
        new public float FuelForDistance(float distance)
        {
            return (distance * ((float)fuelWastingPerHundred) / 100 + (0.16F * peopleInCar * (float)fuelWastingPerHundred / 100));
        }
    }
    class Truck : TransMeans
    {
        float maxWeignt;
        float goodsWeign;
        public Truck() : base()
        {
            maxWeignt = 1000;
            goodsWeign = 500;
        }
        public Truck (string name, int fW, int fV, float mW, float gW) : base(name, fW, fV)
        {
            this.maxWeignt = mW;
            this.goodsWeign = gW;
        }
        public float GetMaxWeight { get { return maxWeignt; } }
        public float GetGoodsWeight
        {
            get { return goodsWeign; }
            set
            {
                try
                {
                    if (value > maxWeignt) throw new Exception("Груз весит больше максимальной грузоподъёмности");
                    if (value < 0) throw new Exception("Груз не может весить меньше 0");
                    goodsWeign = value;
                }
                catch (Exception Error) { Console.WriteLine($"Ошибка : {Error.Message}"); }
            }
        }
        public float WeightPercent { get { return goodsWeign / (maxWeignt / 100); } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int len;
            Car[] someCars = new Car[2];
            for (int i = 1; i <= 2; i++) someCars[i - 1] = new Car("BMW", i * 5, i * 16, i, i + 2, i);
            for (int i = 1; i <= 2; i++)
            {
                Console.Write($"\nМашина {i}\nКакое расстояние вы собираетесь проехать? ");
                len = Convert.ToInt32(Console.ReadLine());
                Console.Write($@"Производитель     :  {someCars[i - 1].GetName}
Тип кузова        :  {(BodyType)someCars[i - 1].GetBody}
Дальность поездки :  {someCars[i - 1].Distance:F2}км
Расход топлива при преодалении {len}км : {someCars[i - 1].FuelForDistance(len):F2}л
В машине {someCars[i - 1].GetPeopleInCar} пассажиров
Сейчас машина загружена на {someCars[i - 1].peoplePercent() / 100:P}
Хотите изменить количество пассажиров? ");
                if (Console.ReadLine().ToLower().Replace("l","д").Replace("f","а") == "да")
                {
                    Console.Write("Введите количество пассажиров : ");
                    someCars[i - 1].GetPeopleInCar = Convert.ToInt32(Console.ReadLine());
                }    
            }
            Truck[] Trucks = new Truck[2];
            for (int i = 1; i <= 2; i++) Trucks[i - 1] = new Truck("URAL", i * 12, i * 20, i * 1000, i * 645);
            for (int i = 1; i <= 2; i++)
            {
                Console.Write($"\nГрузовик {i}\nКакое расстояние вы собираетесь проехать? ");
                len = Convert.ToInt32(Console.ReadLine());
                Console.Write($@"Производитель     :  {Trucks[i - 1].GetName}
Дальность поездки :  {Trucks[i - 1].Distance:F2}
Максимальная грузоподъёмность : {Trucks[i - 1].GetMaxWeight}
Расход топлива при преодалении {len}км : {Trucks[i - 1].FuelForDistance(len):F2}л
Груз весит {Trucks[i - 1].GetGoodsWeight} кг
Сейчас машина загружена на {Trucks[i - 1].WeightPercent / 100:P}
Хотите изменить вес груза? ");
                if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
                {
                    Console.Write("Введите новый вес : ");
                    Trucks[i - 1].GetGoodsWeight = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.ReadLine();
        }
    }
}
