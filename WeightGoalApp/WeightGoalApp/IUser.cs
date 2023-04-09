using static WeightGoalApp.UserBase;

namespace WeightGoalApp
{
    public interface IUser
    {
        
        public void SetCurrentWeight(float currentweight);
        public void SetWeightGoal(float weightgoal);
        public void SetCaloriesDeficit(int caloriesdeficit);

        public Calculation GetCalculation();

        public event DelegateForSuccesfullyAdded SucessfullyAdded;
    }
}
