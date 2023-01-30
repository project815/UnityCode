using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    enum MonsterType
    {
        None = 0,
        Simle = 1,
        Orc = 2,
        Skeleton = 3,
    }
    internal class Monster : Creature
    {
        MonsterType _monsterType = MonsterType.None;

        public Monster(MonsterType monsterType) : base(CreatureType.Monster)
        {
            _monsterType = monsterType;
        }
        public MonsterType GetMonsterType() { return _monsterType; }
  
    }
    class Simle : Monster
    {
        public Simle() : base(MonsterType.Simle) {
            SetInfo(10, 1);
        }
    }
    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc) {
            SetInfo(20, 5);
        }

    }
    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton) {
            SetInfo(30, 15);
        }

    }
}
