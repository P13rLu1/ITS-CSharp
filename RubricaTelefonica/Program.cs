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

            rubrica.Add(new Contatto(nome, cognome, numeroDiTelefono)); // Aggiunta del contatto alla rubrica 

            Console.Write(
                "Vuoi aggiungere un altro contatto? (S-s/N-n): "); // Richiesta di continuare con l'aggiunta di un altro contatto
            if (Console.ReadLine()?.ToUpper() == "N")
            {
                continua = false;
            }
        } while (continua);

        Console.WriteLine("\nContatti aggiunto con successo!");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void RimuoviContatto(List<Contatto> rubrica)
    {
        var continua = true;
        do // Ciclo per permettere all'utente di rimuovere più contatti in una sola sessione 
        {
            Console.Write("Inserisci il numero di telefono del contatto da rimuovere: ");
            var numeroDiTelefono = Console.ReadLine();

            Contatto? contattoDaRimuovere = null;
            foreach (var contatto in rubrica) // Scansione di tutti i contatti nella rubrica
            {
                if (contatto.NumeroDiTelefono ==
                    numeroDiTelefono) // Cerca il contatto con il numero di telefono specificato dall'utente 
                {
                    contattoDaRimuovere =
                        contatto; // Salva il contatto trovato in contattoDaModificare e interrompe il ciclo 
                    break;
                }
            }

            if (contattoDaRimuovere ==
                null) // Se non è stato trovato alcun contatto con il numero di telefono specificato dall'utente stampa un messaggio di errore e termina il metodo
            {
                Console.WriteLine("\nContatto non trovato.");
                Console.Write("Premi un tasto per continuare...");
                Console.ReadKey();
                return;
            }

            Console.Write(
                $"\nHo Trovato =\nNome: {contattoDaRimuovere.Nome} \nCognome: {contattoDaRimuovere.Cognome} \nNumero di telefono: {contattoDaRimuovere.NumeroDiTelefono}\nStai per eliminare questo contatto. Sei sicuro? (S-s/N-n)"); // Stampa il contatto trovato all'utente per conferma 
            var conferma = Console.ReadLine()?.ToUpper() ?? "";

            if (conferma == "N") // Se l'utente non conferma l'eliminazione del contatto, termina il metodo
            {
                Console.WriteLine("Operazione annullata.");
                Console.Write("Premi un tasto per continuare...");
                Console.ReadKey();
                return;
            }

            rubrica.Remove(contattoDaRimuovere); // Rimuove il contatto dalla rubrica 

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
        if (rubrica.Count == 0) // Se la rubrica è vuota, stampa un messaggio e termina il metodo
        {
            Console.WriteLine("\nRubrica vuota.");
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
            return;
        }
        
        foreach (var contatto in rubrica) // Scansione di tutti i contatti nella rubrica e stampa di ciascuno di essi 
        {
            Console.WriteLine(
                $"Nome: {contatto.Nome} \nCognome: {contatto.Cognome} \nNumero di telefono: {contatto.NumeroDiTelefono} \n -----------------");
        }

        Console.WriteLine("\nPremi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void ModificaContatto(List<Contatto> rubrica)
    {
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

        Contatto?
            contattoDaModificare =
                null; // Inizializza contattoDaModificare a null per indicare che non è stato trovato alcun contatto con il numero di telefono specificato dall'utente all'inizio
        foreach (var contatto in rubrica) // Scansione di tutti i contatti nella rubrica
        {
            if (contatto.NumeroDiTelefono ==
                numeroDiTelefono) // Cerca il contatto con il numero di telefono specificato dall'utente 
            {
                contattoDaModificare =
                    contatto; // Salva il contatto trovato in contattoDaModificare e interrompe il ciclo 
                break;
            }
        }

        if (contattoDaModificare ==
            null) // Se non è stato trovato alcun contatto con il numero di telefono specificato dall'utente stampa un messaggio di errore e termina il metodo
        {
            Console.WriteLine("Contatto non trovato.");
            return;
        }

        Console.WriteLine(
            $"\nHo trovato il contatto:\nNome: {contattoDaModificare.Nome}\nCognome: {contattoDaModificare.Cognome}\nNumero di telefono: {contattoDaModificare.NumeroDiTelefono}"); // Stampa il contatto trovato all'utente per conferma

        switch (scelta) // Modifica del campo selezionato dall'utente 
        {
            case "N": // Modifica del nome del contatto 
                Console.Write("Inserisci il nuovo nome: "); 
                contattoDaModificare.Nome = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(contattoDaModificare.Nome)) // Controllo che il nome non sia vuoto
                {
                    Console.WriteLine("\nNome non valido.");
                }

                break;
            case "C":
                Console.Write("Inserisci il nuovo cognome: "); // Modifica del cognome del contatto
                contattoDaModificare.Cognome = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(contattoDaModificare.Cognome)) // Controllo che il cognome non sia vuoto
                {
                    Console.WriteLine("\nCognome non valido.");
                }

                break;
            case "T":
                Console.Write("Inserisci il nuovo numero di telefono: "); // Modifica del numero di telefono del contatto
                contattoDaModificare.NumeroDiTelefono = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(contattoDaModificare.NumeroDiTelefono)) // Controllo che il numero di telefono non sia vuoto
                {
                    Console.WriteLine("\nNumero di telefono non valido.");
                }

                break;
            case "A":
                Console.Write("Inserisci il nuovo nome: ");
                contattoDaModificare.Nome = Console.ReadLine() ?? "";
                
                Console.Write("Inserisci il nuovo cognome: ");
                contattoDaModificare.Cognome = Console.ReadLine() ?? "";
                
                Console.Write("Inserisci il nuovo numero di telefono: ");
                contattoDaModificare.NumeroDiTelefono = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(contattoDaModificare.Nome) || string.IsNullOrWhiteSpace(contattoDaModificare.Cognome) || string.IsNullOrWhiteSpace(contattoDaModificare.NumeroDiTelefono)) // Controllo che nessuno dei campi sia vuoto 
                {
                    Console.WriteLine("\nUno o più campi non validi.");
                }
                break;
        }
    }
}