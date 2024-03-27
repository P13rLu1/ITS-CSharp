namespace esercizio1;

public static class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            decimal costoProdotto = 0;
            decimal importoPagato = 0;

            var inputValido = false;

            // chiede all'utente il costo del prodotto con controllo se il costo del prodotto venga inserito giusto
            while (!inputValido)
            {
                Console.Write("Inserisci il costo del prodotto acquistato: ");
                try
                {
                    costoProdotto = decimal.Parse(Console.ReadLine()!);
                    if (costoProdotto < 0)
                        throw new ArgumentException("\nIl costo del prodotto inserito non è valido.");

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

            // chiedo importo pagato con controllo se l'importo pagato venga inserito giusto
            while (!inputValido)
            {
                Console.Write("Inserisci l'importo pagato dal cliente: ");
                try
                {
                    importoPagato = decimal.Parse(Console.ReadLine()!);
                    if (importoPagato < 0)
                        throw new ArgumentException("\nL'importo pagato inserito non è valido.");
                    if (importoPagato < costoProdotto)
                        throw new ArgumentException("\nL'importo pagato è inferiore al costo del prodotto.");

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

            var resto = importoPagato - costoProdotto;

            Console.WriteLine($"Il resto da dare al cliente è: {resto}\n");

            Console.Write("Vuoi fare un altro calcolo? (s/n): ");
            var risposta = Console.ReadLine();

            if (risposta?.ToLower() != "s")
                break;
        }
    }
}