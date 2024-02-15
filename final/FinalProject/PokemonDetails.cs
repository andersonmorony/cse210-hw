using System.Text.Json;

namespace FinalProject
{
    public class PokemonDetails : Pokemon
    {
        private List<Stats> _stats;

        public PokemonDetails(string name, string url, List<Stats> stats, int id): base(name, url, id)
        {
            _stats = stats;
            base.SetHp(stats.FirstOrDefault(x => x.stat.name.ToUpper() == "HP").base_stat);
        }

        public override PokemonJson GeneratePokeJson()
        {
            return new PokemonJson()
            {
                Name = base.GetName(),
                Url = base.GetURL()
            };
        }
        public override void DisplayPokemonInformation()
        {
            Console.WriteLine($"Name: {base.GetName()}");
            foreach ( Stats stat in _stats )
            {
                if( stat.stat.name.ToUpper() == "HP" )
                {
                    Console.WriteLine($"{stat.stat.name}: {base._hp}/{stat.base_stat}");
                }
                else
                {
                    Console.WriteLine($"{stat.stat.name}: {stat.base_stat}");
                }
            }
            Console.WriteLine($"Effort: {base._effort.GetEffortUsed()}/{base._effort.GetEffort()}");
        }

        public override int GetAttack()
        {
            return _stats.FirstOrDefault(x => x.stat.name == "attack").base_stat;
        }

        public override int GetDefense()
        {
            return _stats.FirstOrDefault(x => x.stat.name == "defense").base_stat;
        }

    }
}
