using System;

namespace Cavern_Crawler___Text_Based_Roguelike
{

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            //Declare player stats
            int pgold = 0;
            int plevel = 1;
            int phpmax = 15;
            int php = phpmax;
            int pdamage = 0;
            int pdamagebonus = 0;
            int pdice = 4;
            int pdicecount = 1;
            int presistance = 0;
            int penergymax = 2;
            int penergy = penergymax;
            int pitemcount = 0;

            int pinput = 0;
            int PSexecute = 0;

            //Declare enemy stats
            string ename;
            int ehpmax;
            int ehp = 1;
            int edice;
            int edamage;
            

            //Start screen
            Console.SetCursorPosition(50,13);
            Console.Write("Cavern Crawler");
            Console.SetCursorPosition(45, 14);
            Console.Write("Press any key to continue...");
            Console.ReadKey();

            //Declare enemy and give enemy hp
            Enemy enemy01 = new Enemy();
            enemy01.Epick();
            ehpmax = enemy01.Ehpmax;
            ehp = ehpmax;

            //Pick spell
            Spell spell = new Spell();
            spell.PSpick();

            //While player is alive, play combat
            while (php > 0 && ehp > 0)
            {
                //Check if player input is valid
                while (pinput >= 5 | pinput <= 0)
                {
                    pinput = 0;
                    GUI(php, phpmax, penergy, penergymax, plevel);

                    //Show enemy
                    Console.SetCursorPosition(3, 5);
                    Console.WriteLine("A " + enemy01.Ename + " approaches [" + ehp + "/" + ehpmax + "]");

                    //Show player options
                    Console.SetCursorPosition(0, 24);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("[1] Attack [" + pdicecount + "d" + pdice + "]");
                    Console.WriteLine("[2] Charge");
                    Console.WriteLine("[3] Spell");
                    Console.WriteLine("[4] Item");

                    //Set player cursor
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                    try
                    {
                        pinput = Convert.ToInt32(Console.ReadLine());
                        if (pinput >= 5 | pinput <= 0)
                        {
                            Console.Write("Try again");
                            Console.ReadKey();
                        }

                    }
                    catch (Exception x)
                    {
                        Console.Write("Try again");
                        Console.ReadKey();
                    }
                }

                //Execute player input
                switch (pinput)
                {
                    //Attack
                    case 1:
                        while (pdicecount > 0)
                        {
                            pdamage = pdamage + rnd.Next(1, pdice + 1);
                            pdicecount--;
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("You deal: " + pdamage);
                        }
                        ehp -= pdamage;
                        pdicecount = 1;
                        pdamage = 0;
                        Console.ReadKey();
                        break;
                    //Charge
                    case 2:
                        pdicecount = pdicecount + 2;
                        Console.SetCursorPosition(3, 7);
                        Console.WriteLine("You charge your next attack");
                        Console.ReadKey();
                        break;
                    //Spell
                    case 3:

                            GUI(php, phpmax, penergy, penergymax, plevel);

                            //Show enemy
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("A " + enemy01.Ename + " approaches [" + ehp + "/" + ehpmax + "]");

                            //Show player options
                            Console.SetCursorPosition(0, 24);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("[1] Cast " + spell.Sname);
                            Console.WriteLine("[2] Back");

                            //Set player cursor
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        PSexecute = 0;
                        (ehp, pdamagebonus, php, pdicecount, presistance, PSexecute) = spell.PSExecute(ehp, pdamagebonus, php, pdicecount, presistance, PSexecute);
                        if (PSexecute == 0)
                        {
                            break;
                        }

                        if(php > phpmax)
                        {
                            php = phpmax;
                        }
                            break;
                    //Item
                    case 4:
                        GUI(php, phpmax, penergy, penergymax, plevel);

                        //Show enemy
                        Console.SetCursorPosition(3, 5);
                        Console.WriteLine("A " + enemy01.Ename + " approaches [" + ehp + "/" + ehpmax + "]");

                        //Show player options
                        Console.SetCursorPosition(0, 24);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("[1] Cast " + spell.Sname);
                        Console.WriteLine("[2] Back");

                        //Set player cursor
                        Console.SetCursorPosition(0, 22);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


                        break;
                }

                //Check if enemy is dead
                if (ehp < 1)
                {
                    break;
                }
                pinput = 0;

                //If player chose not to use a spell, restart combat by skipping enemy attack
                if (PSexecute != 0)
                {
                    //Play enemy attack
                    enemy01.Eattack();
                    if (presistance != 0)
                    {
                        if (enemy01.Edamage > 8)
                        {
                            php = php - enemy01.Edamage + presistance;
                            Console.SetCursorPosition(3, 8);
                            Console.WriteLine("You take: " + enemy01.Edamage + " and block " + presistance);
                            Console.ReadKey();
                            presistance = 0;
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 8);
                            Console.WriteLine("You take: " + enemy01.Edamage + " and block " + presistance);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        php -= enemy01.Edamage;
                        Console.SetCursorPosition(3, 8);
                        Console.WriteLine("You take: " + enemy01.Edamage);
                        Console.ReadKey();
                    }
                }

                PSexecute = 1;
            }

            Console.Clear();
            Console.WriteLine("yay");
        }

        static void GUI(int pHp, int pHpmax, int pEnergy, int pEnergymax, int pLevel)
        {
                //Show player stats and draw gui
                Console.Clear();
                Console.SetCursorPosition(5, 1);
                Console.Write("HP: " + pHp + "/" + pHpmax);
                Console.SetCursorPosition(50, 1);
                Console.Write("Energy: " + pEnergy + "/" + pEnergymax);
                Console.SetCursorPosition(105, 1);
                Console.WriteLine("Level: " + pLevel);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        }
    }
}
