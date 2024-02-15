using FinalProject.Services;

namespace FinalProject
{
    public class Battle
    {
        private Pokemon _pokemonEnemy;
        private Pokemon _pokemonChoosed;
        private List<Pokemon> _pokemonUserList;
        private readonly PokemonService _pokemonService;
        private readonly Animation _animation = new Animation();
        public Battle(List<Pokemon> pokemonUserList, PokemonService pokemonService)
        {
            _pokemonUserList = pokemonUserList;
            _pokemonService = pokemonService;
        }
        async private Task SetPokemonEnemy()
        {
            // Return a Random pokemon from API
            var (url, pokemonEnemy) = await _pokemonService.RandomPokemon();
            _pokemonEnemy = new PokemonDetails(pokemonEnemy.name, url, pokemonEnemy.stats, pokemonEnemy.id);
        }
        public List<Pokemon> Start()
        {
            // Start the battle
            Step1().Wait(); // Choose in user poke list the pokemon to battle
            Step2(); // Choose whether will attack or not
            Step3(); // Catch pokemon

            return _pokemonUserList;
        }
        async public Task Step1()
        {
            // Choose random the Enemy to battle
            await SetPokemonEnemy();
            Console.WriteLine($"You Enemy will be {_pokemonEnemy.GetName()}");
            _pokemonEnemy.DisplayPokemonInformation();

            // Choose a pokemon of user enable pokemon
            ChoosePokemon();
            Console.WriteLine("You poke is: ");
            _pokemonChoosed.DisplayPokemonInformation();
        }
        public void Step2()
        {
            Console.WriteLine("Choose one action:");
            Console.WriteLine("1 - Start Battle");
            Console.WriteLine("2 - Choose other Enemy");
            Console.WriteLine("0 - Get out");
            string chooseMenu = Console.ReadLine();

            switch (chooseMenu)
            {
                case "1":
                    Fight();
                    break;
                case "2":
                    break;
            }
        }
        public void Step3()
        {
            if( _pokemonEnemy.GetHp() <= 0 )
            {
                CatchPokemon();
            }
        }
        public void Fight()
        {
            bool isContinue = true;
            Console.WriteLine("The battle begins with both Pokémon on opposite sides of the battlefield, ready to engage in combat\n");
            while (isContinue)
            {
                Console.WriteLine($"Pokémon {_pokemonChoosed.GetName()} makes the move, choosing an attack from its repertoire...");
                isContinue = AttackAndUpdateState(_pokemonChoosed, _pokemonEnemy);
                _animation.ShowAnimation(3);

                if (!isContinue)
                {
                    ShowWinnerMessage(_pokemonChoosed);
                    break;
                }
                Console.WriteLine($"Pokémon {_pokemonEnemy.GetName()} reacts to the incoming attack from Pokémon {_pokemonChoosed.GetName()}. It may choose to counter with its own attack, use a defensive move to mitigate damage, or employ a status move to hinder Pokémon {_pokemonChoosed.GetName()}'s abilities.");
                _animation.ShowAnimation(3);
                isContinue = AttackAndUpdateState(_pokemonEnemy, _pokemonChoosed);

                if (!isContinue)
                {
                    ShowWinnerMessage(_pokemonEnemy);
                    break;
                }
            }


        }
        public void CatchPokemon()
        {
            Console.WriteLine($"Would you try catch the {_pokemonEnemy.GetName()} for you collection? [Y] or [N]");
            var choose = Console.ReadLine();
            switch (choose.ToUpper())
            {
                case "Y":
                    // use will have 3 attempt
                    Console.WriteLine("Hold your breath, Trainer! The Poké Ball trembles with anticipation as it attempts to secure the wild Pokémon within its confines. Every twitch, every click, brings you one step closer to adding another Pokémon to your team. Stay focused, stay hopeful, and soon you'll see if your efforts have paid off!");
                    for (int i = 0; i < 3; i++)
                    {
                        _animation.ShowAnimation(5);
                        if(CatchProbability())
                        {
                            Console.WriteLine("--------   Congratulations You Catch!  --------");
                            _pokemonUserList.Add(_pokemonEnemy);
                            break;
                        }
                        Console.WriteLine($"Don't was this time, but you have more {3 - i} try");
                        _animation.ShowAnimation(2);
                    }
                    break;
            }
        }
        public bool CatchProbability()
        {
            // return a number with the posibility of 30% of catch the enemy poke.
            Random random = new Random();
            int prob = random.Next(100);
            return prob < 30;

        }
        public bool AttackAndUpdateState(Pokemon pokeInAttack, Pokemon pokeInDefense)
        {
            Random rand = new Random();
            var randomDefense = rand.Next(pokeInDefense.GetDefense());
            var randomAttack = rand.Next(pokeInAttack.GetAttack());

            int demage = randomDefense - randomAttack;
            if (demage < 0)
            {
                pokeInDefense.SetHp(pokeInDefense.GetHp() + demage);
            }

            pokeInAttack.GetEffort().SetEffort();

            var hit = demage > 0 ? "miss" : (demage * -1).ToString();

            Console.WriteLine("\nStatus.....");
            Console.Write($"The {pokeInAttack.GetName()} hit {hit} of {pokeInDefense.GetName()} ");
            Console.WriteLine($"and {pokeInDefense.GetName()} HP is {pokeInDefense.GetHp()}\n");

            // If return false is because the pokemon dead and the loop should to finish
            return pokeInDefense.GetHp() >= 0;
        }
        public void ShowWinnerMessage(Pokemon winner)
        {
            Console.WriteLine($"The {winner.GetName()} winner the battle");
        }
        public void ChoosePokemon()
        {
            // Choose the pokemon to battle against the enemy
            try
            {
                int index = 1;
                Console.WriteLine("Choose you pokemon to battle:");
                foreach (var poke in _pokemonUserList)
                {
                    Console.Write($"\n{index} - {poke.GetName()}");
                    if(poke.GetHp() <= 0) { Console.Write("[unavailable, need of care]"); }
                    index++;
                }
                
                int choose = int.Parse(Console.ReadLine());
                _pokemonChoosed = _pokemonUserList[choose - 1];

            }
            catch (Exception ex)
            {
                Console.WriteLine("Pokemon didn't found.");
            }
        }
    }
}
