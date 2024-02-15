using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalProject
{
    public  class PokemonDetailsAPIResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Stats> stats { get; set; }
    }
}
