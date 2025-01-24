using System;
using System.IO;
using System.Text;

namespace Pokedex_Opgave
{
    internal class LoginCheck
    {
        private string fileName = @"C:\Users\xekrs\Source\Repos\Pokedex-Opgave\LoginPokedex.txt";
        public int attempts = 3;
        Pokemon poke = new Pokemon();

        private string EncryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        private string DecryptPassword(string encryptedPassword)
        {
            byte[] passwordBytes = Convert.FromBase64String(encryptedPassword);
            return Encoding.UTF8.GetString(passwordBytes);
        }

        public void Login(string username, string password)
        {
            using (StreamWriter textWriter = new StreamWriter(fileName))
            {
                string encryptedPassword = EncryptPassword("1234");
                textWriter.WriteLine($"Lucas,{encryptedPassword}");
            }

            // Read file and check login credentials
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                bool login = false;

                while ((line = reader.ReadLine()) != null && !login)
                {
                    string[] credentials = line.Split(',');
                    if (credentials.Length == 2)
                    {
                        string storedUsername = credentials[0];
                        string storedEncryptedPassword = credentials[1];
                        string decryptedPassword = DecryptPassword(storedEncryptedPassword);

                        if (storedUsername == username && decryptedPassword == password)
                        {
                            Console.WriteLine("Du er nu logget ind");
                            login = true;
                            poke.LoggedInMenu();
                        }
                    }
                }

                if (!login)
                {
                    Console.WriteLine("Du har skrevet det forkert");
                    attempts--;
                    Console.WriteLine($"Du har {attempts} forsøg tilbage");
                    Console.ReadKey();
                    if(attempts == 0)
                    {
                        Environment.Exit(0 );
                    }   
                }
            }
        }
        }
    }