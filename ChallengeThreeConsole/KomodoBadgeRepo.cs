using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    
    public class KomodoBadgeRepo
    {
        private readonly Dictionary<int, string> _KomodoBadgeDB = new Dictionary<int, string> ();
       
        

        public bool CreatNewBadge(KomodoBadge badge)
        {
      
        }

        public Dictionary<int, string> GetBadges()
        {
            return _KomodoBadgeDB;
        }
        //public KomodoBadge GetBadgeByID(int badgeID)
        //{
        //    foreach (KomodoBadge item in _KBadge)
        //    {
        //        if (item.BadgeID == badgeID)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}
        //public bool UpdateBadgeByID(int badgeID)
        //{
        //    KomodoBadge oldBadge = GetBadgeByID(badgeID);
        //    if (oldBadge != null)
        //    {
        //        oldBadge.BadgeID = komodoBadge.BadgeID;
        //        oldBadge.DoorList = komodoBadge.DoorList;
        //        return true;
        //    }
        //    else
        //        return false;
        //}

    }
}
