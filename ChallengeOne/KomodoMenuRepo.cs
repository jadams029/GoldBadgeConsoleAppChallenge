using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    public class KomodoMenuRepo
    {
        protected readonly List<KomodoMenu> _menuList = new List<KomodoMenu>();
        //CRUD
        //Create
        public bool AddItemToMenu(KomodoMenu menu)
        {
            int startCount = _menuList.Count;
            _menuList.Add(menu);
            bool wasAdded = (_menuList.Count > startCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<KomodoMenu> GetMenuItems()
        {
            return _menuList;
        }
        public KomodoMenu GetMenuItemByNumber(int mealNumber)
        {
            foreach (KomodoMenu item in _menuList)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
        //Update
        //Delete
        public bool DeleteItem(KomodoMenu existingMenu)
        {
            bool deleteMenu = _menuList.Remove(existingMenu);
            return deleteMenu;
        }
        public bool DeleteItemByNumber(int mealNumber)
        {
            foreach (var item in _menuList)
            {
                if (item.MealNumber == mealNumber)
                {
                    _menuList.Remove(item);
                    return true;
                }

            }
            return false;
        }
    }
}
