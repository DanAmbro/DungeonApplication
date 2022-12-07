using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Inheritance:
    public class Mynock : Monster
    {
        //Unique Props:
        public bool IsSurging { get; set; }
        public DateTime HourChangeBack { get; set; }

        //Constructor with one unique prop:
        public Mynock(string name, string description, int life, int maxLife, int hitChance, int block, 
            int minDamage, int maxDamage, bool isSurging) 
            : base(name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        {
            HourChangeBack = DateTime.Now;//Default value for unique prop.
            IsSurging = isSurging;

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
        public Mynock()//takes in no parameters! 
        {
            //But we still assign all the properties.
            Name = "Surging Mynock";
            Description = "A Mynock full of energy from the ship!";
            MaxLife = 70;
            Life = 70;
            HitChance = 70;
            Block = 0;
            MinDamage = 20;
            MaxDamage = 30;
            IsSurging = true;

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
                strengthString = "The ominous glow of power strengthens this creature.";
            }
            else
            {
                //Otherwise, store a string indicating that bonus is not applied.
                strengthString = "The surge of power has worn off this creature.";
            }

            //Create a string to store the results of our calculation.
            string surgingString = "";

            if (IsSurging)//If the vampire is Shiny...
            {
                //Add some flavor text.
                surgingString = "\nThis mynock is surging with power!";
            }

            //If the mynock is not surging, it's defaulting to an empty string.

            //Concatenate our flavor text to the base ToString().
            return base.ToString() + $"\n{strengthString}" + $"{surgingString}";
        }
    }
}
