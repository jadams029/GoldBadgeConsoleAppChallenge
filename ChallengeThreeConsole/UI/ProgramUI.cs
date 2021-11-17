using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole.UI
{

    public class ProgramUI
    {
        private readonly KomodoBadgeRepo _repo = new KomodoBadgeRepo();

        public void Run()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin, What would you like to do?\n" +
                    "1.) Add a Badge\n" +
                    "2.) Edit a Badge\n" +
                    "3.) List All Badges\n" +
                    "4.) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        AnyKey();
                        break;
                }
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            KomodoBadge badge = new KomodoBadge();
            bool hasListedAllDoors = false;
            while (hasListedAllDoors == false)
            {
                //Console.WriteLine($"Badge number: {badge.BadgeID}");
                Console.WriteLine("Do you want to access to a door? y/n");
                string userInput = Console.ReadLine();
                if (userInput == "Y".ToLower())
                {
                    Console.WriteLine("List a door to give Access too");
                    userInput = Console.ReadLine();
                    badge.Doors.Add(userInput);
                    continue;

                }
                else
                    hasListedAllDoors = true;
                
                bool success = _repo.CreatNewBadge(badge);
                if (success)
                {
                    Console.WriteLine("Door added");
                }
                else
                    Console.WriteLine("Door not added");
            }



            AnyKey();
        }

        private void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<int, KomodoBadge> menuList = _repo.GetBadges();
            foreach (var item in menuList)
            {
                DisplayBadgeInfo(item.Value);
            }
            AnyKey();
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("Please Enter an Existing Badge");
            int userInput = int.Parse(Console.ReadLine());
            KomodoBadge badge = _repo.GetBadgeByID(userInput);
            if (userInput != badge.BadgeID)
            {
                Console.WriteLine("Enter a valid ID");
            }
            else
                

            Console.WriteLine("What would you like to do?\n" +
                "1.) Remove a Door.\n" +
                "2.) Add a Door.\n" +
                "3.) Main Menu");

            string userInput2 = Console.ReadLine();
            switch (userInput2)
            {
                case "1":
                    RemoveADoor(badge);
                    break;
                case "2":
                    AddADoor(badge);
                    break;
                case "3":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("something got jacked");
                    AnyKey();
                    break;
            }



            AnyKey();

        }

        private void AddADoor(KomodoBadge badge)
        {
            Console.Clear();
            Console.WriteLine("Please input the door you want to add.");
            string userInput = Console.ReadLine();
            bool success = _repo.AddDoor(badge.BadgeID, userInput);

            if (success)
            {
                Console.WriteLine("Badge updated.");
            }
            else
                Console.WriteLine("Badge not updated.");
            //AnyKey();
        }

        private void RemoveADoor(KomodoBadge badge)
        {
            Console.Clear();
            Console.WriteLine("Please input the door you want to remove.");
            string userInput = Console.ReadLine();
            bool success = _repo.RemoveDoor(badge.BadgeID, userInput);

            if (success)
            {
                Console.WriteLine("Badge updated.");
            }
            else
                Console.WriteLine("Badge not updated.");

            //AnyKey();
        }

        private void DisplayBadgeInfo(KomodoBadge badge)
        {
            Console.WriteLine(
                $"Badge ID: {badge.BadgeID}"

                );
            foreach (var door in badge.Doors)
            {
                Console.WriteLine($"Door Accessable: {door}");
            }
        }
        private void Seed()
        {
            KomodoBadge badge1 = new KomodoBadge(new List<string> { "A1", "A2" });
            KomodoBadge badge2 = new KomodoBadge(new List<string> { "A1", "A2", "B1", "B2" });
            KomodoBadge badge3 = new KomodoBadge(new List<string> { "A1" });

            _repo.CreatNewBadge(badge1);
            _repo.CreatNewBadge(badge2);
            _repo.CreatNewBadge(badge3);
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to contiue ...");
            Console.ReadKey();
        }
    }
}
