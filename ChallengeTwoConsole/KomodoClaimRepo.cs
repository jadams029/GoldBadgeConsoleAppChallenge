using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    public class KomodoClaimRepo
    {
        protected readonly Queue<KomodoClaim> _claimList = new Queue<KomodoClaim>();
        //CRUD
        //Create
        public bool CreateNewClaim(KomodoClaim claim)
        {
            int startCount = _claimList.Count;
            _claimList.Add(claim);
            bool wasAdded = (_claimList.Count > startCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<KomodoClaim> GetAllClaims()
        {
            return _claimList;
        }

        public KomodoClaim GetClaimByNumber(int claimID)
        {
            foreach (KomodoClaim item in _claimList)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }                
            }
            return null;
        }
        //Upate
        public bool UpdateClaimByNumber(int originalClaim, KomodoClaim claim)
        {
            KomodoClaim oldClaim = GetClaimByNumber(originalClaim);
            if (oldClaim != null)
            {
                oldClaim.ClaimID = claim.ClaimID;
                oldClaim.ClaimType = claim.ClaimType;
                oldClaim.ClaimDescription = claim.ClaimDescription;
                oldClaim.ClaimAmount = claim.ClaimAmount;
                oldClaim.DateOfIncident = claim.DateOfIncident;
                oldClaim.DateOfClaim = claim.DateOfClaim;
                oldClaim.IsValid = claim.IsValid;
                return true;
            }
            else
                return false;
        }
        //Delete
        public bool DeleteClaimByNumber(int claimID)
        {

            foreach (var item in _claimList)
            {
                if(item.ClaimID == claimID)
                {
                    _claimList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
