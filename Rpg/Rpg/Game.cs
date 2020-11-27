using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rpg
{
    class Game
    {
        private Player hero;
        private List<Monster> Monstres;
        private Boolean IsGameOver;
        private string ArenaName;
        private int CurrentLevel;

        public Game()
        {
           
            GameOpening();
            Console.WriteLine("Entrez le nom que vous voulez donner à votre Hero");
            string HeroesName = Console.ReadLine();
            hero = new Player(Player.Role.Warrior, HeroesName);
            CurrentLevel = 0;

            Monstres = new List<Monster>();

            Monstres.Add(new Monster(Monster.MonsterKind.Gobelin, "Bobby"));
            Monstres.Add(new Monster(Monster.MonsterKind.Slime, "Kingnobless"));
            Monstres.Add(new Monster(Monster.MonsterKind.Gobelin, "Roi"));



            Combat();

        }


        private void Combat()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            while (p.Hp> 0 && m.Hp>0)
            {
                Console.WriteLine("Choisissez quelle action doit faire " +hero.Name+ "  : 1:Atk 2:Inventaire 3:Fuir");
                int choix = choixMenu(3);
                switch(choix)//le joueur a le choix entre attaquer, 
                {
                    case 1:
                        Attaque();
                        break;
                    case 2:
                        OpenInventory();
                        break;
                    case 3:
                        Quit();
                        break;
                }
            }

            if (p.Hp>0)
            {
                Console.WriteLine("Bravo");
                hero.Inventory.Add(m.Loot);
            }
            else
            {
                Quit();
            }
        }

        /// <summary>
        /// Le combat final contre le roi si le hero a pu finir les autres ennemi
        /// </summary>
        private void CombatFinally()
        {
            Player p = hero;
            Monster m = Monstres[2];

            while (p.Hp > 0 && m.Hp > 0)
            {
                Console.WriteLine("Choisissez quelle action doit faire " + hero + "  face au Roi  : 1:Atk 2:Inventaire 3:Fuir");
                int choix = choixMenu(3);
                switch (choix)//le joueur a le choix entre attaquer, ouvrir son inventaire et fuir
                {
                    case 1:
                        Attaque();
                        break;
                    case 2:
                        OpenInventory();
                        break;
                    case 3:
                        Quit();
                        Console.WriteLine("Tu as la frouille et tu as decidé de fuir looser hihiihi");
                        break;
                }
            }

            if (p.Hp > 0)
            {
                Console.WriteLine("Bravo");
                hero.Inventory.Add(m.Loot);
            }
            else
            {
                Quit();
            }
        }

        private void OpenInventory()
        {
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                Console.WriteLine((i+1) +":"+hero.Inventory[i].Name);
            }
            Console.WriteLine((hero.Inventory.Count +1) + ":" + "Return to Battle");

            int choix = choixMenu(hero.Inventory.Count+1);

            if ((hero.Inventory.Count + 1) == choix)
                return;

            hero.Inventory[choix - 1].Use(hero);

            if (hero.Inventory[choix - 1].NumberOfUse <= 0)
                hero.Inventory.RemoveAt(choix - 1);
        }

        private void Attaque()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            m.Hp -= Math.Clamp(p.Atk - m.Def,0,100);
            p.Hp -= Math.Clamp(m.Atk - p.Def,0,100);

            Console.WriteLine(p.Name + " a encore " + p.Hp + " Hp");
            Console.WriteLine(m.Name + " a encore " + m.Hp + " Hp");
        }
        /// <summary>
        /// fonction choixMenu qui donne un nombre qui va servir de reponse pour choix et le max de choix possible dans la fonction dans laquelle elle est utiliséée
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int choixMenu(int max)
        {
            Boolean choixValide = false;
            int choix = 0;
            while (choixValide != true)
            {
                choix = int.Parse(Console.ReadLine());
                if ((int)choix > 0 && (int)choix <= max)
                {
                    choixValide = true;
                }
                else
                {
                    Console.WriteLine(choix + " Entrée incorrecte. Veuillez réessayer.");
                }
            }
            return (int)choix;
        }
        /// <summary>
        /// Cette fonction est comme une introduction à notre Jeu RPG
        /// </summary>
    
        public void GameOpening()
        {

            Console.WriteLine("Bienvenue dans le RPG" );
            Console.WriteLine("Il s'agit d'un jeu simple d'un joueur qui combat des monstres, s'il meurt, le jeu est fini sinon il continu jusqu'à la victoire finale");
            Console.WriteLine("Voulez vous charger une partie ? o/n");
            string chargePartie = Console.ReadLine();
            chargePartie = chargePartie.ToLowerInvariant();// la reponse utilisateur est convertie en miniscule caractere
            if (chargePartie == "o")//Si l'utilisateur dit oui "o" alors on utilise sa sauve garde
            {
                Console.WriteLine("nous recherchons votre partie de chargement");
                Load();
            } 
            else if (chargePartie == "no")//Si l'utilisateur dit non "n" alors on utilise pas sa sauvegarde et on rentre dans la premiere fonction pour le combat
            {
                Console.WriteLine("Voilà votre Hero qui apparait il se trouve directement face à un monstre ");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas entré de reponse adequate");
                
            }
          
            
            
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public void save()
        {
            //Pour les sauvegardes 
            //On peut utiliser un fichier, ce fichier sera lu et dans ce fichier, on donnera la position du joueur 
            // aussi on prendra en compte ces données et les ennemis qui sont morts et si possible la phrase de jeu là où il s'est arreté
        }

        public void Load()
        {
            //On demmande d'abord si l'utilisateur veut charger une partie => Voir openingGame
            //Si oui alors on lit dans le dossier/fichier de sauvegarde
           
            //Si pas de fichier de sauvegarde alors on ramene sur la foncion principale du jeu et on fait une nouvelle partie

        }

        public void Lecture(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\bodje\Desktop\saveFile.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        //--------------------
                        string info = line;
                        int found = 0;

                        Console.WriteLine("Les données recuperées sont ");
                        foreach (string s in info)
                            Console.WriteLine(s);

                        Console.WriteLine("\nNous voulons récupérer uniquement les informations clés : ");
                        foreach (string s in info)
                        {
                            found = s.IndexOf(": ");
                            Console.WriteLine("   {0}", s.Substring(found + 2));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le fichier n'a pas pu être lu.");
                Console.WriteLine(e.Message);
            }
        }
    }

        public void Ecriture()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//Environnement Permet de recuperer des raccourcis vers des endroit(ici desktop) de nos machine

            string[] lines = { "First line", "Second line", "Third line" };
        }
    
}
