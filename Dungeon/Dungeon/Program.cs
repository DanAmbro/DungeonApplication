using DungeonLibrary;

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
            
            //Prompt the user to input their name: 
            Console.WriteLine("What is your Name");

            //Store the user input in a string.
            string playerName = Console.ReadLine();

            /*BONUS: Customizing the weapons.
             * 
             * 1) Construct custom weapon objects.
             * 2) Prompt user input.
             * 3) Surround customization in a menu of its own.
             * 4) Assign EquippedWeapon property based on user input.
             */

            //1) Construct the weapon objects:
            Weapons sword1 = new Weapons(40, "Broadsword", 5, true, 30, WeaponType.Sword);
            Weapons bow1 = new Weapons(25, "Longbow", 30, true, 20, WeaponType.Bow); 
            Weapons axe1 = new Weapons(60, "War Axe", -15, true, 50, WeaponType.Axe);

            //3a) COUNTER
            bool playerIsChoosingWeapon = true;

            Weapons chosenWeapon;//Weapon object to store user choice.
            
            Player player = new Player(playerName, 70, 5, 100, 100, PlayerRace.Human, sword1);

            do
            {
                //2a) Prompt user input
                Console.WriteLine("\nChoose your weapon:\n" +
                    "(S) Broadsword\n" +
                    "(L) Longbow\n" +
                    "(A) War Axe\n");
                //Input prompt is a key instead of a line.
                //That way the user just has to press the key
                //instead of typing out a line and pressing enter.
                ConsoleKey userKey = Console.ReadKey().Key;
                Console.Clear();//2b)Clear the console after registering input.

                switch (userKey)//Read user input
                {
                    case ConsoleKey.S://Values are the enumerated values of ConsoleKey
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon= sword1;//4a)Assign to sword object.
                        break;

                    case ConsoleKey.L:
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon= bow1;//4b)Assign to bow object.
                        break;

                    case ConsoleKey.A:
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon= axe1;//4c)Assign to axe object.
                        break;

                    default://If they did not press one of the keys we prompted them to, reload loop
                        Console.WriteLine("Input was invalid. Please press (S), (L), or (A).");
                        break;
                }

            } while (playerIsChoosingWeapon);//3b) CONDITION

            /*BONUS: Customizing the players race.
             * 1) Prompt user input
             * 2) Surround in a loop
             * 3) Assign the Race property based on player's choice.              
             */

            Console.Clear();//Clear text from weapon customization

            //2a) COUNTER
            bool playerIsChoosingRace = true;
            do
            {
                //1)Prompt user input
                Console.WriteLine("\nChoose your Race: " +
                    "\n(H) Human" +
                    "\n(D) Dwarf" +
                    "\n(E) Elf");

                //Store key input
                ConsoleKey raceChoice = Console.ReadKey().Key;
                Console.Clear();//Clear the input from the console.

                switch (raceChoice)
                {
                    case ConsoleKey.H:
                        player.Race = PlayerRace.Human;//3) Assign based on player input
                        playerIsChoosingRace = false;//2c) UPDATE
                        break;

                    case ConsoleKey.D:
                        player.Race = PlayerRace.Dwarf;//3) Assign based on player input
                        player.MaxLife = 150;//Custom properties based on race
                        player.Life = 150;//Custom properties based on race
                        playerIsChoosingRace = false;
                        break;

                    case ConsoleKey.E:
                        player.Race = PlayerRace.Elf;//3) Assign based on player input
                        player.MaxLife = 70;//Custom properties based on race
                        player.Life = 70;//Custom properties based on race
                        player.Block = 35;//Custom properties based on race
                        playerIsChoosingRace = false;//2c) UPDATE
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please press (H), (D), or (E).");
                        break;
                }

            } while (playerIsChoosingRace);//2b) CONDITION

            #endregion

            //Track the score:
            int score = 0;
            //We will update this score whenever the player defeats a Monster
            //then display the score to the player when they exit the game.

            #region Gameplay Loop

            bool playerIsAlive = true;//COUNTER for the GAMEPLAY LOOP
            bool playerIsFighting = true;//COUNTER for the COMBAT LOOP

            int lvlUp1 = 0;
            int lvlUp2 = 0; 
            int lvlUp3 = 0;

            do//START OF GAMEPLAY LOOP
            {
                /*BONUS: Level Up and Rewards
                 * 
                 * 1) At the top of the gameplay loop
                 *    (i.e. When combat ends at the start of a new loop
                 *    but still before getting a new room and monster)
                 * 2) Check the value for score
                 * 3) Based on that value, execute level-up or rewards code.
                 */
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (score)
                {
                    //Examples of stat increases
                    case 3:
                        for (int i = 0; lvlUp1 < 1; lvlUp1++)
                        {
                            Console.WriteLine("\nCongratulations, You leveled up!");
                            player.MaxLife += 50;//Increase their maximum life.
                            player.Life = player.MaxLife;//Refill the player's life.
                        }
                        break;
                    case 6:
                        for (int i = 0; lvlUp2 < 1; lvlUp2++)
                        {
                            Console.WriteLine("\nCongratulations, You leveled up again!");
                            player.MaxLife += 50;//Increase their maximum life.
                            player.Life = player.MaxLife;//Refill the player's life.
                        }
                        break;
                    case 10:
                        for (int i = 0; lvlUp3 < 1; lvlUp3++)
                        {
                            Weapons sword2 = new Weapons(80, "The Hero's Sword", 10, false, 60, WeaponType.Sword);
                            Console.WriteLine("\nCongratulations, You leveled up and have earned the Hero's Sword!!");
                            player.EquippedWeapon = sword2;
                            player.MaxLife += 50;//Increase their maximum life.
                            player.Life = player.MaxLife;//Refill the player's life.
                        }
                        break;                    
                };

                Console.ResetColor();

                //Any code at the top of this loop will execute any time
                //the player defeats a monster.

                #region Create Room & Monster

                //Because we are doing the Console.WriteLine() inside
                //the GetRoom() method, we can just call the method here.
                GetRoom();

                //Create Monster objects
                Rabbit r1 = new Rabbit();
                Rabbit r2 = new Rabbit("Buggs", "From the Warner Brothers Region!", 20, 20, 70, 0, 5, 10, true);
                Skunk s1 = new Skunk();
                Skunk s2 = new Skunk("Stinkor", "From Eternia", 25, 25, 65, 0, 5, 15, true);
                Vampire v1 = new Vampire();
                Vampire v2 = new Vampire("The Count", "1! Ah, ah, ah. 2! Ah, ah, ah. 3!", 25, 25, 60, 1, 10, 15, false);
                Turtle t1 = new Turtle();
                Turtle t2 = new Turtle("Franklin", "He can count by twos and tie his shoes", 10, 10, 50 ,10, 5, 10, 50, 80);

                //Add the Monsters to a Collection:
                Monster[] monsters =
                {
                    r1,
                    r2, r2, r2, r2, r2,
                    s1,
                    s2, s2, s2, s2,
                    v1,
                    v2, v2,
                    t1,
                    t2,
                };

                //Pick one at random to place in the room.
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                Console.WriteLine("You encountered {0}!", monster.Name);

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

                                //Make sure to reset the color of the Console afterwards.
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
                            //Print Monster stats. (ToString() method)
                            Console.WriteLine(monster);
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

            Console.WriteLine("\nThanks for playing!");
            Console.WriteLine("\nScore: {0}", score);
        }//end Main


        private static void GetRoom()
        {
            //Requirements:
            /*
             *  1. Create a collection of room descriptions.
             *   2. Randomly print one of those room descriptions to the Console.
             */
            

            string[] roomDescriptions =
            {
                 "Barracks",
                 "Torture Chamber",
                 "Storeroom",
                 "Armoury",
                 "Infirmary",
                 "Dining Hall",
                 "Throne Room",
                 
            };

            Random roompick = new Random();
            int room = roompick.Next(roomDescriptions.Length);           

            string roomDescripts = roomDescriptions[room];
            Console.WriteLine(roomDescripts);

         
        }
    }//end class
}//end namespace