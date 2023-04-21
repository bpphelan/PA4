namespace PA4
{
    public class WillTurner : Character
    {
        public WillTurner(string name) : base(name, new Random().Next(1, 101))
        {
            AttackBehavior = new Sword();
        }
    }
}