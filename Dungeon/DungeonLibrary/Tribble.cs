using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Change the access modifier from internal to public.
    //Inherit from Monster by adding ": Monster"
    public class Tribble : Monster
    {
        //Add any unique properties for this Monster.
        public bool IsFluffy { get; set; }

        //Make sure to add that unique property to the inherited properties in the parameters.
        public Tribble(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, bool isFluffy)
            : base (name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        //use the base constructor to assign the inherited properties.
        {
            IsFluffy = isFluffy;//Assign the unique property.
        }

        //EXAMPLE: An empty constructor for default values:
        public Tribble()//Take in no parameters. 
        {
            Name = "Borg Tribble";
            Description = "They were cybernetically enhanced with Borg technology due to assimilation.";
            MaxLife = 50;
            Life = 50;
            HitChance = 100;
            Block = 0;
            MinDamage = 5;
            MaxDamage = 10;
            IsFluffy = false;
        }//default Tribble

        public override string ToString()//EXAMPLE: Override the ToString() using the unique property
        {
            return base.ToString() + (IsFluffy ? "\nIt's so fluffy, I'm going to die"
                : "\nNot so fluffy...");
        }

        public override int CalcBlock()
        {
            //return base.CalcBlock();
            int calculatedBlock = Block;
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}
