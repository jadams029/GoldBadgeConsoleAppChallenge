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
            _claimList.Enqueue(claim);
            bool wasAdded = (_claimList.Count > startCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Queue<KomodoClaim> GetAllClaims()
        {
            return _claimList;
        }

        public KomodoClaim GetClaim()
        {
            var nextClaim = _claimList.Peek();
            return nextClaim;
        }
        //Upate
        
        //Delete
        public bool DeleteClaim()
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
