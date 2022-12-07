using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Change the access modifier from internal to public.
    //Inherit from Monster by adding ": Monster"
    public class StoneMite : Monster
    {
        //Add any unique properties for this Monster.
        public bool IsShiny { get; set; }

        //Make sure to add that unique property to the inherited properties in the parameters.
        public StoneMite(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, bool isShiny)
            : base(name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        //use the base constructor to assign the inherited properties.
        {
            IsShiny = isShiny;//Assign the unique property.
        }

        //EXAMPLE: An empty constructor for default values:
        public StoneMite()//Take in no parameters. 
        {
            Name = "Dark side Stone Mite";
            Description = "Somehow enfused with the dark side of the force";
            MaxLife = 70;
            Life = 70;
            HitChance = 100;
            Block = 0;
            MinDamage = 10;
            MaxDamage = 15;
            IsShiny = false;
        }//default Stone Mite

        public override string ToString()//EXAMPLE: Override the ToString() using the unique property
        {
            return base.ToString() + (IsShiny ? "\nIt's so shiny, I can see the glare"
                : "\nNot so shiny...");
        }

        public override int CalcBlock()
        {
            //return base.CalcBlock();
            int calculatedBlock = Block;
            if (IsShiny)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}