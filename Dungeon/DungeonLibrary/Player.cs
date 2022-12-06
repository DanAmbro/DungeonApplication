using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character//Inheritance syntax: Child Class : Parent Class
    {
        //FIELDS
        //_life is inherited from Character.

        //PROPS
        //Name, HitCHance, Block, Life, and MaxLife are inherited from from Character.
        //UNIQUE properties of PLayer:

        public PlayerRace Race { get; set; }

        public Weapons EquippedWeapon { get; set; }

        //CONSTRUCTOR
        //We need to take in all the properties as parameters.
        //EVEN the ones that were inherited from Character.
        public Player(string name, int hitChance, int block, int life, int maxLife, PlayerRace race, Weapons equippedWeapon) : base (name, hitChance, block, maxLife, life)
        {
            //We can borrow the assignments for the inherited properties by using the : base syntax above.
            //Name = name;
            //HitChance = hitChance;
            //Block = block;
            //MaxLife = maxlife;
            //Life = life;

            //All we need to do is assign the unique properties:
            Race= race;
            EquippedWeapon= equippedWeapon;
        }

        //METHODS 
        public override string ToString()
        {
            string raceDescription = "";

            switch (Race)
            {
                case PlayerRace.Human:
                    raceDescription = "A normal dude.";
                    break;
                case PlayerRace.Nautolan:
                    raceDescription = "A regal being, that can be strong with the force.";
                    break;
                case PlayerRace.Mustafarian:
                    raceDescription = "A race that can take the heat.";
                    break;
                case PlayerRace.Wookie:
                    raceDescription = "Always bet on the Wookie!";
                    break;
                case PlayerRace.Zabrak:
                    raceDescription = "Can be easily turned to the dark side!";
                    break;
            }

            return base.ToString() + "\nDescription: " + raceDescription + "\nWeapon: " + EquippedWeapon;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(
                EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
