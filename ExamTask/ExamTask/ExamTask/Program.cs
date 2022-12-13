using System;

namespace ExamTask
{
    internal class Program
    {
        static Weapon weapon = new Weapon();
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            bool Exit = true;
            do
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n0 - Info");
                Console.WriteLine("1 - Shoot");
                Console.WriteLine("2 - Fire");
                Console.WriteLine("3 - Get Remain Bullet Count");
                Console.WriteLine("4 - Reload");
                Console.WriteLine("5 - Change Fire Mode");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("7 - Edit");
                Console.Write("\n Write here:\t");
                Console.ForegroundColor = ConsoleColor.Cyan;
                bool Booling = Int32.TryParse(Console.ReadLine(), out int num);
                Console.ResetColor();

                if (Booling == true)
                {
                    switch (num)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(weapon);
                            Console.ResetColor();
                            break;
                        case 1:
                            weapon.Shoot();
                            break;
                        case 2:
                            weapon.Fire();
                            break;
                        case 3:
                            Console.WriteLine(weapon.GetRemainBulletCount());
                            break;
                        case 4:
                            weapon.Reload();
                            break;
                        case 5:
                            weapon.ChangeFireMode();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nClosing the program...");
                            Console.ResetColor();
                            Exit = false;
                            break;
                        case 7:
                            Edit();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nWrong num");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong key");
                    Console.ResetColor();
                }
            } while (Exit==true);
        }

        static void Edit()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n8 - Change Magazine Max Size");
            Console.WriteLine("9 - Change size of bullets in magazine");
            Console.Write("\n Write here:\t");
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool Booling = Int32.TryParse(Console.ReadLine(), out int num);
            Console.ResetColor();
            if (Booling == true)
            {
                switch (num)
                {
                    case 8:
                        ChangeMagazinMaxSize();
                        break;
                    case 9:
                        ChangeMagazineSize();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong num");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong key");
                Console.ResetColor();
                Edit();
            }

        }

        static void ChangeMagazineSize()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nHow many bullets you want to pull out:\t");
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool Booling = Int32.TryParse(Console.ReadLine(), out int num);
            Console.ResetColor();
            if (Booling==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong key");
                Console.ResetColor();
                ChangeMagazineSize();
            }
            if (num<weapon.MagazineCapacity&&num>0)
            {
                for (int i = weapon.MagazineCapacity; i > num; i--)
                {
                    weapon.BulletCount++;
                    weapon.MagazineCapacity--;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou pulled out bullets");
                Console.ResetColor();
            }
            else if(num > weapon.MagazineCapacity && num > 0 && num <=weapon.MagazineMaxCapacity)
            {
                for (int i = weapon.MagazineCapacity; i < num; i++)
                {
                    weapon.BulletCount--;
                    weapon.MagazineCapacity++;
                }
            }
            else if (num > weapon.MagazineMaxCapacity)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nyou can't add more than the magazine max capacity \nMax capacity: {weapon.MagazineMaxCapacity}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Number of bullets");
                Console.ResetColor();
                ChangeMagazineSize();
            }
        }

        static void ChangeMagazinMaxSize()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nSelect magazine size:\t");           
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool Booling = Int32.TryParse(Console.ReadLine(), out int num);
            Console.ResetColor();
            if (Booling==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong key");
                Console.ResetColor();
                ChangeMagazinMaxSize();
            }
            if (num>0)
            {
                weapon.BulletCount += weapon.MagazineCapacity;
                weapon.MagazineCapacity = 0;
                weapon.MagazineMaxCapacity = num;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong num");
                Console.ResetColor();
                ChangeMagazinMaxSize();
            }
        }
    }
}