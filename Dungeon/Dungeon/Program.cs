﻿namespace Dungeon
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


        private static string GetRoom()
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
         
        }


    }//end class
}//end namespace