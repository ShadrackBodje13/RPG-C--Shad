using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Item
    {
        public enum PotionEffect { Heal, Atk, Def}
        public PotionEffect Effect;

        public int PotionPower;
        public int NumberOfUse;

        public string Description;

        public string Name;

        public Item(PotionEffect effect,string name, int power, int uses)
        {
            Name = name;
            PotionPower = power;
            NumberOfUse = uses;
            Effect = effect;
            Description = "C'est une potion";
        }

        public void Use(Player p)
        {
            switch (Effect)
            {
                case PotionEffect.Heal:
                    p.Hp += PotionPower;
                    break;
                case PotionEffect.Atk:
                    p.Atk += PotionPower;
                    break;
                case PotionEffect.Def:
                    p.Def += PotionPower;
                    break;
                default:
                    break;
            }
            NumberOfUse--;
        }
    }
}
