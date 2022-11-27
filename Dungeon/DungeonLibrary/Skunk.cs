using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Change the access modifier from internal to public.
    //Inherit from Monster by adding ": Monster"
    public class Skunk : Monster
    {
        //Add any unique properties for this Monster.
        public bool IsSmelly { get; set; }

        //Make sure to add that unique property to the inherited properties in the parameters.
        public Skunk(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, bool isSmelly)
            : base(name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        //use the base constructor to assign the inherited properties.
        {
            IsSmelly = isSmelly;//Assign the unique property.
        }

        //EXAMPLE: An empty constructor for default values:
        public Skunk()//Take in no parameters. 
        {
            Name = "Peppy LePew";
            Description = "A lover, not a fighter!";
            MaxLife = 100;
            Life = 100;
            HitChance = 100;
            Block = 0;
            MinDamage = 5;
            MaxDamage = 5;
            IsSmelly = false;
        }//default Skunk

        public override string ToString()//EXAMPLE: Override the ToString() using the unique property
        {
            return base.ToString() + (IsSmelly ? "\nIt's so fluffy, I'm going to die"
                : "\nNot so fluffy...");
        }

        public override int CalcBlock()
        {
            //return base.CalcBlock();
            int calculatedBlock = Block;
            if (IsSmelly)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}