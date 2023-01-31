using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2,
    }
    internal class Creature
    {
        CreatureType _creatureType;

        protected int hp = 0;
        protected int attack = 0;
        public Creature(CreatureType creatureType)
        {
            _creatureType = creatureType;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }

        public bool IsDead()
        {
            return hp <= 0;
        }
        public void OnDamage(int attack)
        {
            hp -= attack;
            if (hp <= 0) hp = 0;
        }
    }
}
