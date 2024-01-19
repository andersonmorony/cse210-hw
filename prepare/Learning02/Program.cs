using System;

class Program
{
    static void Main(string[] args)
    {
        var quarto = new Quarto();
        quarto._porta = new Porta { nome = "Porta Branca" };

        var janelaDaFrente = new Janela();
        janelaDaFrente.Altura = 1;
        janelaDaFrente.Largura = 2;

        var janeladeTras = new Janela();


        quarto._janelas.Add(janelaDaFrente);
        quarto._janelas.Add(janeladeTras);

        Console.WriteLine(quarto._porta.nome);

        quarto.mostrar();
    }

}

class Quarto
{
    public List<Janela> _janelas = new List<Janela>(); 
    public string _cama = "";
    public string _paredes = "";
    public Porta _porta = new Porta();

    public void mostrar()
    {
        foreach (var item in _janelas)
        {
            Console.WriteLine(item.Largura);
        }
    }
}

class Janela
{
    public double Altura = 2.55;
    public double Largura = 1.79;
}

class Porta
{
    public string nome = "";
}