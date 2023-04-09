using WeightGoalApp;

namespace WeightGoalAppTests
{
    public class UserInFileTests
    {
        public UserInFile GetUserEmptyConstructor()
        {
            return new UserInFile();
        }
        public UserInFile GetUserWithOnlyNameInConstructor(string name)
        {
            return new UserInFile("Natalia");
        }
        public UserInFile GetUserWithDataInserted(string name, float currentweight, float goalweight, int caloriesdeficit)
        {
            return new UserInFile(name, currentweight, goalweight, caloriesdeficit);
        }


        [Test]
        public void IfUserInFileExampleNameIsCreatedWithEmptyConstructor()
        {
            var name = GetUserEmptyConstructor().Name;

            Assert.That("Example Person", Is.EqualTo(name));
        }

        [Test]
        public void IfUserInFileNameIsCreatedWithOnlyNameInConstructor()
        {
            var name = GetUserWithOnlyNameInConstructor("Natalia").Name;

            Assert.That("Natalia", Is.EqualTo(name));

        }

        [Test]
        public void IfUserInFileNameIsCreatedWithAllDataInserted()
        {
            var name = GetUserWithDataInserted("Maria", 67.5f, 60, 400).Name;

            Assert.That("Maria", Is.EqualTo(name));
        }

        [Test]

        public void IfKilogramDifferenceIsCalculatedCorrectly()
        {
            UserInFile userinfile = GetUserWithOnlyNameInConstructor("Maria");
            userinfile.SetCurrentWeight(67.5f);
            userinfile.SetWeightGoal(60f);
            userinfile.SetCaloriesDeficit(500);

            Calculation calculation = userinfile.GetCalculation();

            var kilogramdifference = calculation.KilogramDifference;

            Assert.AreEqual(7.5f, kilogramdifference);
        }


        [Test]

        public void IfCanSetNewWeightGoalToTheUser()
        {
            UserInFile userinfile = GetUserWithDataInserted("Maria", 67.5f, 60, 400);
            userinfile.SetWeightGoal(56);
            float weightgoalset = userinfile.WeightGoal;

            Assert.AreEqual(56, weightgoalset);
        }

        [Test]

        public void IfNumberOfDaysIsCorrectlyCalculated()
        {
            UserInFile userinfile = GetUserWithOnlyNameInConstructor("Maria");
            userinfile.SetCurrentWeight(70);
            userinfile.SetWeightGoal(69);
            userinfile.SetCaloriesDeficit(500);

            Calculation calculation = userinfile.GetCalculation();
            int numberofdays = calculation.NumberOfDays;

            //User wants to lose 70-69 = 1kg 
            //to lose 1kg of fat it is required to lose 7000 calories.
            //When deficit is 500kcal a day you need 14 days (14 * 500 = 7000).
            //int kaloriestolose = 7000;
            //int deficitofcalories = 500;
            //int calculateddays = kaloriestolose/deficitofcalories;

            Assert.AreEqual(14, numberofdays);

        }



    }
}