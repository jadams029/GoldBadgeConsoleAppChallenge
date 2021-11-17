using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{

    public class KomodoBadgeRepo
    {
        private Dictionary<int, KomodoBadge> _KomodoBadgeDB = new Dictionary<int, KomodoBadge>();
        

        int count = 0;
        public bool CreatNewBadge(KomodoBadge badge)
        {
            if (badge == null)
            {
                return false;
            }
            else
            {
                count++;
                badge.BadgeID = count;
                _KomodoBadgeDB.Add(badge.BadgeID, badge);
                return true;
            }
        }
        //read (everything)
        public Dictionary<int, KomodoBadge> GetBadges()
        {
            return _KomodoBadgeDB;
        }
        public KomodoBadge GetBadgeByID(int badgeID)
        {
            foreach (var item in _KomodoBadgeDB)
            {
                if (item.Key == badgeID)
                {
                    return item.Value;
                }
            }
            return null;
        }

        //go into a particular badge and get list of doors that live in that badge 
        //take a string value that represents a door and add it to the list the badge can access
        //return true for this 
        public bool AddDoor(int badgeID, string doorName)
        {
            //Need a Badge 
            KomodoBadge badge = GetBadgeByID(badgeID);//grabs the badge id and if that id is in the system it will grab it otherwise we will get nothing
            if (badge != null)
            {
                badge.Doors.Add(doorName);
                return true;

            }
            else
                return false;

        }
        public bool RemoveDoor(int badgeID, string doorName)
        {
            KomodoBadge badge = GetBadgeByID(badgeID);
            if (badge != null)
            {
                badge.Doors.Remove(doorName);
                return true;
            }
            else
                return false;
        }
   
   
    }
}
