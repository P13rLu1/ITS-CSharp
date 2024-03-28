//Creare una .NET Console App che simuli le funzionalità di base di una calcolatrice. Al lancio, l'applicazione presenterà all'utente un menu di selezione per il tipo di operazione matematica desiderata: addizione, sottrazione, moltiplicazione, divisione, o l'opzione per terminare l'esecuzione del programma. Una volta selezionata l'operazione, l'applicazione richiederà all'utente di inserire due valori numerici. Dopo l'inserimento, calcolerà e visualizzerà il risultato dell'operazione scelta. L'applicazione poi riproporrà il menu per permettere all'utente di eseguire ulteriori calcoli o di terminare il programma. Durante l'interazione, l'applicazione gestirà eventuali errori di input, assicurando che l'utente possa inserire solo numeri validi e prevenendo il crash del programma in caso di errori di digitazione.

namespace esercizio2
{
    static class Program
    {
        static void Main()
        {
            bool continua = true;

            while (continua)
            {
                Console.Write(
                    "Seleziona l'operazione desiderata:\n1. Addizione\n2. Sottrazione\n3. Moltiplicazione\n4. Divisione\n5. Esci\nScelta: ");

                string? sceltaOperazione = Console.ReadLine();

                switch (sceltaOperazione)
                {
                    case "1":
                        EseguiOperazione('+');
                        break;
                    case "2":
                        EseguiOperazione('-');
                        break;
                    case "3":
                        EseguiOperazione('*');
                        break;
                    case "4":
                        EseguiOperazione('/');
                        break;
                    case "5":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("\nScelta non valida. Riprova. (Cugghiune)");
                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EseguiOperazione(char operatore)
        {
            double num1, num2;

            Console.Write("Inserisci il primo numero: ");
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Input non valido. Inserisci un numero valido.");
                Console.Write("Primo numero: ");
            }

            Console.Write("Inserisci il secondo numero: ");
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Input non valido. Inserisci un numero valido.");
                Console.Write("Secondo numero: ");
            }

            double risultato;

            switch (operatore)
            {
                case '+':
                    risultato = num1 + num2;
                    break;
                case '-':
                    risultato = num1 - num2;
                    break;
                case '*':
                    risultato = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        risultato = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Impossibile dividere per zero.");
                        return;
                    }

                    break;
                default:
                    Console.WriteLine("Operatore non riconosciuto.");
                    return;
            }

            Console.WriteLine($"Risultato: {risultato}");
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(); // Attende che l'utente prema un tasto
        }
    }
}