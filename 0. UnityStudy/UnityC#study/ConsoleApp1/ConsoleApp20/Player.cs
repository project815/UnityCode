using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Mage = 2,
        Archer = 3,
    }
    internal class Player
    {
        protected PlayerType _type;
        protected int hp = 0 ;
        protected int attack = 0;

        protected Player (PlayerType type)
        {
            _type = type;
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
            if (hp < 0) hp = 0;
        }
    }
    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 20);
        }
    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage) 
        {
            SetInfo(100, 12);
        }
    }
    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer) 
        {
            SetInfo(200, 10);
        }
    }
}
