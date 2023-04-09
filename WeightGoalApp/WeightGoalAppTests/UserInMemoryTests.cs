
using WeightGoalApp;

namespace WeightGoalAppTests
{
    internal class UserInMemoryTests
    {
        public UserInMemory GetUserEmptyConstructor()
        {
            return new UserInMemory();
        }
        public UserInMemory GetUserWithOnlyNameInConstructor(string name)
        {
            return new UserInMemory("Natalia");
        }
        public UserInMemory GetUserWithDataInserted(string name, float currentweight, float goalweight, int caloriesdeficit)
        {
            return new UserInMemory(name, currentweight, goalweight, caloriesdeficit);
        }



        [Test]
        public void IfUserInMemoryExampleNameIsCreatedWithEmptyConstructor()
        {
            var name = GetUserEmptyConstructor().Name;

            Assert.That("Example Person", Is.EqualTo(name));
        }

        [Test]
        public void IfUserInMemoryNameIsCreatedWithOnlyNameInConstructor()
        {
            var name = GetUserWithOnlyNameInConstructor("Natalia").Name;

            Assert.That("Natalia", Is.EqualTo(name));

        }

        [Test]
        public void IfUserInMemoryIsCreatedWithAllDataInserted()
        {
            var name = GetUserWithDataInserted("Maria", 67.5f, 60, 400).Name;

            Assert.That("Maria", Is.EqualTo(name));
        }

        [Test]

        public void IfKilogramDifferenceIsCalculatedCorrectly()
        {
            var kilogramdifference = GetUserWithDataInserted("Maria", 67.5f, 60, 400).GetCalculation().KilogramDifference;

            Assert.AreEqual(7.5f,kilogramdifference);
        }


        [Test]

        public void IfCanSetNewWeightGoalToTheUser()
        {
            UserInMemory userinmemory = GetUserWithDataInserted("Maria", 67.5f, 60, 400);
            userinmemory.SetWeightGoal(56);
            float weightgoalset = userinmemory.WeightGoal;

            Assert.AreEqual(56, weightgoalset);
        }

        [Test]
        public void IfNumberOfDaysIsCorrectlyCalculated()
        {
            Calculation calculation = GetUserWithDataInserted("Maria", 70, 69, 500).GetCalculation();

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
