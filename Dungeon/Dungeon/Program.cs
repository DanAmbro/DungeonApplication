namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region Introduction
            //Print a welcome.
            #endregion

            #region Create Player
            //TODO: Create an instance of the Player class.
            #endregion

            //Prompt the user to input their name: 
            Console.WriteLine("What is your Name");

            //Store the user input in a string.
            string playerName = Console.ReadLine();

            //Construct the Player's weapon:
            Weapons weapon = new Weapons(70, "sword", 10, true, 35, WeaponType.Sword);

            //Construct the player object:
            //NOTE: Pass in the user input string as the Name for the Player.
            Player player = new Player(playerName, 70, 5, 100, 100, PlayerRace.Human, weapon);

            //Track the score:
            int score = 0;
            //We will update this score whenever the player defeats a Monster
            //then display the score to the player when they exit the game.

            #region Gameplay Loop

            #region Create Room & Monster

            //TODO: Print a random room description.
            //TODO: Create an instance of a Monster class at random.

            #endregion

            #region Menu Loop

            /*
                TODO: Create menu with options:
                1) Attack
                2) Run Away
                3) Character Info
                4) Monster Info
                5) Exit
             */

            #endregion

            #endregion
        }//end Main


        private static void GetRoom()
        {
            //Requirements:
            /*
                1. Create a collection of room descriptions.
                2. Randomly print one of those room descriptions to the Console.
             */
            Console.WriteLine("Get Room Lab");

            Console.WriteLine();

            string[] roomDescriptions =
            {
                 "Barracks",
                 "Storeroom",
                 "Armoury",
                 "Mess Hall",
                 "Throne Room",
                 
            };

            Random roompick = new Random();
            int room = roompick.Next(roomDescriptions.Length);
            Console.WriteLine(room);

            string userInput = roomDescriptions[room];
            Console.WriteLine(userInput);

         
        }


    }//end class
}//end namespace