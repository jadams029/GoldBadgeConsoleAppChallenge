using ChallengeTwoConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTests
{
    [TestClass]
    public class KomodoClaimTests
    {
        private KomodoClaimRepo _repo;
        private KomodoClaim _claim;
        [TestInitialize]
        public void init()
        {
            _repo = new KomodoClaimRepo();
            _claim = new KomodoClaim();
            _repo.CreateNewClaim(_claim);
        }
        [TestMethod]
        public void AddClaim_ShouldAddItemToList()
        {
            bool addResult = _repo.CreateNewClaim(_claim);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaimsAll_ShouldReturnAllClaims()
        {
            Queue<KomodoClaim> claims = _repo.GetAllClaims();
            bool claimsHasItems = claims.Contains(_claim);
            Assert.IsTrue(claimsHasItems);
        }
        [TestMethod]
        public void GetClaimByID_ShouldReturnCorrectClaim()
        {
            KomodoClaim foundClaim = _repo.GetClaim();
            Assert.AreEqual(_claim, foundClaim);
        }
        [TestMethod]
        public void DeleteClaimByNumber_ShouldReturnTrue()
        {
            bool removeClaim = _repo.DeleteClaim();
            Assert.IsTrue(removeClaim);
        }
    }
}
