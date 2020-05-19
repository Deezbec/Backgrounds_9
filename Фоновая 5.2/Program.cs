using System;

namespace Фоновая_5._2
{
    enum DriveUnitType { manual, steam, hydraulic, pneumatic, internalCombustionEngine, electric };
    class Truck 
    {
        protected string name;
        protected int truckMass;
        protected int lenLoss;
        protected int maxMass;
        protected int goodsMass;
        protected Truck()
        {
            this.name = "DUBNA";
            this.truckMass = 500;
            this.lenLoss = 10000;
            this.maxMass = 1000;
            this.goodsMass = 967;
        }
        protected Truck(string name, int truckMass, int lenLoss, int maxMass, int goodsMass)
        {
            this.name = name;
            this.truckMass = truckMass;
            this.lenLoss = lenLoss;
            this.maxMass = maxMass;
            this.goodsMass = goodsMass;
        }
        protected int GetAllMass { get { return goodsMass + truckMass; } }
        protected string GetName { get { return this.name; } }
        protected int GetGoodsMass { get { return this.goodsMass; } set { this.goodsMass = value; } }
        protected void AllTrucksInf(out string name, out int truckMass, out int lenLoss, out int maxMass, out int goodsMass)
        {
            name = this.name;
            truckMass = this.truckMass;
            lenLoss = this.lenLoss;
            maxMass = this.maxMass;
            goodsMass = this.goodsMass;
        }
        protected int MaxLengthNow() { return this.lenLoss - GetAllMass / 100; }
    }
    class WheelsT : Truck
    {
        protected int wheelCount;
        protected DriveUnitType UnitType;
        public WheelsT () : base()
        {
            wheelCount = 8;
            UnitType = (DriveUnitType)1;
        }
        public WheelsT(string name, int truckMass, int lenLoss, int maxMass, int goodsMass, int wheelCount, int UnitType) : base(name, truckMass, lenLoss, maxMass, goodsMass)
        {
            this.wheelCount = wheelCount;
            this.UnitType = (DriveUnitType)UnitType;
        }
        new public int MaxLengthNow()
        {
            if (wheelCount < 4) return 0;
            return base.MaxLengthNow();
        }
        public void AllTrucksInf(out string name, out int truckMass, out int lenLoss, out int maxMass, out int goodsMass, out int wheelCount, out DriveUnitType UnitType)
        {
            base.AllTrucksInf(out name, out truckMass, out lenLoss, out maxMass, out goodsMass);
            wheelCount = this.wheelCount;
            UnitType = this.UnitType;
        }
    }
    class FreightTrain : WheelsT
    {
        protected int countWagon;
        public FreightTrain() : base()
        {
            countWagon = 75;
        }
        public FreightTrain(string name, int truckMass, int lenLoss, int maxMass, int goodsMass, int wheelCount, int UnitType, int countWagon) : base(name, truckMass, lenLoss, maxMass, goodsMass, wheelCount, UnitType)
        {
            this.countWagon = countWagon;
        }
        public void AllTrucksInf(out string name, out int truckMass, out int lenLoss, out int maxMass, out int goodsMass, out int wheelCount, DriveUnitType UnitType, out int countWagon)
        {
            base.AllTrucksInf(out name, out truckMass, out lenLoss, out maxMass, out goodsMass, out wheelCount, out UnitType);
            countWagon = this.countWagon;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
