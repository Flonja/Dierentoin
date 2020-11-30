namespace Dierentoin.Data.Animals
{
    public sealed class Lion : Animal
    {
        public Lion() : base(25)
        {
            Name = "Lion";
        }

        public override void UseEnergy()
        {
            Energy -= 10;
        }
    }
}
