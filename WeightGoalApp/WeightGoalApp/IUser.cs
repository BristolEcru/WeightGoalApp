using static WeightGoalApp.UserBase;

namespace WeightGoalApp
{
    public interface IUser
    {
        //metody
        

        public Calculation GetCalculation();

        public event DelegateForSuccesfullyAdded SucessfullyAdded;
    }
}
