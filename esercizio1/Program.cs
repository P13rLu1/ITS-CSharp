namespace esercizio1;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            decimal costoProdotto = 0;
            decimal importoPagato = 0;
            decimal resto;

            var inputValido = false;

            // Ciclo per chiedere all'utente di inserire il costo del prodotto finché l'input non è valido
            while (!inputValido)
            {
                Console.Write("Inserisci il costo del prodotto acquistato: ");
                if (!decimal.TryParse(Console.ReadLine(), out costoProdotto) || costoProdotto < 0)
                    Console.WriteLine("\nIl costo del prodotto inserito non è valido. Riprova.");
                else
                    inputValido = true;
            }

            inputValido = false;

            // Ciclo per chiedere all'utente di inserire l'importo pagato finché l'input non è valido
            while (!inputValido)
            {
                Console.Write("Inserisci l'importo pagato dal cliente: ");
                if (!decimal.TryParse(Console.ReadLine(), out importoPagato) || importoPagato < 0)
                    Console.WriteLine("\nL'importo pagato inserito non è valido. Riprova.");
                else if (importoPagato < costoProdotto)
                    Console.WriteLine("\nL'importo pagato è inferiore al costo del prodotto. Riprova.");
                else
                    inputValido = true;
            }

            resto = importoPagato - costoProdotto;

            Console.WriteLine($"Il resto da dare al cliente è: {resto}\n");

            Console.Write("Vuoi fare un altro calcolo? (s/n): ");
            var risposta = Console.ReadLine();

            if (risposta?.ToLower() != "s")
                break;
        }
    }
}