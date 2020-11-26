using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Player : Person //La class player depend de la classe Person 
    {
        public enum Role { Warrior, Mage}

        public Role r;

        public List<Item> Inventory;

        public Player(Role role, string name) : base(name) //Son constructeur de type string et ce name là provient de la Class PErson
        {
            r = role;
            Inventory = new List<Item>();
            Inventory.Add(new Item(Item.PotionEffect.Heal, "heal", 5, 2));
            Inventory.Add(new Item(Item.PotionEffect.Atk, "Atk", 5, 2));

            switch (role)
            {
                case Role.Warrior:
                    Hp = 150;
                    Atk = 15;
                    Def = 25;
                    break;
                case Role.Mage:
                    Hp = 5;
                    Atk = 25;
                    Def = 5;
                    break;

            }

          
        }
    }
}
