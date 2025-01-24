using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_Opgave
{
    internal class Pokemon
    {
        public int MenuInput;
        private string fileName = @"C:\Users\xekrs\Source\Repos\Pokedex-Opgave\PokemonsDB.txt";
        public List<string> Pokemons = new List<string> { "Id:1,Navn:Charizard,Type:Fire,Styrke:10", "Id:2,Navn:Pikachu,Type:Lightning,Styrke:5", "Id:3,Navn:Bulbasaur,Type:Vand,Styrke:3", "Id:4,Navn:Vaporeon,Type:Vand,Styrke:4" };
        public void LoggedInMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 1. To add pokemons\nPress 2. To delete pokemons\nPress 3. To edit pokemons\nPress 4. To see all your pokemons\nTryk på 5 for at søge efter pokemons\nPress 9. To exit");
                MenuInput = Convert.ToInt32(Console.ReadLine());

                switch (MenuInput)
                {
                    case 1:
                        TilføjPokemon();
                        break;
                    case 2:
                        SletPokemon();
                        break;
                    case 3:
                        RedigerPokemon();
                        break;
                    case 4:
                        SePokemons();
                        break;
                    case 5:
                        SøgPokemon();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void LoggedOutMenu()
        {
            Console.Clear();
            Console.WriteLine("Press 1. To see all the pokemons you have\nPress 9. to quit");
            MenuInput = Convert.ToInt32(Console.ReadLine());

            if (MenuInput == 1)
            {
                SePokemons();
            }
            else if (MenuInput == 9)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine();
            }
        }
        public void TilføjPokemon()
        {
            int ID;
            Console.WriteLine("Du kan tilføje 4 pokemons");
            for (int i = 0; i < Pokemons.Count(); i++)
            {
                Console.WriteLine(Pokemons[i]);
            }
            Console.WriteLine("Skriv ID på det pokemon du vil tilføje");
            ID = Convert.ToInt32(Console.ReadLine());
            switch (ID)
            {
                case 1:
                    ID--;
                    using (StreamWriter TextWriter = new StreamWriter(fileName, true))
                    {
                        TextWriter.WriteLine(Pokemons[ID]);
                    }
                    break;
                case 2:
                    ID--;
                    using (StreamWriter TextWriter = new StreamWriter(fileName, true))
                    {
                        TextWriter.WriteLine(Pokemons[ID]);
                    }
                    break;
                case 3:
                    ID--;
                    using (StreamWriter TextWriter = new StreamWriter(fileName, true))
                    {
                        TextWriter.WriteLine(Pokemons[ID]);
                    }
                    break;
                case 4:
                    ID--;
                    using (StreamWriter TextWriter = new StreamWriter(fileName, true))
                    {
                        TextWriter.WriteLine(Pokemons[ID]);
                    }
                    break;
            }
        }
        public void SletPokemon()
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("Indtast id på pokemon du ville slette");
            string pokemonId = Console.ReadLine();
            var selectedPokemon = Pokemons.FirstOrDefault(p => p.StartsWith("Id:"+pokemonId+","));
            if (selectedPokemon != null)
            {
                var lines = File.ReadAllLines(fileName).ToList();
                lines.Remove(selectedPokemon);
                File.WriteAllLines(fileName, lines);
                Console.WriteLine("Pokemon slettet.");
            }
            else
            {
                Console.WriteLine("Pokemon ikke fundet.");

            }
            Console.ReadKey();
        }
        public void RedigerPokemon()
        {
            Console.WriteLine("Indtast id på pokemon du vil redigere:");
            string pokemonId = Console.ReadLine();

            var lines = File.ReadAllLines(fileName).ToList();
            var selectedPokemonIndex = lines.FindIndex(p => p.StartsWith("Id:" + pokemonId + ","));

            if (selectedPokemonIndex != -1)
            {
                Console.WriteLine("skriv navn");
                string navn = Console.ReadLine();
                Console.WriteLine("skriv type");
                string type = Console.ReadLine();
                Console.WriteLine("skriv styrke");
                string styrke = Console.ReadLine();

                lines[selectedPokemonIndex] = $"Id:{pokemonId},Navn:{navn},type:{type},Styrke:{styrke}";
                File.WriteAllLines(fileName, lines);
                Console.WriteLine("Pokemon redigeret.");
            }
            else
            {
                Console.WriteLine("Pokemon ikke fundet.");
            }
        }
        public void SøgPokemon()
        {
            List<string> pokemons = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                Console.WriteLine("Indtast navn eller type på pokemon du ville se");
                string pokemonNavnellerType = Console.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.ToLower().Contains("navn:" + pokemonNavnellerType) || line.ToLower().Contains("type:" + pokemonNavnellerType))
                    {
                        pokemons.Add(line);
                    }
                }
            }
            if (Pokemons.Any())
            {
              foreach(var pokemon in pokemons)
                {
                    Console.WriteLine(pokemon);
                }
            }
            else
            {
                Console.WriteLine("Pokemon ikke fundet.");
            }
            Console.ReadKey();
        }
        public void SePokemons()
        {
            Console.WriteLine("Pokemons:");
            using (StreamReader TextReader = new StreamReader(fileName))
            {
                string line;
                while ((line = TextReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }
    }
}
