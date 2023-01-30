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
    internal class Player : Creature
    {
        protected PlayerType _type;


        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            _type = type;
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
