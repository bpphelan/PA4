using System;

namespace PA4
{
    public class Game
    {
        public Character Player1 { get; set; }
        public Character Player2 { get; set; }

        public void Play()
        {
            Console.WriteLine("Welcome to Pirates of the Caribbean");
            Console.WriteLine("Player 1, Enter name:");
            string player1Name = Console.ReadLine();
            Player1 = ChooseCharacter(player1Name);

            Console.WriteLine("Player 2, Enter name:");
            string player2Name = Console.ReadLine();
            Player2 = ChooseCharacter(player2Name, Player1);

            Character currentPlayer = ChooseFirstAttacker();
            Character opponent = currentPlayer == Player1 ? Player2 : Player1;

            Console.WriteLine($"{currentPlayer.Name} will be the first to attack");

            while (!IsGameOver())
            {
                Console.WriteLine($"{currentPlayer.Name}, press any key to attack");
                System.Console.WriteLine("-----------------------------------------");
                Console.ReadKey(true);

                Console.WriteLine($"{currentPlayer.Name} just attacked");
                currentPlayer.Attack(opponent);

                Console.WriteLine($"{opponent.Name}'s stats:");
                Console.WriteLine(opponent.GetStats());

                // Swap the players
                Character temp = currentPlayer;
                currentPlayer = opponent;
                opponent = temp;
            }

            string winner = Player1.Health > 0 ? Player1.Name : Player2.Name;
            Console.WriteLine($"{winner} has won");
        }


        public Character ChooseCharacter(string playerName, Character otherPlayer = null)
        {
            System.Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{playerName}, Choose a character:");
            Console.WriteLine("1. Jack Sparrow");
            Console.WriteLine("2. Will Turner");
            Console.WriteLine("3. Davy Jones");
            System.Console.WriteLine("-----------------------------------------");

            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return ChooseCharacter(playerName, otherPlayer);
            }

            switch (choice)
            {
                case 1:
                    if (otherPlayer is JackSparrow)
                    {
                        Console.WriteLine("That character has already been chosen. Please choose another.");
                        return ChooseCharacter(playerName, otherPlayer);
                    }
                    return new JackSparrow(playerName);
                case 2:
                    if (otherPlayer is WillTurner)
                    {
                        Console.WriteLine("That character has already been chosen. Please choose another.");
                        return ChooseCharacter(playerName, otherPlayer);
                    }
                    return new WillTurner(playerName);
                case 3:
                    if (otherPlayer is DavyJones)
                    {
                        Console.WriteLine("That character has already been chosen. Please choose another.");
                        return ChooseCharacter(playerName, otherPlayer);
                    }
                    return new DavyJones(playerName);
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return ChooseCharacter(playerName, otherPlayer);
            }
        }


        public Character ChooseFirstAttacker()
        {
            Random random = new Random();
            return random.Next(2) == 0 ? Player1 : Player2;
        }

        public void DisplayStats(Character character)
        {
            Console.WriteLine(character.GetStats());
        }

        public static float AttackEffectiveness(Character attacker, Character defender)
        {
            float typeBonus = 1.0f;

            if ((attacker is JackSparrow && defender is WillTurner) || (attacker is WillTurner && defender is DavyJones) || (attacker is DavyJones && defender is JackSparrow))
            {
                typeBonus = 1.2f;
            }

            return typeBonus;

        }

        public bool IsGameOver()
        {
            return Player1.Health <= 0 || Player2.Health <= 0;
        }
    }
}
