﻿// Creare una ToDoList, ovvero un'applicazione che contiene un elenco di attività da fare. 1. All'avvio l'utente dovrà scegliere l'operazione da compiere tra: Inserisci una nuova attività, Rimuovi un'attività effettuata, Visualizza le attività da fare oppure Esci dal programma; 2. Se l'utente sceglie di inserire una nuova attività gli verrà richiesto un testo descrittivo dell'attività, e questo verrà aggiunto alla lista delle attività; 3. Se l'utente sceglie di rimuovere un'attività, gli verrà visualizzato l'elenco di tutte le attività inserite, e dovrà inserire l'indice corrispondente all'attività da rimuovere. Es. Inserimento: lista.Add(descrizione) Es. rimozione: lista.Remove(lista[posizioneDaRimuovere])

namespace ToDoList
{
    public static class Program
    {
        public static void Main()
        {
            var toDoList = new List<string>();
            var continua = true;
            Console.WriteLine("Benvenuto Nella Lista Piú Bella Del pianeta!\n");

            while (continua)
            {
                Console.Write(
                    "Seleziona l'operazione desiderata:\nA/a. Aggiungi\nR/r. Rimuovi\nV/v. Visualizza\nM/m. Modifica\nE/e. Esci\nScelta: "); // Menu di selezione

                continua = SceltaOperazione(Console.ReadLine()?.ToUpper() ?? "", toDoList);
            }
        }

        private static bool SceltaOperazione(string operazione, List<string> toDoList)
        {
            switch (operazione)
            {
                case "A":
                    Console.WriteLine("\nSei nell'aggiungi");
                    AggiungiLista(toDoList);
                    break;
                case "R":
                    Console.WriteLine("\nSei nel rimuovi");
                    RimuoviLista(toDoList);
                    break;
                case "V":
                    Console.WriteLine("\nSei nel visualizza");
                    VisualizzaLista(toDoList);
                    break;
                case "M":
                    Console.WriteLine("\nSei nel modifica");
                    ModificaLista(toDoList);
                    break;
                case "E":
                    return false; // Ritorna false per indicare che l'utente ha scelto di finire
                default: // Caso di scelta non valida
                    Console.WriteLine("\nScelta non valida.");
                    Console.Write("Premi un tasto per riprovare..."); // Attesa di un ingresso per continuare
                    Console.ReadKey();
                    break;
            }

            return true; // ritorna true per indicare che l'utente vuole continuare
        }

        private static void AggiungiLista(List<string> toDoList)
        {
            var contatoreDecorativo = 1;

            while (true)
            {
                Console.Write($"Inserisci la {contatoreDecorativo} attività" +
                              (contatoreDecorativo <= 1
                                  ? " (obbligatorio): "
                                  : " (premi INVIO per finire): ")); // Messaggio per l'inserimento del numero 
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(
                        input)) //se viene inserito un ingresso vuoto, il ciclo controlla che siano stati inseriti almeno due numeri, se la condizione;è vera, il ciclo continua, altrimenti esce
                {
                    if (toDoList.Count < 1) // Controllo per evitare di terminare l'inserimento con meno di due numeri
                    {
                        Console.WriteLine("\nDevi inserire almeno un'attività.");
                        continue;
                    }

                    break;
                }

                contatoreDecorativo++;
                toDoList.Add(input);
            }

            Console.Write("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private static void RimuoviLista(List<string> toDoList)
        {
            Console.Write("Vuoi Rimuovere un singolo elemento o tutti? (S-s/T-t): ");

            switch (Console.ReadLine()?.ToUpper())
            {
                case "S":
                    do
                    {
                        Console.Write(
                            $"\nInserisci il numero dell'attività da rimuovere\nci sono {toDoList.Count} attività: "); 
                        var input = Console.ReadLine();

                        if (!int.TryParse(input, out var numeroAttivita) || numeroAttivita < 1 ||
                            numeroAttivita > toDoList.Count) // Controllo per evitare di rimuovere un numero non valido o non esistente nella lista 
                        {
                            Console.WriteLine("\nNumero non valido.");
                            Console.Write("Premi un tasto per continuare...");
                            Console.ReadKey();
                            return;
                        }

                        Console.Write(
                            $"Stai per rimuovere l'attività: \"{toDoList[numeroAttivita - 1]}\", sei sicuro? (S-s/N-n): "); // Messaggio di conferma per la rimozione dell'attività
                        if (Console.ReadLine()?.ToUpper() == "S")
                        {
                            toDoList.RemoveAt(numeroAttivita - 1);
                            Console.WriteLine("\nAttività rimossa con successo.");
                        }
                        else
                        {
                            Console.WriteLine("\nAttività non rimossa.");
                        }

                        Console.Write("Vuoi rimuovere un'altra attività? (S-s/N-n): ");
                    } while (Console.ReadLine()?.ToUpper() == "S");

                    Console.Write("Premi un tasto per continuare...");
                    Console.ReadKey();
                    break;

                case "T":
                    Console.Write("Sei sicuro di voler rimuovere tutte le attività? (S-s/N-n): ");
                    if (Console.ReadLine()?.ToUpper() == "S")
                    {
                        toDoList.Clear();
                        Console.WriteLine("\nTutte le attività sono state rimosse.");
                    }
                    else
                    {
                        Console.WriteLine("\nAttività non rimosse.");
                    }

                    Console.Write("Premi un tasto per continuare...");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("\nScelta non valida.");
                    Console.Write("Premi un tasto per continuare...");
                    Console.ReadKey();
                    break;
            }
        }

        private static void VisualizzaLista(List<string> toDoList)
        {
            Console.WriteLine("\nEcco le attività da fare:");
            for (var i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {toDoList[i]}");
            }

            Console.Write("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private static void ModificaLista(List<string> toDoList)
        {
            Console.Write($"inserisci il numero dell'attività da modificare\nci sono {toDoList.Count} attività:");
            if (!int.TryParse(Console.ReadLine(), out var numeroAttivita) || numeroAttivita < 1 ||
                numeroAttivita > toDoList.Count) // Controllo per evitare di modificare un numero non valido o non esistente nella lista
            {                
                Console.WriteLine("\nNumero non valido.");
            }
            
            Console.Write("sei sicuro di voler modificare l'attività? (S-s/N-n): ");
            if (Console.ReadLine()?.ToUpper() == "S")
            {
                Console.Write(
                    $"Stai per modificare l'attività: \"{toDoList[numeroAttivita - 1]}\", inserisci la nuova attività: ");
                toDoList[numeroAttivita - 1] = Console.ReadLine() ?? "";
            }
            else
            {
                Console.WriteLine("\nAttività non modificata.");
            }
            
            Console.WriteLine("\nAttività modificata con successo.");
            Console.Write("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}