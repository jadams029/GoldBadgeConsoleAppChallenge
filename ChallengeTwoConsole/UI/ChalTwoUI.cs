using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole.UI
{
    public class ChalTwoUI
    {
        private readonly KomodoClaimRepo _ClaimMenu = new KomodoClaimRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Chose a Menu option: \n" +
                    "1.) See all claims \n" +
                    "2.) Take Care of Next Claim \n" +
                    "3.) Enter new Claim \n" +
                    "4.) Exit \n"
                    );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    case "one":
                        ShowAllClaims();
                        break;
                    case "2":
                    case "two":
                        ShowNextClaim();
                        break;
                    case "3":
                    case "three":
                        AddClaim();
                        break;
                    case "4":
                    case "four":
                    case "exit":
                        keepRunning = false;
                        break;
                    default:
                        AnyKey();
                        break;
                }
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<KomodoClaim> claimQue = _ClaimMenu.GetAllClaims();
            foreach (var item in claimQue)
            {
                DisplayClaimStuff(item);
            }
            AnyKey();

        }
        private void ShowNextClaim()
        {
            
            Console.Clear();
           
            KomodoClaim claim = _ClaimMenu.GetClaim();
           
            if (claim != null)
            {
                DisplayClaimStuff(claim);
                Console.WriteLine("Do you want to deal with this claim? Y/N");
                string userInputKey = Console.ReadLine();
                if (userInputKey == "y".ToLower())
                {
                    //remove the first claim in line
                    bool success = _ClaimMenu.ProcessClaim();
                    if (success == true)
                    {
                        Console.WriteLine("Claim was processed.");
                    }
                    else
                    {
                        Console.WriteLine("Claim was not Processed.");
                    }
                }

                else
                {
                    Console.WriteLine("Press any key to contiue.");
                    AnyKey();
                    RunMenu();
                }
            }
            AnyKey();

        }
        private void AddClaim()
        {
            Console.Clear();
            KomodoClaim claim = new KomodoClaim();        
            Console.WriteLine("Enter Claim Type: \n" +
                "1.) Car\n" +
                "2.) Home\n" +
                "3.) Theft");
            string claimInput = Console.ReadLine();
            int claimID = int.Parse(claimInput);
            claim.ClaimType = (ClaimType)claimID;
            Console.WriteLine("Enter Claim Description: ");
            claim.ClaimDescription = Console.ReadLine();
            Console.WriteLine("Enter Claim Amount: ");
            claim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Incident\n" +
                "Year, Month, Day");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Claim\n" +
                "Year, Month, Day");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            if (_ClaimMenu.CreateNewClaim(claim))
            {
                Console.WriteLine("Claim was Added");
            }
            else
            {
                Console.WriteLine("Claim not added.");
                AnyKey();
            }

        }
        private void DisplayClaimStuff(KomodoClaim claim)
        {
            Console.WriteLine(
                $"Claim ID: {claim.ClaimID}\n"+
                $"Claim Type: {claim.ClaimType}\n" +
                $"Claim Description: {claim.ClaimDescription}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Claim Valid?:{claim.IsValid}"
                );
            Console.WriteLine();
        }
        private void SeedContent()
        {

            KomodoClaim claimOne = new KomodoClaim(1, ClaimType.Car, "Car Accident on 465.", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            KomodoClaim claimTwo = new KomodoClaim(2, ClaimType.Home, "House Fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            KomodoClaim claimThree = new KomodoClaim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2010, 04, 27), new DateTime(2018, 06, 01));

            _ClaimMenu.CreateNewClaim(claimOne);
            _ClaimMenu.CreateNewClaim(claimTwo);
            _ClaimMenu.CreateNewClaim(claimThree);

        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
