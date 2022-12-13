using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask;

namespace ExamTask
{
    public class Weapon : IWeaphon
    {
       
        
        public int BulletCount { get; set; }
        public  int MagazineCapacity { get; set; }
        public int MagazineMaxCapacity { get; set; }
        public FireMode Mode { get; set; }

        public Weapon()
        {
            BulletCount = 120;
            MagazineCapacity= 30;
            MagazineMaxCapacity = 30;
            Mode = FireMode.semi;
        }


        public void ChangeFireMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n1 - Semi\n2 - Auto\nSelect Fire Mode: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool Booling =Int32.TryParse(Console.ReadLine(), out int num);
            Console.ResetColor();
            if (Booling==true)
            {
                switch (num)
                {
                    case 1:
                        Mode = FireMode.semi;
                        break;
                    case 2:
                        Mode = FireMode.auto;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong key");
                        Console.ResetColor();
                        ChangeFireMode();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong key");
                Console.ResetColor();
                ChangeFireMode();
            }
        }


        public void Shoot()
        {
            if (Mode==FireMode.semi)
            {
                if (MagazineCapacity > 0)
                {
                    MagazineCapacity--;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nShot");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMagazine is empty!");
                    Console.ResetColor();
                }
            }
            else
            {
                Fire();
            }
        }

        public void Fire()
        {
            if (Mode==FireMode.auto)
            {
                if (MagazineCapacity > 0)
                {
                    MagazineCapacity = 0;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nShots Shots Shots... \nyou fired all the ammo");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMagazine is empty!");
                    Console.ResetColor();
                }
            }
            else
            {
                Shoot();
            }
        }

        public int GetRemainBulletCount()
        {
            if (MagazineCapacity==0)
            {
                return MagazineMaxCapacity;
            }
            else
            {
                return MagazineMaxCapacity-MagazineCapacity;
            }
        }

        public void Reload()
        {
            if (BulletCount>0)
            {
                for (int i = 0; i < BulletCount&&BulletCount!=0; i++)
                {
                    if (MagazineCapacity<MagazineMaxCapacity)
                    {
                        BulletCount--;
                        MagazineCapacity++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nMagazine is full");
                        Console.ResetColor();
                        break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou ran out of ammo");
                Console.ResetColor();
            }
        }


        public override string ToString()
        {
            return $"\nBulletCount: {BulletCount}  MagazineMaxCapacity: {MagazineMaxCapacity}  MagazineCapacity: {MagazineCapacity} FireMode: {Mode}";
        }

    }
}
