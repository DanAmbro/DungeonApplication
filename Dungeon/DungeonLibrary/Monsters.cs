using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monsters : Character   
    {
        //FIELDS
        private int _minDamage;

        //PROPS
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage 
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }
        }//end MinDamage prop

        //CTORS
        public Monsters(string name, string description, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage) : base(name, hitChance, block, life, maxLife)
        {
            MaxDamage = maxDamage;           
            Description = description;         
            MinDamage = minDamage;
        }//end FQCTOR

        public Monsters() { }//end default ctor

        //METHODS
        public override string ToString()
        {
            return string.Format ("\n--== MONSTERS ==--\n" +
                "{0}\n" +
                "Life: {1} of {2}\n" +
                "Block: -{3} damage reduction\n" +
                "Hit Chance: {4}\n" +
                "Damage: {5} to {6}\n" +
                "{7}\n",
                Name,
                Life,
                MaxLife,
                Block,
                HitChance,
                MinDamage, 
                MaxDamage,
                Description);
        }//end override ToString()

        public override int CalcDamage()
        {
            Random random = new Random();
            return random.Next(MinDamage, MaxDamage + 1);
        }//end override CalcDamage()
    }//end class
}//end namespace
