using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.UI
{
    public class ChalOneUI
    {
        private readonly KomodoMenuRepo _KMenu = new KomodoMenuRepo();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the option you would like to select: \n" +
                    "1. Show all menu items.\n" +
                    "2. Add new menu item. \n" +
                    "3. Remove menu item. \n" +
                    "4. Exit. \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                    case "one":
                        ShowFullMenu();
                        break;
                    case "2":
                    case "two":
                        AddItemToMenu();
                        break;
                    case "3":
                    case "three":
                        RemoveItemFromMenu();
                        break;
                    case "4":
                    case "four":
                    case "exit":
                        keepRunning = false;
                        break;
                    default:
                        AnyKey();
                        break;
                }
            }
        }
        private void ShowFullMenu()
        {
            Console.Clear();
            List<KomodoMenu> menuList = _KMenu.GetMenuItems();
            foreach (KomodoMenu item in menuList)
            {
                DisplayMenuStuff(item);
            }
            AnyKey();
        }
        private void AddItemToMenu()
        {
            Console.Clear();
            KomodoMenu menu = new KomodoMenu();
            Console.WriteLine("Enter a Meal Number: ");
            menu.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Meal Name: ");
            menu.MealName = Console.ReadLine();
            Console.WriteLine("Enter a Meal Description: ");
            menu.MealDescrip = Console.ReadLine();
            Console.WriteLine("Enter a Meal Price: ");
            menu.MealPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Meal Indgredients: ");
            Console.WriteLine("Enter Ingredient Items:  ");
            Console.WriteLine("1. Fries \n" +
                "2. Drink \n" +
                "3. Burger \n" +
                "4. Chicken Sandwich \n" +
                "5. Chicken Nuggets ");
            string ingredientInput = Console.ReadLine();
            int ingrID = int.Parse(ingredientInput);
            menu.ItemIngredients = (IngredientsList)ingrID;
            if (_KMenu.AddItemToMenu(menu))
            {
                Console.WriteLine("Menu Item Added.");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Menu Item not added");
                AnyKey();
            }

        }
        private void RemoveItemFromMenu()
        {
            Console.Clear();
            Console.WriteLine("What menu item would you like to remove?\n");
            List<KomodoMenu> currentMenu = _KMenu.GetMenuItems();
            int count = 0;
            foreach (KomodoMenu item in currentMenu)
            {
                count++;
                Console.WriteLine($"{count}. {item.MealNumber}");
            }
            int targetMealNum = int.Parse(Console.ReadLine());
            int targetIndex = targetMealNum - 1;
            if (targetIndex >= 0 && targetIndex < currentMenu.Count)
            {
                KomodoMenu desiredMealNum = currentMenu[targetIndex];
                if (_KMenu.DeleteItem(desiredMealNum))
                {
                    Console.WriteLine($"{desiredMealNum.MealNumber} was removed");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("Removal Failed.");
                    AnyKey();
                }
            }
        }
        private void DisplayMenuStuff(KomodoMenu menu)
        {
            Console.WriteLine(
                $"Meal Number: {menu.MealNumber}\n" +
                $"Meal Name: {menu.MealName}" +
                $"Meal Descrip: {menu.MealDescrip}" +
                $"Meal Price: {menu.MealPrice}");
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

    }
}
