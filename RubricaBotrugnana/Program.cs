//Creare una .NET Console App in C# che permetta la gestione di una rubrica. 

// Ogni contatto in rubrica potrà avere:
// - Nome (facoltativo);
// - Cognome (facoltativo);
// - Recapiti (di tipo cellulare, casa, ufficio, email personale ..., di cui almeno il cellulare è obbligatorio);
// - Luogo di nascita (facoltativo);
// - Luogo di residenza (facoltativo);
// - Luogo di domicilio (facoltativo);
// - Eta (intero che indica gli anni del contatto. PRO: usare la data di nascita con il tipo DateOnly o DateTime).
//
// Ogni recapito dovrà contenere:
// - Tipo (facoltativo, "Cellulare", "Casa", "Ufficio", "Email personale" ...)
// - Valore (obbligatorio, conterrà il numero di telefono o l'email).
//
//     Ogni luogo dovrà contenere:
// - Indirizzo (facoltativo);
// - Cap (facoltativo);
// - Citta (obbligatorio);
// - Provincia (obbligatorio);
//
// L'utente potrà eseguire le seguenti operazioni:
// - Inserimento contatto in rubrica, chiedendo quali proprietà facoltative vuole definire;
// - Modifica di un contatto esistente e di qualunque sua proprietà (chiedendo il suo numero di cellulare che deve essere univoco);
// - Cancellazione di un contatto esistente (chiedendo il suo numero di cellulare che deve essere univoco);
// - Visualizzazione dei contatti in rubrica e di tutte le loro proprietà (solo di quelle presenti);
// - Visualizzazione dei contatti in rubrica con residenza in una città richiesta in input;
// - Visualizzazione della media delle età dei contatti in rubrica;
// - Visualizzazione dei contatti con il cognome passato in input;
// - Uscita dal programma (ovviamente).
//     Ricordarsi di gestire tutti i possibili casi d'errore e di separare il codice in diversi metodi atomici.

namespace RubricaBotrugnana
{
    internal static class Program
    {
        static void Main()
        {
            // tutta la logica è in un metodo separato dal Main
            Console.WriteLine("Benvenuto nella tua rubrica!");
            Porcodio();
        }

        static void Porcodio()
        {
            List<Contatto> rubrica = new List<Contatto>();
            string scelta;
            do
            {
                Console.Write(
                    "1. Inserimento contatto in rubrica\n2. Modifica di un contatto esistente\n3. Cancellazione di un contatto esistente\n4. Visualizzazione dei contatti in rubrica\n5. Visualizzazione dei contatti in rubrica con residenza in una città richiesta\n6. Visualizzazione della media delle età dei contatti in rubrica\n7. Visualizzazione dei contatti con il cognome passato in input\n8. Uscita dal programma\nScegli un'opzione: ");
                scelta = Console.ReadLine() ?? "";
                switch (scelta)
                {
                    case "1":
                        Console.WriteLine("\nInserimento contatto in rubrica");
                        InserimentoContatto(rubrica);
                        break;
                    case "2":
                        Console.WriteLine("\nModifica di un contatto esistente");
                        if (rubrica.Count != 0)
                        {
                            // ModificaContatto(rubrica); DOPO (Forse)
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da modificare!");
                            Console.ReadKey();
                        }

                        break;
                    case "3":
                        Console.WriteLine("\nCancellazione di un contatto esistente");
                        if (rubrica.Count != 0)
                        {
                            EliminaContatto(rubrica);
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da cancellare!");
                            Console.ReadKey();
                        }

                        break;
                    case "4":
                        Console.WriteLine("\nVisualizzazione dei contatti in rubrica");
                        if (rubrica.Count != 0)
                        {
                            VisualizzazioneContatti(rubrica);
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da visualizzare!");
                            Console.ReadKey();
                        }

                        break;
                    case "5":
                        Console.WriteLine(
                            "\nVisualizzazione dei contatti in rubrica con residenza in una città richiesta");
                        if (rubrica.Count != 0)
                        {
                            VisualizzazioneContattiPerCittaResidenza(rubrica);
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da visualizzare!");
                            Console.ReadKey();
                        }

                        break;
                    case "6":
                        Console.WriteLine("\nVisualizzazione della media delle età dei contatti in rubrica");
                        if (rubrica.Count != 0)
                        {
                            // VisualizzazioneMediaEta(rubrica); DOPO (Forse)
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da visualizzare!");
                            Console.ReadKey();
                        }

                        break;
                    case "7":
                        Console.WriteLine("\nVisualizzazione dei contatti con il cognome passato in input");
                        if (rubrica.Count != 0)
                        {
                            VisualizzazioneContattiPerCognome(rubrica);
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono contatti da visualizzare!");
                            Console.ReadKey();
                        }

                        break;
                    case "8":
                        Console.WriteLine("Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida!");
                        break;
                }
            } while (scelta != "8");
        }

        private static void InserimentoContatto(List<Contatto> rubrica)
        {
            string numero;
            do // chiedere all'utente il numero da inserire gestendo eventuali errori 
            {
                Console.Write(
                    "Inserisci il numero di cellulare: "); //chiestamento del porca madonna di numero che deve essere porca madonna unico e porca madonna non vuoto
                numero = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(numero))
                {
                    Console.WriteLine("Il numero non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(numero)); // finché l'utente non inserisce un numero valido

            Console.Write(
                "Inserisci il nome (facoltativo): "); // chiedere all'utente il nome, il cognome e il numero da inserire gestendo eventuali errori
            var nome = Console.ReadLine() ?? "";

            Console.Write(
                "Inserisci il cognome (facoltativo): "); // chiedere all'utente il nome, il cognome e il numero da inserire gestendo eventuali errori
            var cognome = Console.ReadLine() ?? "";

            Contatto
                nuovoContatto =
                    new Contatto(numero, nome, cognome); // creare un nuovo contatto con i dati inseriti dall'utente

            string scelta; // chiedere all'utente cosa vuole fare con il contatto appena creato
            do
            {
                Console.Write(
                    "1. Inserisci un recapito\n2. Inserisci un luogo di nascita\n3. Inserisci un luogo di residenza\n4. Inserisci un luogo di domicilio\n5. Esci\nScegli un'opzione: "); // chiede all'utente cosa vuole fare con il contatto appena creato
                scelta = Console.ReadLine() ?? "";
                switch (scelta)
                {
                    case "1":
                        InserimentoRecapito(nuovoContatto); //link al metodo InserimentoRecapito
                        break;
                    case "2":
                        InserimentoLuogo(nuovoContatto, "nascita"); //link al metodo InserimentoLuogo
                        break;
                    case "3":
                        InserimentoLuogo(nuovoContatto, "residenza"); //link al metodo InserimentoLuogo
                        break;
                    case "4":
                        InserimentoLuogo(nuovoContatto, "domicilio"); //link al metodo InserimentoLuogo
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Scelta non valida!");
                        break;
                }
            } while (scelta != "5"); // finché l'utente non decide di uscire

            rubrica.Add(nuovoContatto); // aggiungere il contatto alla rubrica 
        }

        private static void
            InserimentoRecapito(
                Contatto contatto) // chiedere all'utente il tipo e il valore del recapito da inserire gestendo eventuali errori
        {
            Console.Write(
                "Inserisci il tipo di recapito (facoltativo) (cellulare, email, ecc...) : "); // chiedere all'utente il tipo e il valore del recapito da inserire gestendo eventuali errori
            var tipo = Console.ReadLine() ?? "";

            string valore;
            do
            {
                Console.Write(
                    "Inserisci il valore del recapito: "); // chiedere all'utente il tipo e il valore del recapito da inserire gestendo eventuali errori
                valore = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(valore))
                {
                    Console.WriteLine("Il valore non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(valore)); // finché l'utente non inserisce un valore valido

            Recapito
                nuovoRecapito = new Recapito(valore, tipo); // creare un nuovo recapito con i dati inseriti dall'utente
            contatto.Recapiti.Add(nuovoRecapito); // aggiungere il recapito al contatto
        }

        private static void InserimentoLuogo(Contatto contatto, string tipo)
        {
            Console.Write(
                "Inserisci l'indirizzo (facoltativo): "); // chiede l'indirizzo e lo inserisce nel luogo del contatto
            var indirizzo = Console.ReadLine() ?? "";

            Console.Write("Inserisci il CAP (facoltativo): ");
            var cap = Console.ReadLine() ?? "";

            string citta;
            do // chiede la città e la inserisce nel luogo del contatto che non può essere vuota
            {
                Console.Write("Inserisci la città: ");
                citta = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(citta))
                {
                    Console.WriteLine("La città non può essere vuota!");
                }
            } while (string.IsNullOrWhiteSpace(citta));

            string provincia;
            do // chiede la provincia e la inserisce nel luogo del contatto che non può essere vuota
            {
                Console.Write("Inserisci la provincia: ");
                provincia = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(provincia))
                {
                    Console.WriteLine("La provincia non può essere vuota!");
                }
            } while (string.IsNullOrWhiteSpace(provincia));

            Luogo nuovoLuogo =
                new Luogo(citta, provincia, indirizzo, cap); // crea un nuovo luogo con i dati inseriti dall'utente
            switch (tipo) // inserisce il luogo nel contatto in base al tipo
            {
                case "nascita":
                    contatto.LuogoNascita = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                    break;
                case "residenza":
                    contatto.LuogoResidenza = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                    break;
                case "domicilio":
                    contatto.LuogoDomicilio = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                    break;
            }
        }

        private static void VisualizzazioneContatti(List<Contatto> rubrica) // visualizzare i contatti in rubrica
        {
            foreach (Contatto contatto in rubrica) // visualizzare i contatti in rubrica
            {
                Console.WriteLine($"Nome: {contatto.Nome}"); // visualizzare il nome del contatto
                Console.WriteLine($"Cognome: {contatto.Cognome}"); // visualizzare il cognome del contatto
                foreach (Recapito recapito in contatto.Recapiti) //ciclo per visualizzare le informazioni dei recapiti
                {
                    Console.WriteLine(
                        $"{recapito.Tipo}: {recapito.Valore}"); // visualizzare il tipo e il valore del recapito
                }

                if (contatto.LuogoNascita != null) // visualizzare il luogo di nascita se presente
                {
                    Console.WriteLine(
                        $"Luogo di nascita: {contatto.LuogoNascita.Indirizzo} {contatto.LuogoNascita.Cap} {contatto.LuogoNascita.Citta} ({contatto.LuogoNascita.Provincia})");
                }

                if (contatto.LuogoResidenza != null) // visualizzare il luogo di residenza se presente
                {
                    Console.WriteLine(
                        $"Luogo di residenza: {contatto.LuogoResidenza.Indirizzo} {contatto.LuogoResidenza.Cap} {contatto.LuogoResidenza.Citta} ({contatto.LuogoResidenza.Provincia})");
                }

                if (contatto.LuogoDomicilio != null) // visualizzare il luogo di domicilio se presente
                {
                    Console.WriteLine(
                        $"Luogo di domicilio: {contatto.LuogoDomicilio.Indirizzo} {contatto.LuogoDomicilio.Cap} {contatto.LuogoDomicilio.Citta} ({contatto.LuogoDomicilio.Provincia})");
                }

                Console.WriteLine("-----------------------------");
            }

            Console.ReadKey();
        }

        private static void EliminaContatto(List<Contatto> rubrica) //funzione per eliminare un contatto
        {
            string numero;
            do //ciclo per chiedere il numero del contatto da eliminare
            {
                Console.Write(
                    "Inserisci il numero di cellulare del contatto da cancellare: "); // chiedere all'utente il numero da inserire gestendo eventuali errori
                numero = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(numero))
                {
                    Console.WriteLine("Il numero non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(numero)); // finché l'utente non inserisce un numero valido

            Contatto? contattoDaCancellare = null; //inizializzazione del contatto da cancellare
            foreach (var contatto in rubrica) //ciclo per cercare il contatto da cancellare dal numero
            {
                foreach (var recapito in contatto.Recapiti) //ciclo per cercare il contatto da cancellare dai recapiti
                {
                    if (recapito.Valore == numero) //se il recapito è uguale al numero da cancellare
                    {
                        contattoDaCancellare = contatto; //il contatto da cancellare è il contatto corrente
                        break;
                    }
                }

                if (contattoDaCancellare != null) //se il contatto da cancellare è stato trovato
                {
                    break; //esci dal ciclo
                }
            }

            if (contattoDaCancellare != null) //se il contatto da cancellare è stato trovato e non è nullo 
            {
                rubrica.Remove(contattoDaCancellare); //rimuovi il contatto dalla rubrica
                Console.WriteLine("Contatto cancellato con successo!");
            }
            else
            {
                Console.WriteLine(
                    "Contatto non trovato!"); //se il contatto da cancellare non è stato trovato visualizza un messaggio di errore
            }

            Console.ReadKey();
        }

        private static void
            VisualizzazioneContattiPerCittaResidenza(
                List<Contatto> rubrica) //funzione per visualizzare i contatti con residenza in una città richiesta
        {
            string citta;
            do //ciclo per chiedere la città da cercare
            {
                Console.Write("Inserisci la città di residenza da cercare: "); // chiedere all'utente la città da cercare
                citta = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(citta))
                {
                    Console.WriteLine("La città non può essere vuota!");
                }
            } while (string.IsNullOrWhiteSpace(citta)); // finché l'utente non inserisce una città valida

            var contattoTrovato = false; 
            foreach (var contatto in rubrica) //ciclo per cercare i contatti con residenza nella città richiesta
            {
                if (contatto.LuogoResidenza?.Citta == citta) //se il contatto ha residenza nella città richiesta
                {
                    contattoTrovato = true; //il contatto è stato trovato
                    Console.WriteLine($"Nome: {contatto.Nome}"); //visualizza il nome del contatto
                    Console.WriteLine($"Cognome: {contatto.Cognome}"); //visualizza il cognome del contatto
                    foreach (Recapito recapito in contatto.Recapiti)
                    {
                        Console.WriteLine($"{recapito.Tipo}: {recapito.Valore}"); //visualizza il tipo e il valore del recapito
                    }

                    if (contatto.LuogoNascita != null)
                    {
                        Console.WriteLine(
                            $"Luogo di nascita: {contatto.LuogoNascita.Indirizzo} {contatto.LuogoNascita.Cap} {contatto.LuogoNascita.Citta} ({contatto.LuogoNascita.Provincia})"); //visualizza il luogo di nascita se presente
                    }

                    if (contatto.LuogoResidenza != null)
                    {
                        Console.WriteLine(
                            $"Luogo di residenza: {contatto.LuogoResidenza.Indirizzo} {contatto.LuogoResidenza.Cap} {contatto.LuogoResidenza.Citta} ({contatto.LuogoResidenza.Provincia})"); //visualizza il luogo di residenza se presente
                    }

                    if (contatto.LuogoDomicilio != null)
                    {
                        Console.WriteLine(
                            $"Luogo di domicilio: {contatto.LuogoDomicilio.Indirizzo} {contatto.LuogoDomicilio.Cap} {contatto.LuogoDomicilio.Citta} ({contatto.LuogoDomicilio.Provincia})"); //visualizza il luogo di domicilio se presente
                    }

                    Console.WriteLine("-----------------------------");
                }
            }

            if (!contattoTrovato)
            {
                Console.WriteLine("Nessun contatto trovato!"); //se nessun contatto è stato trovato visualizza un messaggio di errore
            }

            Console.ReadKey();
        }
        
        private static void VisualizzazioneContattiPerCognome(List<Contatto> rubrica) //funzione per visualizzare i contatti con un cognome richiesto
        {
            string cognome;
            do 
            {
                Console.Write("Inserisci il cognome da cercare: "); //chiede il cognome da cercare
                cognome = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(cognome)) //se il cognome è vuoto visualizza un messaggio di errore
                {
                    Console.WriteLine("Il cognome non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(cognome)); // finché l'utente non inserisce un cognome valido il ciclo continua

            var contattoTrovato = false; //inizializzazione del contatto trovato
            foreach (var contatto in rubrica)
            {
                if (contatto.Cognome == cognome) //se il cognome del contatto è uguale al cognome richiesto visualizza le informazioni del contatto
                {
                    contattoTrovato = true;
                    Console.WriteLine($"Nome: {contatto.Nome}"); //visualizza il nome del contatto
                    Console.WriteLine($"Cognome: {contatto.Cognome}"); //visualizza il cognome del contatto
                    foreach (Recapito recapito in contatto.Recapiti) 
                    {
                        Console.WriteLine($"{recapito.Tipo}: {recapito.Valore}");
                    }

                    if (contatto.LuogoNascita != null)
                    {
                        Console.WriteLine(
                            $"Luogo di nascita: {contatto.LuogoNascita.Indirizzo} {contatto.LuogoNascita.Cap} {contatto.LuogoNascita.Citta} ({contatto.LuogoNascita.Provincia})");
                    }

                    if (contatto.LuogoResidenza != null)
                    {
                        Console.WriteLine(
                            $"Luogo di residenza: {contatto.LuogoResidenza.Indirizzo} {contatto.LuogoResidenza.Cap} {contatto.LuogoResidenza.Citta} ({contatto.LuogoResidenza.Provincia})");
                    }

                    if (contatto.LuogoDomicilio != null)
                    {
                        Console.WriteLine(
                            $"Luogo di domicilio: {contatto.LuogoDomicilio.Indirizzo} {contatto.LuogoDomicilio.Cap} {contatto.LuogoDomicilio.Citta} ({contatto.LuogoDomicilio.Provincia})");
                    }

                    Console.WriteLine("-----------------------------");
                }
            }

            if (!contattoTrovato) //se nessun contatto è stato trovato visualizza un messaggio di errore
            {
                Console.WriteLine("Nessun contatto trovato!");
            }

            Console.ReadKey();
        }
    }
}