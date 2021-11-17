using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{

    public enum DoorList { A1 = 1, A2, A3, A4, A5, A6, A7, B1, B2 }
    public class KomodoBadge
    {
        public int BadgeID { get; set; }
        public DoorList DoorList { get; set; }
    }
}
