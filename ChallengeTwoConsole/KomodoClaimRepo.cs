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
        private int _count = 0;
        //CRUD
        //Create
        public bool CreateNewClaim(KomodoClaim claim)
        {
            if (claim is null)
            {
                return false;
            }
            else
            {
                _count++;
                claim.ClaimID = _count;
                _claimList.Enqueue(claim);
                return true;
            }
        }
        //Read
        public Queue<KomodoClaim> GetAllClaims()
        {
            return _claimList;
        }

        public KomodoClaim GetClaim()
        {

            if (_claimList.Count > 0)
            {
                var nextClaim = _claimList.Peek();
                return nextClaim;

            }
            return null;
            //this only give us who is next in line...

        }
        //Upate

        //Delete
        public bool ProcessClaim()
        {
            if (_claimList.Count > 0)
            {
                _claimList.Dequeue();
                return true;
            }
            return false;
        }
    }
}
