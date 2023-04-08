
using System.Security.Cryptography.X509Certificates;

namespace WeightGoalApp
{
    public static class Menu
    {
        public static void Run()
        {

           
            void DataAccepted(object sender, EventArgs args)
            {
                Console.WriteLine("~~~Data accepted~~~");
            }


            Console.WriteLine("*********************************************");
            Console.WriteLine("***WELCOME TO YOUR WEIGHT GOAL CALCULATOR***");
            Console.WriteLine("*********************************************");
            Console.WriteLine("*********************************************");
            Console.WriteLine();

            do
            {

                Console.WriteLine("\n What is your name?");
                var user1 = new UserInFile(Console.ReadLine());
                user1.SucessfullyAdded += DataAccepted;
                Console.WriteLine("What is your body weight?");
                var input = Console.ReadLine();
                user1.SetCurrentWeight(input);
                Console.WriteLine("And what is you WEIGHT GOAL?");
                input = Console.ReadLine();
                user1.SetWeightGoal(input);
                if (user1.CheckIfGain())
                {
                    Console.WriteLine("How many calories can you add to your daily food intake (per day) ?");
                    input = Console.ReadLine();
                    user1.SetCaloriesDeficit(input);
                    user1.DisplayCalculationInConsoleForGain();
                }
                else
                {
                    Console.WriteLine("How many calories can you skip in your daily food intake (per day) ?");
                    input = Console.ReadLine();
                    user1.SetCaloriesDeficit(input);
                    user1.DisplayCalculationInConsoleForLoss();
                }

                Console.WriteLine("Do you want to check again?");
                Console.WriteLine("1-> YES");
                Console.WriteLine("2-> idk");
                Console.WriteLine("3-> End program");
                var choice = Console.ReadLine();
                int number = 3;
                try
                {
                    number = Int32.Parse(choice);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    continue;
                }
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        Console.WriteLine("\n The End");
                        return;
                    default:
                        Console.WriteLine("\n Incorrect value, try again ");
                        break;
                }
            } while (true);
        }
    }
}
