namespace esercizio1;

public class Program
{
    public static void Main(string[] args)
    {
        decimal costoProdotto;
        decimal importoPagato;
        decimal resto;

        Console.Write("Inserisci il costo del prodotto acquistato: ");
        if (!decimal.TryParse(Console.ReadLine(), out costoProdotto) || costoProdotto < 0)
        {
            Console.WriteLine("\nIl costo del prodotto inserito non è valido.");
            return;
        }

        Console.Write("Inserisci l'importo pagato dal cliente: ");
        if (!decimal.TryParse(Console.ReadLine(), out importoPagato) || importoPagato < 0)
        {
            Console.WriteLine("\nL'importo pagato inserito non è valido.");
            return;
        }

        if (importoPagato < costoProdotto)
        {
            Console.WriteLine("L'importo pagato è inferiore al costo del prodotto.");
            return;
        }

        resto = importoPagato - costoProdotto;

        Console.WriteLine($"Il resto da dare al cliente è: {resto}");
    }
}