using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class KomodoClaim
    {
        public KomodoClaim()
        {

        }
        public KomodoClaim(int claimID, ClaimType claimType, string claimDescription, double claimAmount, DateTime dateOfIncitent, DateTime dateOfClaim )
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncitent;
            DateOfClaim = dateOfClaim;
            //IsValid = isValid;
        }
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).Days < 30)
                    return true;
                else
                    return false;
            }
            set
            {

            }
        }

    }
}
