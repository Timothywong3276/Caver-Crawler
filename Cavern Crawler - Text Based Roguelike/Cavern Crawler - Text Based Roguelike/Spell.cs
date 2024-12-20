using System;
using System.Collections.Generic;
using System.Text;

namespace Cavern_Crawler___Text_Based_Roguelike
{
    class Spell
    {
        Random rnd = new Random();

        //Declare spell stats
        public string Sname;
        int Pspell;
        public int Pspellshield = 0;
        public int Pspelldmg = 0;
        public int Pspelldmgbonus = 0;
        public int Pspellheal = 0;
        public int Pspelldicecount = 0;
        int pinput = 0;

        //Pick spell
        public void PSpick()
        {
            Pspell = rnd.Next(1, 6);
            switch (Pspell)
            {
                case 1:
                    Sname = "Smite [Deal 6 damage]";
                    break;
                case 2:
                    Sname = "Focus [Next attack will do 2 bonus damage per dice]";
                    break;
                case 3:
                    Sname = "Pray [Heal 10 hp]";
                    break;
                case 4:
                    Sname = "Meditate [Increase dice count by 2]";
                    break;
                case 5:
                    Sname = "Harden [Gain a temporary shield that blocks 8 dmg]";
                    break;
            }
        }

        public (int, int, int, int, int, int) PSExecute(int _ehp, int _pdamagebonus, int _php, int _pdicecount, int _presistance, int _PSexecute)
        {
            pinput = 0;
            while (pinput > 3 | pinput <= 0)
            {
                try
                {
                    pinput = Convert.ToInt32(Console.ReadLine());
                    if (pinput > 3 | pinput < 0)
                    {
                        Console.WriteLine("Try again");
                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine("Try again");
                }
            }

            if (pinput == 1)
            {
                switch (Pspell)
                {
                    case 1:
                        //Smite
                        Pspelldmg = 6;
                        _ehp -= Pspelldmg;
                        break;
                    case 2:
                        //Focus
                        Pspelldmgbonus = Pspelldmgbonus + 2;
                        _pdamagebonus += Pspelldmgbonus;
                        break;
                    case 3:
                        //Pray
                        Pspellheal = 10;
                        _php += Pspellheal;
                        break;
                    case 4:
                        //Meditate
                        Pspelldicecount = Pspelldicecount + 2;
                        _pdicecount += Pspelldicecount;
                        break;
                    case 5:
                        //Harden
                        Pspellshield = Pspellshield + 8;
                        _presistance += Pspellshield;
                        break;

                }
                _PSexecute = 1;
            }

            else if (pinput == 2)
            {
                _PSexecute = 0;
            }
            return (_ehp, _pdamagebonus, _php, _pdicecount, _presistance, _PSexecute);
        }
    }
}
