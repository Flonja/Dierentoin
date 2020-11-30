namespace Dierentoin.Data.Animals
{
    public sealed class Elephant : Animal
    {
        public Elephant() : base(50)
        {
            Name = "Elephant";
        }

        public override void UseEnergy()
        {
            Energy -= 5;
        }
    }
}
