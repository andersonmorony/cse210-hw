namespace FinalProject
{
    public abstract class Pokemon
    {
        private int _id;
        private string _name;
        private string _url;
        protected int _hp;
        protected Effort _effort = new Effort();


        public Pokemon(string name, string url, int id)
        {
            _id = id;
            _name = name;
            _url = url;
        }
        public Effort GetEffort()
        {
            return _effort;
        }
        public string GetName()
        {
            return _name;
        }
        public int GetHp()
        {
            return _hp;
        }
        public string GetURL()
        {
            return _url;
        }
        public void SetHp(int hp)
        {
            _hp = hp;
        }
        public virtual void DisplayPokemonInformation()
        {
            Console.WriteLine($"Pokemon name: {_name}");
        }
        public abstract int GetAttack();
        public abstract int GetDefense();
        public abstract PokemonJson GeneratePokeJson();

    }
}
