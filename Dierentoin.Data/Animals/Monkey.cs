namespace Dierentoin.Data.Animals
{
    public sealed class Monkey : Animal
    {
        public Monkey() : base(10, 60)
        {
            Name = "Monkey";
        }

        public override void UseEnergy()
        {
            Energy -= 2;
        }
    }
}
