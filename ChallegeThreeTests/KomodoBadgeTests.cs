using ChallengeThreeConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallegeThreeTests
{
    [TestClass]
    public class KomodoBadgeTests
    {
        private KomodoBadgeRepo _repo;
        private KomodoBadge _badge;
        [TestInitialize]
        public void init()
        {
            _repo = new KomodoBadgeRepo();
            _badge = new KomodoBadge();

        }

        [TestMethod]
        public void AddBadge_ShouldAddBadge()
        {
            bool addresult = _repo.CreatNewBadge(_badge);
            Assert.IsTrue(addresult);
        }
        [TestMethod]
        public void GetBadgesAll_ShouldReturnAllBadges()
        {
            List<KomodoBadge> badges = _repo.GetBadges();
            bool badgesHasItems = badges.Contains(_badge);
            Assert.IsTrue(badgesHasItems);
        }
        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {

            bool updateResult = _repo.UpdateBadgeByID(12345);
            Assert.IsTrue(updateResult);
        }
    }
}
