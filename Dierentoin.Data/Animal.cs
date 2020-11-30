using System;

namespace Dierentoin.Data
{
    public abstract class Animal
    {
        public Animal(int energyPerEat, int initialEnergy = 100)
        {
            EnergyPerEat = energyPerEat;
            Energy = initialEnergy;
        }

        public string Name { get; set; }
        public int Energy { get; protected set; }

        private int EnergyPerEat { get; set; }

        public void Eat()
        {
            Energy += EnergyPerEat;
        }

        public abstract void UseEnergy();
    }
}
