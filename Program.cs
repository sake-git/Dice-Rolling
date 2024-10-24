
namespace Dice_Roller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Casino!");

            //Get the input from user for number of sides of the dice
            Console.WriteLine("How many sides should each die have?");
            int diceSides = Convert.ToInt32(Console.ReadLine());
            int counter = 0;
            do
            {
                Console.WriteLine("\n*********************************************************");
                counter++;
                Console.WriteLine($"\nRoll {counter}:");

                //Roll pair of dice
                int dice1 = RollDice(diceSides);
                int dice2 = RollDice(diceSides);
                Console.WriteLine($"You rolled a {dice1} and a {dice2} ({dice1 + dice2} total)");

                // Display the message based on the roll of both dice
                string message = DiceRolledMessage(dice1, dice2, diceSides);
                if (message != "")
                {
                    Console.WriteLine(message);
                }

                // Display the outcome based on the total number on both rolls
                string outcome = DiceRollingOutcome(dice1, dice2, diceSides);
                if (outcome != "")
                {
                    Console.WriteLine(outcome);
                }

                Console.WriteLine("*********************************************************\n");

                Console.WriteLine("Roll again? (y/n): "); // check if user wants to continue

            } while (Console.ReadLine() == "y");
            Console.WriteLine("Thanks for playing!!");

            Console.ReadKey();
        }


        // Static method to generate random numbers for Dice roll
        public static int RollDice(int side)
        {
            Random randomObject = new Random();

            /* 'random.next()' method gets a random number between the given range.
               The number generated is inclusive of lower limit but exclusive of upper limit. */
            return randomObject.Next(1, side+1); 
        }

        //Get the message based on Dice roll.
        public static string DiceRolledMessage(int diceOneValue, int diceTwoValue, int diceSides)
        {
            string message = "";
            if (diceOneValue == 1 && diceTwoValue == 1)
            {
                message = "Snake Eyes";
            }
            else if ((diceOneValue == 1 && diceTwoValue == 2) || (diceOneValue == 2 && diceTwoValue == 1))
            {
                message = "Ace Deuce";
            }
            else if (diceOneValue == diceSides && diceTwoValue == diceSides) {
                message = "Box Cars";
            }

            return message;
        }
        
        //Get the outcome(win/lose) based on total value for 2 dice roll.
        public static string DiceRollingOutcome(int diceOneValue, int diceTwoValue, int diceSides)
        {
            string outcome = "";
            int total = diceOneValue + diceTwoValue;

            /* The win for dice with 6 sides is when total is either 7 or 11.
               To extend this to Dice with different number of side, below formula is created.

                 1. 'Max Value' + 1  (for 6 side dice this will be 7)   OR  
                 2. 'Max Value' + (Max Value - 1) (for 6 side dice this will be 11) 
            If this formula is applied for dice with 5 sides, the winning total will be 6 or 9
            */
            if (total == (diceSides + 1) || total == (diceSides * 2 - 1 )) 
            {
                outcome = "Win!";
            }
            /*
             If Total = 2 or 3 or Max Value * 2 returns "Craps"
             for eg: if dice has 6 side the  'max value' will be 6 
             So when user roll both dice and get 6 on each dice, i.e. total 12, Outcome will be 'Craps' 
             */
            else if (total == 2 || total == 3 || total == (diceSides * 2))
            {
                outcome = "Craps!";
            }

            return outcome;
        }
    }
}
