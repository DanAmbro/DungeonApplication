using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Character
    {
        private int _life;

        public string Name { get; set; }

        public int HitChance { get; set; }

        public int BLock { get; set; }

        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value < MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }

            }
        }

        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            BLock = block;
            MaxLife = maxLife;
            Life = life;
        }

    }
}
