using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightGoalApp
{
    public class Calculation
    {
        public int NumberOfDays { get; set; }

        public static int KiloFat { get=> 7000;}

        public float CaloriesToGo { get; set; }

        public float CurrentWeight { get; set; }

        public float WeightGoal { get; set; }

        public float KilogramDifference { get; set; }

        public int CaloriesDeficit { get; set; }

        public Calculation() 
        {
            this.NumberOfDays = 0;
            this.CaloriesToGo = 0;
        }

        public void AddData(float currentweight, float goalweight, int caloriesdeficit) 
        {
            
            this.KilogramDifference = currentweight - goalweight;

            this.CaloriesDeficit = caloriesdeficit;

            this.CaloriesToGo = this.KilogramDifference * KiloFat;

            this.NumberOfDays = (int)(CaloriesToGo / CaloriesDeficit);

        }

    }
}
