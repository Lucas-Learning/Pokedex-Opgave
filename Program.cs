using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_Opgave
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            LoginCheck lc = new LoginCheck();
            Pokemon poke = new Pokemon();
           
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1. to log in\nPress 2. to continue without loggin\nPress 9. to quit");
            int menuInput = Convert.ToInt32(Console.ReadLine());

            switch (menuInput)
            {
                case 1:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password");
                        string password = Console.ReadLine();
                        lc.Login(username, password);
                    }
                    while (lc.attempts > 0);
                    break;

                case 2:
                    poke.LoggedOutMenu();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Du skal tryk på et tal");
                    break;
            }
            Console.ReadKey();
        }
    }
}
