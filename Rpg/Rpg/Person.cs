using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    abstract class Person
    {
        public string Name;
        public int Hp;
        public int Atk;
        public int Def;

        public Person(string name)
        {
            Name = name;
        }

        public virtual void damage(int amount)
        {
            Hp -= amount;
            if (Hp <= 0)
                Console.WriteLine("Oulag");
        }


    }
}
