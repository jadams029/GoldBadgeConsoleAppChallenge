using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole.UI
{
    public class ChalTwoUI
    {
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
                        break;
                    case "2":
                    case "two":
                        break;
                    case "3":
                    case "three":
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
        private void SeedContent()
        {


            KomodoClaim claimOne = new KomodoClaim(1, ClaimType.Car, "Car Accident on 465.", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
