using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Weapons
    {     
       
            public string Name { get; set; }

            public int MinDamage { get; set; }

            public int MaxDamage { get; set; }

            public int BonusHitChance { get; set; }

            public bool IsTwoHanded { get; set; }

            

            public Weapons(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
            {
                Name = name;
                MinDamage = minDamage;
                MaxDamage = maxDamage;
                BonusHitChance = bonusHitChance;
                IsTwoHanded = isTwoHanded;
                
            }

        }
    }
}
}
