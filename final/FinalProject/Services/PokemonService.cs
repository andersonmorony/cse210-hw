using System.Text.Json;

namespace FinalProject.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async public Task<PokemonDetailsAPIResponse> GetPokemonDetails(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PokemonDetailsAPIResponse>(content);
        }

        async public Task<List<Details>> GetPokemonsAsync()
        {
            var URI = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";
            var response = await _httpClient.GetAsync(URI);
            var content = await response.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<PokemonApiResponse>(content);
            return pokemons.results;
        }
        async public Task<(string url, PokemonDetailsAPIResponse PokemonDetailsAPIResponse)> RandomPokemon()
        {
            var pokemons = await GetPokemonsAsync();

            Random random = new Random();
            int randomPokeIndex = random.Next(pokemons.Count());
            var pokemonChoosed = pokemons[randomPokeIndex];

            var pokemonDatails = await GetPokemonDetails(pokemonChoosed.url);
            return (pokemonChoosed.url, pokemonDatails);
        }

    }
}
