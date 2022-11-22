using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Inheritance:
    public class Vampire : Monster
    {
        //Unique Props:
        public bool IsShiny { get; set; }
        public DateTime HourChangeBack { get; set; }

        //Constructor with one unique prop:
        public Vampire(string name, string description, int life, int maxLife, int hitChance, int block, 
            int minDamage, int maxDamage, bool isShiny) 
            : base(name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        {
            HourChangeBack = DateTime.Now;//Default value for unique prop.
            IsShiny = isShiny;

            //EXAMPLE: Using a unique property to affect the assignment of the inherited properties:
            //At night, our vampire becomes significantly more dangerous.
            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MaxDamage += 5;
                MinDamage += 5;
            }
        }

        //Empty Constructor
        public Vampire()//takes in no parameters! 
        {
            //But we still assign all the properties.
            Name = "Edward";
            Description = "The love of my life";
            MaxLife = 70;
            Life = 60;
            HitChance = 90;
            Block = 0;
            MinDamage = 20;
            MaxDamage = 30;
            IsShiny = true;

            //Make sure to assign the default:
            HourChangeBack = DateTime.Now;//Calculated at the time of constructing the object.
            //And test to see if we should apply the buff:
            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MaxDamage += 5;
                MinDamage += 5;
            }
            //This will save us time when constructing our objects.
        }

        //EXAMPLE: Overriding the ToString() using unique props
        public override string ToString()
        {
            //Create a string to store the results of our calculation.
            string strengthString = "";

            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 )//If the hour is less than (6am) or greater
                                                                //than 18  (6pm)...                  
            {
                //Store a string indicating the increase in stats on Lines 26-32.
                strengthString = "The ominous glow of the moon strengthens this creature.";
            }
            else
            {
                //Otherwise, store a string indicating that bonus is not applied.
                strengthString = "The bright rays of the sun are weakening this creature.";
            }

            //Create a string to store the results of our calculation.
            string shinyString = "";

            if (IsShiny)//If the vampire is Shiny...
            {
                //Add some flavor text.
                shinyString = "\nThis vampire sparkles in the light. How mesmerising and beautiful!";
            }

            //If the vampire is not shiny, it's defaulting to an empty string.

            //Concatenate our flavor text to the base ToString().
            return base.ToString() + $"\n{strengthString}" + $"{shinyString}";
        }
    }
}
