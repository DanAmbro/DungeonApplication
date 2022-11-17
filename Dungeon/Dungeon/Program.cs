namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, there and wlecome to our world!");
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

            bool playerIsAlive = true;//COUNTER for the GAMEPLAY LOOP
            bool playerIsFighting = true;//COUNTER for the COMBAT LOOP

            do//START OF GAMEPLAY LOOP
            {


                #region Create Room & Monster

                //TODO: Print a random room description.
                //TODO: Create an instance of a Monster class at random.

                #endregion

                #region Menu Loop

                do
                {
                    Console.WriteLine("\nChoose your action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) View Player Stats\n" +
                        "M) View Monster Stats\n" +
                        "Q) Quit\n");

                    string fightingChoice = Console.ReadLine();

                    Console.Clear();

                    switch (fightingChoice.ToUpper())
                    {
                        case "A":
                            Combat.DoBattle(player, monster);

                            //Check Monster Health
                            if (monster.Life <= 0)
                            {
                                //Use green text to highlight winning combat:

                                //Select a text color by setting the ForegroundColor property
                                //to an enum value ConsoleColor.
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("\nYou killed {0}", monster.Name);

                                //Make sre to reset the color of the Console afterwards.
                                Console.ResetColor();

                                //Increment the score by one.
                                score++;

                                //End this COMBAT LOOP
                                playerIsFighting = false;

                            }
                            break;
                        case "R":
                            Console.WriteLine("Running Away!");

                            //Give the monster an 'attack of opportunity' when the player attempts to run away:
                            Console.WriteLine($"{monster.Name} attacks you as you attempt to flee!");
                            Combat.DoAttack(monster, player);

                            playerIsFighting = false;
                            break;
                        case "P":
                            //Because we have an override of the ToString() method on our Player class,
                            //that information can be printed to the console simply by passing the 
                            //Player object into the Console.WriteLine();
                            Console.WriteLine(player);
                            break;
                        case "M":
                            //TODO: Print Monster stats. (ToString() method)
                            break;
                        case "Q":
                            playerIsFighting = false;
                            playerIsAlive = false;
                            break;
                        default:
                            Console.WriteLine("Input invalid. Please type a letter from the Menu below and press Enter.");
                            break;
                    }
                    #region Check PLayer Life

                    if (player.Life <= 0)
                    {
                        playerIsFighting = false;
                        playerIsAlive = false;
                    }

                    //if (score > 15)
                    //{
                    //    Console.WriteLine("You Win!");
                    //    playerIsFighting = false;
                    //    playerIsAlive = false;
                    //}                

                    #endregion

                } while (playerIsFighting && playerIsAlive);

                //Re-execute the COMBAT LOOP while the player is still fighting.

                #endregion
            } while (playerIsAlive);
            //Re-execute the COMBAT LOOP while the player is still alive.
            //This will get a new Room and Monster then re-enter the COMBAT LOOP.


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