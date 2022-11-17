using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character   
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
                if (value <= MaxDamage)//IF the value is less than or equal to the maximum...
                {
                    _minDamage = value;//Set the value as the minimum damage
                }
                else//But if it exceeds the maximum....
                {
                    _minDamage = MaxDamage;//Set the value at the maximum.
                }                
            }
        }

        //CTORS
        public Monster()
        {

        }
        
        public Monster(string name, string description, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;           
            Description = description;         
            MinDamage = minDamage;
        }    

        //METHODS
        public override string ToString()
        {
           return base.ToString() + $"\nDamage: {MinDamage} - {MaxDamage}" +
                $"\nDescription: {Description}";
        }//end override ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(MinDamage, MaxDamage + 1
                );
            return damage;
        }//end override CalcDamage()
    }//end class
}//end namespace
