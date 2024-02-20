using FinalProject.Services;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;

namespace FinalProject
{
    internal class GameManager
    {

        private List<Pokemon> _ownPokemons = new List<Pokemon>();
        private readonly PokemonService _pokemonService;
        private readonly Animation _animation;
        public GameManager()
        {
            var _client = new HttpClient();
            _pokemonService = new PokemonService(_client);
            _animation = new Animation();
        }
        public void Start()
        {
            Console.WriteLine("Welcome to Pokemon Game!");
            Console.WriteLine("1 - Start new game");
            Console.WriteLine("2 - Load game");
            var choose = Console.ReadLine();
            Console.Clear();

            if(choose == "1")
            {
                CreateNewPokemon().Wait();
            }
            else if(choose == "2")
            {
                LoadGame().Wait();
            }

            Menu();
        }
        async public Task CreateNewPokemon()
        {
                Console.WriteLine("Wait some seconds while we are choosen a new friend for you...");
                _animation.ShowAnimation(1);
                var (url, pokemonDatails) = await _pokemonService.RandomPokemon();
                _ownPokemons.Add(new PokemonDetails(pokemonDatails.name, url, pokemonDatails.stats, pokemonDatails.id));
                Console.Clear();
                Console.WriteLine("Congrats you cath one pokemon, named '" + _ownPokemons.First().GetName() + "', you new friend!");
                _animation.ShowAnimation(1);
        }
        public void Menu()
        {
            var optionChoosed = string.Empty;
            while (optionChoosed != "0")
            {
                Console.WriteLine("What do you want to do, choose one option in menu?");
                Console.WriteLine("1 - See poke information");
                Console.WriteLine("2 - Go to battle");
                Console.WriteLine("3 - Healing you pokemon");
                Console.WriteLine("4 - Save game");
                Console.WriteLine("0 - Exit");
                optionChoosed = Console.ReadLine();
                
                switch (optionChoosed)
                {
                    case "1":
                        Console.Clear();
                        GetPokemonInformation();
                        break;
                    case "2":
                        StartBattle();
                        break;
                    case "3":
                        HealingPokemon();
                        break;
                    case "4":
                        SaveGame();
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        break;
                }
            }

        }
        async public Task LoadGame()
        {
            try
            {
                Console.Clear();
                Console.Write("Prompt the filename: ");
                var filename = Console.ReadLine();
                var pokemons = LoadJson(filename);

                foreach ( var pokemon in pokemons )
                {
                    var pokemonDatails = await _pokemonService.GetPokemonDetails(pokemon.Url);
                    _ownPokemons.Add(new PokemonDetails(pokemonDatails.name, pokemon.Url, pokemonDatails.stats, pokemonDatails.id));
                }
                Console.WriteLine("Loading...");
                _animation.ShowAnimation(3);
                Console.WriteLine("Completed, You Import all your pokemons!!!");
                _animation.ShowAnimation(3);
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load {ex.Message}");
                Console.WriteLine("Filename don't found");
                Start();
            }
        }
        public List<PokemonJson> LoadJson(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                var pokemons = JsonConvert.DeserializeObject<List<PokemonJson>>(json);
                return pokemons;
            }
        }
        public void SaveGame()
        {

            var pokemon = new List<PokemonJson>();

            foreach (var item in _ownPokemons)
            {
                pokemon.Add(item.GeneratePokeJson());
            }

            var json = System.Text.Json.JsonSerializer.Serialize(pokemon);
            Console.WriteLine(json);
            Console.WriteLine("Important! the extension should be .json");
            string filename = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(json);
            }
        }
        private void StartBattle()
        {
            Console.Clear();
            var battle = new Battle(_ownPokemons, _pokemonService);
            battle.Start();
        }
        private void GetPokemonInformation()
        {
            foreach(var poke in _ownPokemons)
            {
                poke.DisplayPokemonInformation();
                Console.WriteLine("\n -------------------- \n");
            }
        }
        private void HealingPokemon()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Your pokemons:");

                int index = 1;
                foreach (var pokemon in _ownPokemons)
                {
                    Console.WriteLine($"{index} - {pokemon.GetName()}");
                    index++;
                }
                Console.Write("\nChoose one pokemon: ");
                var choose = int.Parse(Console.ReadLine());
                _ownPokemons[choose - 1].HealingPokemon();

                Console.WriteLine("\nWe are taking care of your pokemon, it will take some seconds...");
                _animation.ShowAnimation(3);

                Console.WriteLine("Uhuuu, all was well, you pokemon are well!");
                _animation.ShowAnimation(3);
                Console.Clear();
            }catch (Exception ex)
            {
                Console.WriteLine("We are unvalible now, please ty again in some seconds.");
            }


        }
    }
}
