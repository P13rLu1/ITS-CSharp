//Creare una .NET Console App in C# che permetta la gestione di una rubrica. Chiedere all'avvio se l'utente desidera inserire, eliminare o visualizzare la rubrica. In fase di inserimento permettere di digitare nome, cognome e numero di telefono e gestire eventuali errori. Gestire la cancellazione chiedendo il numero di telefono (chiave univoca). Pro: gestire la modifica.

namespace RubricaTelefonica;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nella tua rubrica telefonica!");

        List<Contatto> rubrica = new List<Contatto>();
        var continua = true;

        while (continua)
        {
            Console.Write(
                "Seleziona l'operazione desiderata:\nA/a. Aggiungi\nR/r. Rimuovi\nV/v. Visualizza\nM/m. Modifica\nE/e. Esci\nScelta: "); // Menu di selezione delle operazioni

            continua = SceltaOperazione(Console.ReadLine()?.ToUpper() ?? "", rubrica);
        }
    }

    private static bool SceltaOperazione(string operazione, List<Contatto> rubrica)
    {
        switch (operazione)
        {
            case "A":
                Console.WriteLine("\nSei nell'aggiungi"); // Chiamata al metodo per l'aggiunta di un contatto
                AggiungiContatto(rubrica);
                break;
            case "R":
                Console.WriteLine("\nSei nel rimuovi"); // Chiamata al metodo per la rimozione di un contatto
                RimuoviContatto(rubrica);
                break;
            case "V":
                Console.WriteLine(
                    "\nSei nel visualizza"); // Chiamata al metodo per la visualizzazione di tutti i contatti
                VisualizzaContatto(rubrica);
                break;
            case "M":
                Console.WriteLine("\nSei nel modifica"); // Chiamata al metodo per la modifica di un contatto
                ModificaContatto(rubrica);
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

    private static void AggiungiContatto(List<Contatto> rubrica)
    {
        var continua = true;
        do // Ciclo per permettere all'utente di aggiungere più contatti in una sola sessione 
        {
            Console.Write("Inserisci il nome: ");
            var nome = Console.ReadLine();

            Console.Write("Inserisci il cognome: ");
            var cognome = Console.ReadLine();

            Console.Write("Inserisci il numero di telefono: ");
            var numeroDiTelefono = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome) ||
                string.IsNullOrWhiteSpace(numeroDiTelefono)) // Controllo che i campi non siano vuoti 
            {
                Console.WriteLine("\nUno o più campi sono vuoti. Riprova.");
                Console.Write("Premi un tasto per continuare...");
                Console.ReadKey();
                return;
            }

            foreach (var contatto in
                     rubrica) // Scansione di tutti i contatti nella rubrica per verificare che il numero di telefono non sia già presente visto che deve essere univoco
            {
                if (contatto.NumeroDiTelefono == numeroDiTelefono)
                {
                    Console.WriteLine("\nQuesto numero di telefono è già presente nella rubrica.");
                    Console.Write("Premi un tasto per continuare...");
                    Console.ReadKey();
                    return;
                }
            }

            rubrica.Add(new Contatto(nome, cognome, numeroDiTelefono)); // Aggiunta del contatto alla rubrica 

            Console.Write(
                "Vuoi aggiungere un altro contatto? (S-s/N-n): "); // Richiesta di continuare con l'aggiunta di un altro contatto
            if (Console.ReadLine()?.ToUpper() == "N")
            {
                continua = false;
            }
        } while (continua);

        Console.WriteLine("\nContatti aggiunti con successo!");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void RimuoviContatto(List<Contatto> rubrica)
    {
        if (RubricaVuota(rubrica))
        {
            return; // Se la rubrica è vuota, termina il metodo senza fare ulteriori operazioni
        }

        var continua = true;

        do // Ciclo per permettere all'utente di rimuovere più contatti in una sola sessione 
        {
            Console.Write("Inserisci il numero di telefono del contatto da rimuovere: ");
            var numeroDiTelefono = Console.ReadLine();

            if (!TrovaContattoPerNumero(rubrica, numeroDiTelefono ?? "", out var contattoDaRimuovere)) // Trova il contatto da rimuovere se esiste altrimenti termina il metodo
            { 
                Console.WriteLine("\nContatto non trovato.");
                Console.Write("Premi un tasto per continuare...");
                Console.ReadKey();
                return;
            }

            Console.Write(
                $"\nHo trovato il contatto:\nNome: {contattoDaRimuovere.Nome}\nCognome: {contattoDaRimuovere.Cognome}\nNumero di telefono: {contattoDaRimuovere.NumeroDiTelefono}"); // Stampa il contatto trovato all'utente per conferma

            Console.Write("\nStai per eliminare questo contatto. Sei sicuro? (S-s/N-n): ");
            var conferma = Console.ReadLine()?.ToUpper() ?? "";

            if (conferma == "N") // Se l'utente annulla l'operazione, termina il metodo senza fare ulteriori operazioni
            {
                Console.WriteLine("Operazione annullata.");
                Console.Write("Premi un tasto per continuare...");
                Console.ReadKey();
                return;
            }

            rubrica.Remove(contattoDaRimuovere); // Rimuove il contatto dalla rubrica 

            Console.WriteLine("\nDi seguito la rubrica aggiornata: ");
            VisualizzaContatto(rubrica);

            Console.Write(
                "Vuoi rimuovere un altro contatto? (S-s/N-n): "); // Richiesta di continuare con la rimozione di un altro contatto
            if (Console.ReadLine()?.ToUpper() == "N")
            {
                continua = false;
            }
        } while (continua);

        Console.WriteLine("\nContatto rimosso con successo!");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void VisualizzaContatto(List<Contatto> rubrica)
    {
        if (RubricaVuota(rubrica))
        {
            return; // Se la rubrica è vuota, termina il metodo senza fare ulteriori operazioni
        }

        var numeroContatto = 1; // Numero del primo contatto

        foreach (var contatto in rubrica) // Scansione di tutti i contatti nella rubrica e stampa di ciascuno di essi 
        {
            Console.WriteLine($"Contatto {numeroContatto}:");
            Console.WriteLine(
                $"Nome: {contatto.Nome} \nCognome: {contatto.Cognome} \nNumero di telefono: {contatto.NumeroDiTelefono} \n -----------------");
            numeroContatto++; // Incremento del numero del contatto per il prossimo contatto
        }

        Console.WriteLine("\nPremi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void ModificaContatto(List<Contatto> rubrica)
    {
        if (RubricaVuota(rubrica))
        {
            return; // Se la rubrica è vuota, termina il metodo senza fare ulteriori operazioni
        }

        var continua = true;

        do
        {
            Console.WriteLine(
                "Cosa vuoi modificare?\nN-n. Nome\nC-c. Cognome\nT-t. Numero di telefono\nA-a Tutto\nScelta: "); // Menu di selezione per la modifica del contatto
            var scelta = Console.ReadLine()?.ToUpper() ?? "";

            switch (scelta)
            {
                case "N":
                    ModificaContattiSelezione(rubrica,
                        scelta); // Chiamata al metodo per la modifica del nome del contatto 
                    break;
                case "C":
                    ModificaContattiSelezione(rubrica,
                        scelta); // Chiamata al metodo per la modifica del cognome del contatto
                    break;
                case "T":
                    ModificaContattiSelezione(rubrica,
                        scelta); // Chiamata al metodo per la modifica del numero di telefono del contatto
                    break;
                case "A":
                    ModificaContattiSelezione(rubrica,
                        scelta); // Chiamata al metodo per la modifica di tutti i campi del contatto
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            Console.Write(
                "Vuoi modificare un altro contatto? (S-s/N-n): "); // Richiesta di continuare con la modifica di un altro contatto
            if (Console.ReadLine()?.ToUpper() == "N")
            {
                continua = false;
            }

            Console.WriteLine("\nContatto modificato con successo!");
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        } while (continua);
    }

    private static void ModificaContattiSelezione(List<Contatto> rubrica, string scelta)
    {
        Console.Write("Inserisci il numero di telefono del contatto da modificare: ");
        var numeroDiTelefono = Console.ReadLine();

        if (!TrovaContattoPerNumero(rubrica, numeroDiTelefono ?? "", out var contattoDaModificare))
        {
            Console.WriteLine("Contatto non trovato.");
            return;
        }

        Console.WriteLine(
            $"\nHo trovato il contatto:\nNome: {contattoDaModificare.Nome}\nCognome: {contattoDaModificare.Cognome}\nNumero di telefono: {contattoDaModificare.NumeroDiTelefono}");

        switch (scelta)
        {
            case "N":
                Console.Write("Inserisci il nuovo nome: ");
                var nuovoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoNome)) // Controllo che il nome non sia vuoto 
                {
                    contattoDaModificare.Nome = nuovoNome;
                }
                else
                {
                    Console.WriteLine("Nome non valido.");
                }

                break;
            case "C":
                Console.Write("Inserisci il nuovo cognome: ");
                var nuovoCognome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoCognome)) // Controllo che il cognome non sia vuoto
                {
                    contattoDaModificare.Cognome = nuovoCognome;
                }
                else
                {
                    Console.WriteLine("Cognome non valido.");
                }

                break;
            case "T":
                Console.Write("Inserisci il nuovo numero di telefono: ");
                var nuovoNumeroDiTelefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoNumeroDiTelefono)) // Controllo che il numero di telefono non sia vuoto
                {
                    contattoDaModificare.NumeroDiTelefono = nuovoNumeroDiTelefono;
                }
                else
                {
                    Console.WriteLine("Numero di telefono non valido.");
                }

                break;
            case "A":
                Console.Write("Inserisci il nuovo nome: ");
                var nuovoNomeCompleto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoNomeCompleto))
                {
                    contattoDaModificare.Nome = nuovoNomeCompleto;
                }
                else
                {
                    Console.WriteLine("Nome non valido.");
                    break;
                }

                Console.Write("Inserisci il nuovo cognome: ");
                var nuovoCognomeCompleto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoCognomeCompleto))
                {
                    contattoDaModificare.Cognome = nuovoCognomeCompleto;
                }
                else
                {
                    Console.WriteLine("Cognome non valido.");
                    break;
                }

                Console.Write("Inserisci il nuovo numero di telefono: ");
                var nuovoNumeroCompleto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuovoNumeroCompleto))
                {
                    contattoDaModificare.NumeroDiTelefono = nuovoNumeroCompleto;
                }
                else
                {
                    Console.WriteLine("Numero di telefono non valido.");
                }

                break;
            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }

        Console.WriteLine("\nContatto modificato con successo!");
    }

    private static bool RubricaVuota(List<Contatto> rubrica) // Metodo per controllare se la rubrica è vuota
    {
        if (rubrica.Count == 0) // Se la rubrica è vuota, stampa un messaggio e ritorna true
        {
            Console.WriteLine("La rubrica è vuota. Non ci sono contatti.");
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(); 
            return true;
        }

        return false;
    }

    private static bool TrovaContattoPerNumero(List<Contatto> rubrica, string numeroDiTelefono,
        out Contatto contattoTrovato) // Metodo per trovare un contatto nella rubrica per numero di telefono
    {
        contattoTrovato = null!; // Inizializziamo il contatto trovato a null

        foreach (var contatto in rubrica) // Scansione di tutti i contatti nella rubrica
        {
            if (contatto.NumeroDiTelefono == numeroDiTelefono)
            {
                contattoTrovato = contatto;
                return true; // Ritorna true se trova il contatto
            }
        }

        return false; // Ritorna false se il contatto non viene trovato
    }
}