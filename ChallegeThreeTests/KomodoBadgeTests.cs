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
        private KomodoBadge badge1;
        private KomodoBadge badge2;
        private KomodoBadge badge3;
        [TestInitialize]
        public void init()
        {
            _repo = new KomodoBadgeRepo();
            _badge = new KomodoBadge();
            _repo.CreatNewBadge(_badge);
            badge1 = new KomodoBadge(new List<string> { "A1", "A2" });
            badge2 = new KomodoBadge(new List<string> { "A1", "A2", "B1", "B2" });
            badge3 = new KomodoBadge(new List<string> { "A1" });

            _repo.CreatNewBadge(badge1);
            _repo.CreatNewBadge(badge2);
            _repo.CreatNewBadge(badge3);
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
            Dictionary<int, KomodoBadge> badges = _repo.GetBadges();
            bool badgesHasItems = badges.ContainsKey(_badge.BadgeID);
            Assert.IsTrue(badgesHasItems);
        }
        [TestMethod]
        public void AddDoor_ShouldReturnTrue()
        {
            bool addDoor = _repo.AddDoor(_badge.BadgeID,_badge.Doors.ToString());
            Assert.IsTrue(addDoor);
         
        }
        [TestMethod]
        public void RemoveDoor_ShouldReturnTrue()
        {
            bool removerDoor = _repo.RemoveDoor(_badge.BadgeID,_badge.Doors.ToString());
            Assert.IsTrue(removerDoor);
        }
    }
}
