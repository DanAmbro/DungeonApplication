using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS
        private int _life;
        //Because we are creating a business rule for life's property
        //we need to declare the field.

        //PROPERTIES
        public string Name { get; set; }

        public int HitChance { get; set; }

        public int Block { get; set; }

        public int MaxLife { get; set; }
        //Because we are using the MaxLife property
        //in the business rule for Life,
        //MaxLife must be assigned BEFORE Life
        public int Life
        {
            get { return _life; }//default getter
            set//custom setter by opening scopes
            {
                if (value <= MaxLife)//Check if the supplied value is less than or equal to the maximum.
                {
                    _life = value;//If so, set that value to Life.
                }
                else if (value > MaxLife)//However, if the value is greater than the maximum...
                {
                    _life = MaxLife;//Set Life to the maximum.
                }

            }
        }

        public Character()
        {

        }

        //CONSTRUCTOR
        public Character(string name, int hitChance, int block, int maxLife, int life)//FQCTOR
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }

        //METHODS
        public override string ToString()
        {
            return string.Format("\n--== " + Name + "==--\n" +
                "Life: " + Life + " / " + MaxLife + "\n" +
                "Hit Chance: " + HitChance + "%\n" +
                "Block: " + Block + "\n");
        }

        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        public virtual int CalcDamage()
        {
            return 0;
        }//end CalcDamage()
    }//end class
}//end namespace
