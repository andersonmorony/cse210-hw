
using System.Text.Json.Serialization;

namespace FinalProject
{
    public class Stats
    {
        [JsonInclude]
        public int base_stat {  get; private set; }
        [JsonInclude]
        public Details stat { get; private set; }
    }
}
