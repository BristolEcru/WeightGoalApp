using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeightGoalApp
{
    public class UserInMemory : UserBase
    {
        public UserInMemory() { }

        public UserInMemory(string username) : base(username) { this.Name = username; }
        public UserInMemory(string name, float currentweight, float weightgoal, int caloriesdeficit)
        {
            this.Name = name;
            this.CurrentWeight = currentweight;
            this.WeightGoal = weightgoal;
            this.CaloriesDeficit = caloriesdeficit;

        }

        public override event DelegateForSuccesfullyAdded SucessfullyAdded;


        public override Calculation GetCalculation()
        {
            var calculation = new Calculation();
            try
            {
                calculation.AddData(this.CurrentWeight, this.WeightGoal, this.CaloriesDeficit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Something went wrong with adding data. Exception: {ex.Message})");
            }
            return calculation;

        }

        public bool CheckIfGain()
        {
            if (this.KilogramDifference < 0)
                return true;
            else
                return false;
        }
        public void DisplayCalculationInConsoleForLoss()
        {
            var calc = this.GetCalculation();
            Console.WriteLine($"\n {this.Name}, you wish to lose {(calc.KilogramDifference):N1} kg of fat tissue");
            Console.WriteLine($" This is the equivalent of {calc.CaloriesToGo} calories");
            Console.WriteLine($" If you reduce your normal daily intake by {calc.CaloriesDeficit} kcal");
            Console.WriteLine($" You will achievie your goal in {calc.NumberOfDays} days!!!");
            Console.WriteLine(" You can do it! :)");
            Console.WriteLine();
        }

        public void DisplayCalculationInConsoleForGain()
        {
            var calc = this.GetCalculation();
            Console.WriteLine($"\n {this.Name}, you wish to gain {(-1)*(calc.KilogramDifference):N1} kg of fat tissue");
            Console.WriteLine($" This is the equivalent of {(-1)*calc.CaloriesToGo} calories");
            Console.WriteLine($" If you increase your normal daily intake by {calc.CaloriesDeficit} kcal");
            Console.WriteLine($" You will achievie your goal in {(-1)*calc.NumberOfDays} days!!!");
            Console.WriteLine(" You can do it! :)");
            Console.WriteLine();
        }


        public void SetCurrentWeight(string weight)
        {
            try
            {
                var currentweight = float.Parse(weight);
                SetCurrentWeight(currentweight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"This is not a valid value for weight. Exception: {ex.Message}");
                Console.WriteLine("Insert correct value again: ");
                var anothertry = Console.ReadLine();
                SetCurrentWeight(anothertry);
            }
        }
        public void SetWeightGoal(string weight)
        {
            if (float.TryParse(weight, out var weightgoal))
            {
                SetWeightGoal(weightgoal);
            }
            else
            {
                Console.WriteLine($"This is not a valid value for weight");
                Console.WriteLine("Insert correct value again: ");
                var anothertry = Console.ReadLine();
                SetWeightGoal(anothertry);
            }
        }
        public void SetCaloriesDeficit(string deficit)
        {
            try
            {
                var caloriesdeficit = Int32.Parse(deficit);
                SetCaloriesDeficit(caloriesdeficit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"This is not a valid value for calories deficit. Exception: {ex.Message}");
            }
        }

        public override void SetCurrentWeight(float currentweight)
        {
            if (currentweight > 39 && currentweight < 200)
            {
                this.CurrentWeight = currentweight;
                if (SucessfullyAdded != null)
                {
                    SucessfullyAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("This isn't considered a healthy weight. Calculation cannot be done.");
                throw new Exception("If you are concerned about the weight please consult your doctor");
            }
        }
        public override void SetWeightGoal(float weightgoal)
        {
            if (weightgoal > 39 && weightgoal < 200)
            {
                this.WeightGoal = weightgoal;
                if (SucessfullyAdded != null)
                {
                    SucessfullyAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("This isn't considered a healthy weight. Calculation cannot be done.");
                throw new Exception("If you are concerned about the weight please consult your doctor");
            }
        }

        public override void SetCaloriesDeficit(int caloriesdeficit)
        {
            if (caloriesdeficit >=100 && caloriesdeficit <= 1000)
            {
                this.CaloriesDeficit = caloriesdeficit;
                if (SucessfullyAdded != null)
                {
                    SucessfullyAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("This isn't considered a healthy calories deficit. Calculation cannot be done.");
                throw new Exception("If you are concerned about calories please consult your doctor");
            }
        }
    }
}
