using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Monster : Person
    {
        public enum MonsterKind { Gobelin, Slime}
        public Item Loot;
        public Monster(MonsterKind type, string name) : base(name)
        {
            switch (type)
            {
                case MonsterKind.Gobelin:
                    Hp = 100;
                    Atk = 1;
                    Def = 1;
                    Loot = new Item(Item.PotionEffect.Heal,"Heal",20,2);
                    break;
                case MonsterKind.Slime:
                    Hp = 2;
                    Atk = 3;
                    Def = 2;
                    Loot = new Item(Item.PotionEffect.Atk,"BOMBE",20,1);
                    break;
            }
        }

        public Monster() : base("")
        {

        }


        public override void damage(int amount) 
        {
            base.damage(amount);
            if (Hp < 0)
                Console.WriteLine(Loot.Name);
        }

    }
}
