using ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneTests
{
    [TestClass]
    public class KomodoRepoTests
    {
        private KomodoMenuRepo _repo;
        private KomodoMenu _menu;
        [TestInitialize]
        public void init()
        {
            _repo = new KomodoMenuRepo();
            _menu = new KomodoMenu();
            _repo.AddItemToMenu(_menu);
        }

        [TestMethod]
        public void AddMenuItem_ShouldAddItemToList()
        {
            //Arrange
            KomodoMenu menu = new KomodoMenu();
            KomodoMenuRepo repo = new KomodoMenuRepo();
            //Act
            bool addResult = repo.AddItemToMenu(menu);
            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenu_ShouldReturnMenu()
        {
            //Arrange
            KomodoMenu menu = new KomodoMenu();
            KomodoMenuRepo repo = new KomodoMenuRepo();
            repo.AddItemToMenu(menu);
            //Act
            List<KomodoMenu> menus = repo.GetMenuItems();
            bool menuHasItems = menus.Contains(menu);
            //Assert
            Assert.IsTrue(menuHasItems);
        }


        [TestMethod]
        public void DeleteMenuItemByNumber_ShouldReturnTrue()
        {

            
            bool removeItem = _repo.DeleteItemByNumber(_menu.MealNumber);
            Assert.IsTrue(removeItem);
        }
    }
}
