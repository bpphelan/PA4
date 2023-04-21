namespace PA4
{
    public class DavyJones : Character
    {
        public DavyJones(string name) : base(name, new Random().Next(1, 101))
        {
            AttackBehavior = new CannonFire();
        }
        
    }
}