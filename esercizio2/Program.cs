//Creare una .NET Console App che simuli le funzionalità di base di una calcolatrice. Al lancio, l'applicazione presenterà all'utente un menu di selezione per il tipo di operazione matematica desiderata: addizione, sottrazione, moltiplicazione, divisione, o l'opzione per terminare l'esecuzione del programma. Una volta selezionata l'operazione, l'applicazione richiederà all'utente di inserire due valori numerici. Dopo l'inserimento, calcolerà e visualizzerà il risultato dell'operazione scelta. L'applicazione poi riproporrà il menu per permettere all'utente di eseguire ulteriori calcoli o di terminare il programma. Durante l'interazione, l'applicazione gestirà eventuali errori di input, assicurando che l'utente possa inserire solo numeri validi e prevenendo il crash del programma in caso di errori di digitazione.

namespace esercizio2
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Benvenuto nella calcolatrice!\n");
            while (true)
            {
                Console.Write(
                    "Seleziona l'operazione desiderata:\nA/a. Addizione\nS/s. Sottrazione\nM/m. Moltiplicazione\nD/d. Divisione\nE/e. Esci\nScelta: "); // Menu di selezione

                switch (Console.ReadLine()?.ToUpper())
                {
                    case "A":
                        EseguiOperazione('+'); // Chiamata alla funzione per eseguire l'operazione di addizione
                        break;
                    case "S":
                        EseguiOperazione('-'); // Chiamata alla funzione per eseguire l'operazione di sottrazione
                        break;
                    case "M":
                        EseguiOperazione('*'); // Chiamata alla funzione per eseguire l'operazione di moltiplicazione
                        break;
                    case "D":
                        EseguiOperazione('/'); // Chiamata alla funzione per eseguire l'operazione di divisione
                        break;
                    case "E":
                        return; // Uscita dal programma
                    default: // Caso di scelta non valida
                        Console.WriteLine("\nScelta non valida.");
                        Console.Write("Premi un tasto per riprovare..."); // Attesa di un input per continuare
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void EseguiOperazione(char operatore) // Funzione per eseguire le operazioni matematiche
        {
            Console.Write("Quanti numeri vuoi inserire? ");
            int numNumeri;
            while (!int.TryParse(Console.ReadLine(), out numNumeri) || numNumeri < 2) // Ripeti finché l'input non è un numero intero maggiore o uguale a 2
            {
                Console.WriteLine("\nInput non valido. Inserisci un numero intero maggiore o uguale a 2.");
                Console.Write("Quanti numeri vuoi inserire? ");
            }

            var numeri = new double[numNumeri]; // Array per contenere i numeri inseriti

            for (var i = 0; i < numNumeri; i++)
            {
                Console.Write($"Inserisci il {i + 1}° numero: ");
                while (!double.TryParse(Console.ReadLine(), out numeri[i])) // Ripeti finché l'input non è un numero
                {
                    Console.WriteLine("\nInput non valido. Inserisci un numero valido.");
                    Console.Write($"Inserisci il {i + 1}° numero: ");
                }
            }

            var risultato = numeri[0]; // Inizializzazione del risultato con il primo numero inserito

            switch (operatore)
            {
                case '+': // Calcolo del risultato in base all'operatore scelto
                    for (var i = 1; i < numNumeri; i++)
                    {
                        risultato += numeri[i];
                    }

                    break;
                case '-':
                    for (var i = 1; i < numNumeri; i++)
                    {
                        risultato -= numeri[i];
                    }

                    break;
                case '*':
                    for (var i = 1; i < numNumeri; i++)
                    {
                        risultato *= numeri[i];
                    }

                    break;
                case '/':
                    for (var i = 1; i < numNumeri; i++)
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