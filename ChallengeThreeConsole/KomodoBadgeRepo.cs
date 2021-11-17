using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    
    class KomodoBadgeRepo
    {
        private readonly Dictionary<int, string> BadgeID = new Dictionary<int, string>
        {
            {12345, $"{DoorList.A1}" }
        };
        protected readonly List<KomodoBadge> _KBadge = new List<KomodoBadge>();

        public bool CreatNewBadge(KomodoBadge badge)
        {
            int startCount = _KBadge.Count;
            _KBadge.Add(badge);
            bool wasAdded = (_KBadge.Count > startCount) ? true : false;
            return wasAdded;
        }

        public List<KomodoBadge> GetBadges()
        {
            return _KBadge;
        }
        public KomodoBadge GetBadgeByID(int badgeID)
        {
            foreach (KomodoBadge item in _KBadge)
            {
                if (item.BadgeID == badgeID)
                {
                    return item;
                }
            }
            return null;
        }
        public bool UpdateBadgeByID(int badgeID,KomodoBadge komodoBadge)
        {
            KomodoBadge oldBadge = GetBadgeByID(badgeID);
            if (oldBadge != null)
            {
                oldBadge.BadgeID = komodoBadge.BadgeID;
                oldBadge.DoorList = komodoBadge.DoorList;
                return true;
            }
            else
                return false;
        }

    }
}
