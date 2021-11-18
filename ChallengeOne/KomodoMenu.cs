using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    public enum IngredientsList {Burger=1, ChickenSandwich, Nuggets  }
    public class KomodoMenu
    {
        public KomodoMenu()
        {

        }
        public KomodoMenu (int mealNumber, string mealName, string mealDescrip, double mealPrice, IngredientsList ingredients )
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescrip = mealDescrip;
            MealPrice = mealPrice;
            ItemIngredients = ingredients;
        }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescrip { get; set; }
        public double MealPrice { get; set; }
        public IngredientsList ItemIngredients { get; set; }
    }
}
