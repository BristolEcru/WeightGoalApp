
namespace WeightGoalApp
{
    public abstract class UserBase : IUser
    {
        public delegate void DelegateForSuccesfullyAdded(object sender, EventArgs e);
        public abstract event DelegateForSuccesfullyAdded SucessfullyAdded;

        public string Name { get; set; }

        public float CurrentWeight { get; set; }

        public float WeightGoal { get; set; }

        public float KilogramDifference { get => this.CurrentWeight - this.WeightGoal; }

        public int CaloriesDeficit { get; set; }
  

        public abstract void SetCurrentWeight(float currentweight);
        public abstract void SetWeightGoal(float weightgoal);
        public abstract void SetCaloriesDeficit(int caloriesdeficit);


        public abstract Calculation GetCalculation();

        public UserBase(string name)
        {
        this.Name = name;
        }

        public UserBase()
        {
            this.Name = "Example Person";
            this.CurrentWeight = 80;
            this.WeightGoal = 77;
            this.CaloriesDeficit = 200;

        }





    }
}
