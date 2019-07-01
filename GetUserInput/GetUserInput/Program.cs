using System;
using System.Threading;
namespace GetUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Using C# classes to implement, ask the user for information about themselves:
                First Name
                Last Name
                Favorite Number
                Number of Pets
                Names of All Pets
                Any other information you want to ask about
            */
            Console.WriteLine("Hello!");
            Console.WriteLine("What is your first name?");
            string FirstName = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            string LastName = Console.ReadLine();
            int FavoriteNumber = GetIntegerFromUser("What is your favorite number?", false);
            int AmountOfPets = GetIntegerFromUser("How many pets do you have?", true);
            string[] ArrayOfPetNames = new string[AmountOfPets];
            string[] ArrayOfPetTypes = new string[AmountOfPets];
            for (int i = 0; i < AmountOfPets; i++)
            {
                string PetType = PreventOtherOptions("What type of pet do you have?", "dog", "cat", "bird", "other");
                if (PetType == "other")
                {
                    Console.WriteLine("What is the pet's type then?");
                    PetType = Console.ReadLine();
                }
                ArrayOfPetTypes[i] = PetType;
                Console.WriteLine("What is the " + PetType + "'s name");
                string PetName = Console.ReadLine();
                ArrayOfPetNames[i] = PetName;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------");
            Console.WriteLine("Final Results:");
            Console.WriteLine("--------------");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine("Greetings " + FirstName  + " " + LastName + "!");
            Thread.Sleep(2000);
            if (AmountOfPets > 0)
            {
                Console.WriteLine("You have " + AmountOfPets + " pets");
                if (FavoriteNumber == AmountOfPets)
                {
                    Console.WriteLine("That is the same as your favorite number!");
                }
                for (int i = 0; i < AmountOfPets; i++)
                {
                    Console.WriteLine("You have a " + ArrayOfPetTypes[i] + " named " + ArrayOfPetNames[i]);
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("You have no pets");
            }
            Thread.Sleep(1000);
            Console.WriteLine("Your favorite number is " + FavoriteNumber);



        }
        
        static string PreventOtherOptions(string Question, string Option1, string Option2, string Option3, string Option4)
        {
            string UserChoice = "";
            while (UserChoice != Option1 && UserChoice != Option2 && UserChoice != Option3 && UserChoice != Option4)
            {
                Console.WriteLine(Question + ":\n" + Option1 + "\n" + Option2 + "\n" + Option3 + "\n" + Option4);
                UserChoice = Console.ReadLine().ToLower();
            }
            return UserChoice;
        }

        static int GetIntegerFromUser(string question, bool ChecksPositive)
        {
            int integerFromUser;
            bool success;
            
            do
            {
                Console.WriteLine(question);
                string userResponse = Console.ReadLine();
                success = int.TryParse(userResponse, out integerFromUser);
                if (integerFromUser < 0 && ChecksPositive == true)
                {
                    success = false;
                }
            } while (success == false && ChecksPositive == true);
            
            return integerFromUser;
        }
    }
}
