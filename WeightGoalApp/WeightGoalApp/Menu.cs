
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
                Console.WriteLine("What is your name?");
                var user = new UserInFile(Console.ReadLine());

                user.SucessfullyAdded += DataAccepted;
                Console.WriteLine("What is your body weight?");
                var input = Console.ReadLine();
                user.SetCurrentWeight(input);

                Console.WriteLine("And what is you WEIGHT GOAL?");
                input = Console.ReadLine();
                user.SetWeightGoal(input);


                if (user.CheckIfGain())
                {
                    Console.WriteLine("How many calories (range:1-1000) can you add to your daily food intake (per day) ?");
                    input = Console.ReadLine();
                    user.SetCaloriesDeficit(input);
                    user.DisplayCalculationInConsoleForGain();

                }
                else
                {
                    Console.WriteLine("How many calories (range:1-1000) can you skip in your daily food intake (per day) ?");
                    input = Console.ReadLine();
                    user.SetCaloriesDeficit(input);
                    user.DisplayCalculationInConsoleForLoss();

                }


                Console.WriteLine("Do you want to check again?");
                Console.WriteLine("y-> YES");
                Console.WriteLine("n-> End program");

                var choice = Console.ReadLine();
                //try
                //{
                //    number = Int32.Parse(choice);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.ToString());
                //    continue;
                //}
                switch (choice)
                {
                    case "y":
                        Console.Clear();
                        break;
                    case "n":
                        Console.Clear();
                        Console.WriteLine("\nThe End");
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nIncorrect value. Press y to try again. Press n to quit");
                        choice = Console.ReadLine();
                        if (choice == "y")
                            break;
                        else
                            return;
                }
            } while (true);
        }

    }
}

