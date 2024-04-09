//Creare una .NET Console App che simuli le funzionalità di base di una calcolatrice. Al lancio, l'applicazione presenterà all'utente un menu di selezione per il tipo di operazione matematica desiderata: addizione, sottrazione, moltiplicazione, divisione, o l'opzione per terminare l'esecuzione del programma. Una volta selezionata l'operazione, l'applicazione richiederà all'utente di inserire due valori numerici. Dopo l'inserimento, calcolerà e visualizzerà il risultato dell'operazione scelta. L'applicazione poi riproporrà il menu per permettere all'utente di eseguire ulteriori calcoli o di terminare il programma. Durante l'interazione, l'applicazione gestirà eventuali errori di input, assicurando che l'utente possa inserire solo numeri validi e prevenendo il crash del programma in caso di errori di digitazione.

namespace esercizio2
{
    internal static class Program
    {
        private static void Main()
        {
            var continua = true;
            Console.WriteLine("Benvenuto nella calcolatrice!\n");

            while (continua)
            {
                Console.Write(
                    "Seleziona l'operazione desiderata:\nA/a. Addizione\nS/s. Sottrazione\nM/m. Moltiplicazione\nD/d. Divisione\nE/e. Esci\nScelta: "); // Menu di selezione

                continua = SceltaOperazione(Console.ReadLine()?.ToUpper() ?? "");
            }
        }

        private static bool SceltaOperazione(string operazione)
        {
            switch (operazione)
            {
                case "A":
                    InserisciNumeri('+'); // Chiamata alla funzione per eseguire l'operazione di addizione
                    break;
                case "S":
                    InserisciNumeri('-'); // Chiamata alla funzione per eseguire l'operazione di sottrazione
                    break;
                case "M":
                    InserisciNumeri('*'); // Chiamata alla funzione per eseguire l'operazione di moltiplicazione
                    break;
                case "D":
                    InserisciNumeri('/'); // Chiamata alla funzione per eseguire l'operazione di divisione
                    break;
                case "E":
                    return false; // Ritorna false per indicare che l'utente ha scelto di finire
                default: // Caso di scelta non valida
                    Console.WriteLine("\nScelta non valida.");
                    Console.Write("Premi un tasto per riprovare..."); // Attesa di un input per continuare
                    Console.ReadKey();
                    break;
            }

            return true; //ritorna true per indicare che l'utente vuole continuare
        }

        private static void InserisciNumeri(char operatore)
        {
            var numeri = new List<double>(); // Lista per contenere i numeri inseriti

            Console.WriteLine("\nInserisci i numeri. Premi invio senza inserire un numero per terminare.");

            var contatoreDecorativo = 1;

            while (true)
            {
                Console.Write($"Inserisci il {contatoreDecorativo} numero" +
                              (contatoreDecorativo <= 2
                                  ? " (obbligatorio): "
                                  : " (premi INVIO per finire): ")); // Messaggio per l'inserimento del numero    
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(
                        input)) //se viene inserito un input vuoto, il ciclo controlla che siano stati inseriti almeno due numeri, se la condizione ;è vera, il ciclo continua, altrimenti esce
                {
                    if (numeri.Count < 2) // Controllo per evitare di terminare l'inserimento con meno di due numeri
                    {
                        Console.WriteLine("\nDevi inserire almeno due numeri.");
                        continue;
                    }

                    break;
                }

                if (!double.TryParse(input, out var numero)) // Controllo per evitare input non numerici
                {
                    Console.WriteLine("\nInput non valido. Inserisci un numero valido.");
                    continue;
                }

                contatoreDecorativo++;
                numeri.Add(numero);
            }

            EseguiOperazione(operatore, numeri);
        }

        private static void
            EseguiOperazione(char operatore, List<double> numeri) // Funzione per eseguire le operazioni matematiche
        {
            var risultato = numeri[0]; // Inizializzazione del risultato con il primo numero inserito

            switch (operatore)
            {
                case '+': // Calcolo del risultato in base all'operatore scelto
                    for (var i = 1; i < numeri.Count; i++)
                    {
                        risultato += numeri[i];
                    }

                    break;
                case '-':
                    for (var i = 1; i < numeri.Count; i++)
                    {
                        risultato -= numeri[i];
                    }

                    break;
                case '*':
                    for (var i = 1; i < numeri.Count; i++)
                    {
                        risultato *= numeri[i];
                    }

                    break;
                case '/':
                    for (var i = 1; i < numeri.Count; i++)
                    {
                        if (numeri[i] != 0) // Controllo per evitare la divisione per zero
                        {
                            risultato /= numeri[i];
                        }
                        else
                        {
                            Console.WriteLine("\nImpossibile dividere per zero.");
                            Console.Write("Premi un tasto per continuare...");
                            Console.ReadKey();
                            return;
                        }
                    }

                    break;
                default:
                    Console.WriteLine("Operatore non riconosciuto.");
                    return;
            }

            Console.WriteLine($"\nRisultato: {risultato:N2}"); // Visualizzazione del risultato con due cifre decimali
            Console.Write("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}