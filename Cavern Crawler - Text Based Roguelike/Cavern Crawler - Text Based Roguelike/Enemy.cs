using System;
using System.Collections.Generic;
using System.Text;

namespace Cavern_Crawler___Text_Based_Roguelike
{
    class Enemy
    {
        Random rnd = new Random();

        //Declare enemy stats
        public string Ename;
        public int Ehp;
        public int Ehpmax;
        int Edice;
        public int Edamage;
        int Eidentity;

        //Pick enemy
        public void Epick()
        {
            Eidentity = rnd.Next(1, 6);

            switch (Eidentity)
            {
                case 1:
                    Ename = "Goblin";
                    Ehpmax = 10;
                    Ehp = Ehpmax;
                    Edice = 6;
                    break;
                case 2:
                    Ename = "Slime";
                    Ehpmax = 12;
                    Ehp = Ehpmax;
                    Edice = 4;
                    break;
                case 3:
                    Ename = "Skeleton";
                    Ehpmax = 14;
                    Ehp = Ehpmax;
                    Edice = 2;
                    break;
                case 4:
                    Ename = "Bat Swarm";
                    Ehpmax = 6;
                    Ehp = Ehpmax;
                    Edice = 10;
                    break;
                case 5:
                    Ename = "Bandit";
                    Ehpmax = 8;
                    Ehp = Ehpmax;
                    Edice = 8;
                    break;
            }
        }

        //Execute enemy attack
        public void Eattack()
        {
            Edamage = rnd.Next(1, Edice + 1);
        }
    }
}
