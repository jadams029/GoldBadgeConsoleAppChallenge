using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{

    
    public class KomodoBadge
    {
        public KomodoBadge()
        {

        }
        public KomodoBadge(  List<string> doors)
        {            
            Doors = doors;
        }
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();
    }
}
