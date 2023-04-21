namespace PA4
{
    public class JackSparrow : Character
    {
        public JackSparrow(string name) : base(name, new Random().Next(1, 101))
        {
            AttackBehavior = new Distract();
        }
    }
}