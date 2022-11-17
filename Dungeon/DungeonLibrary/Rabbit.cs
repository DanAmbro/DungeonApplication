using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monsters
    {
        //Add any unique properties for this Monster.
        public bool IsFluffy { get; set; }

        public Rabbit(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, bool isFluffy)
            : base (name, description, hitChance, block, life, maxLife, minDamage, maxDamage)
        //use the base constructor to assign the inherited 
        {
            IsFluffy = isFluffy;
        }
        public override string ToString()
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
