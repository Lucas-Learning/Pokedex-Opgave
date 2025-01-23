using Microsoft.SqlServer.Server;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Pokedex_Opgave
{
    internal class LoginCheck
    {
        private string fileName = @"C:\Users\gisse\Desktop\LoginPokedex.txt";
        public int attempts = 3;
        Pokemon poke = new Pokemon();
        public void Login(string username, string password) 
        {
            using (StreamWriter TextWriter = new StreamWriter(fileName))
            {
                TextWriter.WriteLine($"Lucas,1234");
            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                bool login = false;
                while ((line = reader.ReadLine()) != null && !login)
                {
                    
                    string[] credentials = line.Split(',');
                    if (credentials.Length == 2 && credentials[0] == username && credentials[1] == password)
                    {
                        Console.WriteLine("Du er nu logget ind");
                        login = true;

                        poke.LoggedInMenu();
                    }
                }

                if (!login)
                {
                    Console.WriteLine("Du har skrevet det forkert");
                    attempts--;
                    Console.WriteLine($"Du har {attempts} forsøg tilbage");
                    Console.ReadKey();
                }
            }
           
        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
