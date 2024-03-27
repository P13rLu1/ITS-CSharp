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
                try
                {
                    costoProdotto = decimal.Parse(Console.ReadLine()!);
                    if (costoProdotto < 0)
                        throw new ArgumentException("Il costo del prodotto inserito non è valido.");

                    inputValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nIl costo del prodotto inserito non è valido. Riprova.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            inputValido = false;

            // Ciclo per chiedere all'utente di inserire l'importo pagato finché l'input non è valido
            while (!inputValido)
            {
                Console.Write("Inserisci l'importo pagato dal cliente: ");
                try
                {
                    importoPagato = decimal.Parse(Console.ReadLine()!);
                    if (importoPagato < 0)
                        throw new ArgumentException("L'importo pagato inserito non è valido.");
                    if (importoPagato < costoProdotto)
                        throw new ArgumentException("L'importo pagato è inferiore al costo del prodotto.");

                    inputValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nL'importo pagato inserito non è valido. Riprova.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
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