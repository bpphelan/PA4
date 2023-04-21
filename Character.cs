using PA4.Interfaces;

namespace PA4
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxPower { get; set; }
        public int Health { get; set; }
        public int AttackStrength { get; set; }
        public int DefensivePower { get; set; }
        public IAttack AttackBehavior { get; set; }

        public Character(string name, int maxPower)  
        {
            Name = name;
            MaxPower = maxPower;
            Health = 100;

            // Generate attack strength and defensive power as a percentage of max power (e.g., 40% to 90%)
            Random random = new Random();
            AttackStrength = random.Next((int)(maxPower * 0.4), (int)(maxPower * 0.9));
            DefensivePower = random.Next((int)(maxPower * 0.4), (int)(maxPower * 0.9));

            // Ensure that the AttackStrength is greater than the DefensivePower
            while (AttackStrength <= DefensivePower)
            {
                AttackStrength = random.Next((int)(maxPower * 0.4), (int)(maxPower * 0.9));
            }
        }

        public void SetAttackBehavior(IAttack newAttackBehavior)
        {
            AttackBehavior = newAttackBehavior;
        }

        public void Attack(Character opponent)
        {
            AttackBehavior.PrimaryAttack();
            float effectiveness = Game.AttackEffectiveness(this, opponent);
            int effectiveAttackPower = (int)Math.Ceiling(AttackStrength * effectiveness);
            Console.WriteLine("Effectiveness is : "+effectiveness+"  Attack Strength is : "+AttackStrength+": Effective Attackpower is : "+effectiveAttackPower);
            int damage = effectiveAttackPower - opponent.DefensivePower;
            damage = Math.Max(0, damage); // Ensure damage is not negative

            System.Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{Name}'s effective attack power: {effectiveAttackPower}");
            Console.WriteLine($"{opponent.Name}'s defense power: {opponent.DefensivePower}");
            Console.WriteLine($"{Name} dealt {damage} damage.");
            System.Console.WriteLine("-----------------------------------------");

            opponent.Defend(damage);
        }

        public void Defend(int damage)
        {
            Health -= damage;
            // Health = Math.Max(0, Health); // Ensure health doesn't go below 0
            Health = Health >= 1 ? Health : 0;
        }

        public string GetStats()
        {
            System.Console.WriteLine("-----------------------------------------");
            return $"Name: {Name}\nHealth: {Health}\nAttack Strength: {AttackStrength}\nDefensive Power: {DefensivePower}";
            System.Console.WriteLine("-----------------------------------------");
        }
    }
}
