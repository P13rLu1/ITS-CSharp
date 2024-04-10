namespace EsempioOggetti;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        Cane mioCane = new Cane()
        {
            Nome = "Fido",
            eta = 5,
            razza = "Pastore tedesco"
        };
        
        mioCane.abbaia();
        mioCane.corre();
    }
}