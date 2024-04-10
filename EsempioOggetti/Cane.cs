namespace EsempioOggetti;

internal class Cane
{
    internal string Nome { get; set; }

    internal int eta { get; set; }
    
    internal string razza { get; set; }
    
    internal void abbaia()
    {
        Console.WriteLine("Bau bau");
    }
    
    internal void corre()
    {
        Console.WriteLine("Il cane corre");
    }
}