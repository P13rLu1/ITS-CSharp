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
        private static void Main()
        {
            // tutta la logica è in un metodo separato dal Main
            Console.WriteLine("Benvenuto nella tua rubrica!");
            Porcodio();
        }

        private static void Porcodio() // funzione per lo switch case del menu
        {
            List<Contatto> rubrica = new List<Contatto>(); // creare una lista di contatti per la rubrica
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
                            ModificaContatto(rubrica);
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
                            VisualizzazioneMediaEta(rubrica);
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

        private static void InserimentoContatto(List<Contatto> rubrica) // funzione per inserire un contatto in rubrica
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

                foreach (var contatto in rubrica) //ciclo per controllare che il numero sia unico
                {
                    foreach (var recapito in contatto.Recapiti) //ciclo per controllare che il numero sia unico
                    {
                        if (recapito.Valore != numero)
                            continue; //se il numero è già presente in rubrica visualizza un messaggio di errore
                        Console.WriteLine("Il numero è già presente in rubrica!");
                        numero = "";
                        break;
                    }

                    if (numero == "") //se il numero è già presente in rubrica visualizza un messaggio di errore
                    {
                        break;
                    }
                }
            } while (string.IsNullOrWhiteSpace(numero)); // finché l'utente non inserisce un numero valido

            Console.Write(
                "Inserisci il nome (facoltativo): "); // chiedere all'utente il nome, il cognome e il numero da inserire gestendo eventuali errori
            var nome = Console.ReadLine() ?? "";

            Console.Write(
                "Inserisci il cognome (facoltativo): "); // chiedere all'utente il nome, il cognome e il numero da inserire gestendo eventuali errori
            var cognome = Console.ReadLine() ?? "";

            var
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

            InserimentoEta(nuovoContatto); //link al metodo InserimentoEta

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

            var
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

            var nuovoLuogo =
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
            foreach (var contatto in rubrica) // visualizzare i contatti in rubrica
            {
                Console.WriteLine(
                    $"Nome: {contatto.Nome}\nCognome: {contatto.Cognome}\nData di nascita: {contatto.DataNascita:dd/MM/yyyy}\nEtà: {contatto.Eta}"); // visualizzare il nome del contatto e il cognome del contatto e la data di nascita e l'età del contatto
                foreach (var recapito in contatto.Recapiti) //ciclo per visualizzare le informazioni dei recapiti
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
                Console.WriteLine(
                    $"\nHo trovato il contatto {contattoDaCancellare.Nome} {contattoDaCancellare.Cognome}");
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

        private static void VisualizzazioneContattiPerCittaResidenza(List<Contatto> rubrica)
        {
            string citta;
            do
            {
                Console.Write("Inserisci la città di residenza da cercare: ");
                citta = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(citta))
                {
                    Console.WriteLine("La città non può essere vuota!");
                }
            } while (string.IsNullOrWhiteSpace(citta));

            List<Contatto> contattiTrovati = new List<Contatto>();

            foreach (var contatto in rubrica)
            {
                if (contatto.LuogoResidenza?.Citta == citta)
                {
                    contattiTrovati.Add(contatto);
                }
            }

            if (contattiTrovati.Count > 0)
            {
                VisualizzazioneContatti(contattiTrovati);
            }
            else
            {
                Console.WriteLine("Nessun contatto trovato!");
            }

            Console.ReadKey();
        }

        private static void
            VisualizzazioneContattiPerCognome(
                List<Contatto> rubrica) //funzione per visualizzare i contatti con un cognome richiesto
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
            } while
                (string.IsNullOrWhiteSpace(
                    cognome)); // finché l'utente non inserisce un cognome valido il ciclo continua

            List<Contatto> contattiTrovati = new List<Contatto>();

            foreach (var contatto in rubrica)
            {
                if (contatto.Cognome == cognome)
                {
                    contattiTrovati.Add(contatto);
                }
            }

            if (contattiTrovati.Count > 0)
            {
                VisualizzazioneContatti(contattiTrovati);
            }
            else
            {
                Console.WriteLine("Nessun contatto trovato!");
            }

            Console.ReadKey();
        }

        private static void ModificaContatto(List<Contatto> rubrica) //funzione per modificare un contatto
        {
            string numero;
            do //ciclo per chiedere il numero del contatto da modificare
            {
                Console.Write(
                    "Inserisci il numero di cellulare del contatto da modificare: "); //chiede all'utente il numero da modificare
                numero = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(numero)) //se il numero è vuoto visualizza un messaggio di errore
                {
                    Console.WriteLine("Il numero non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(numero)); // finché l'utente non inserisce un numero valido

            Contatto? contattoDaModificare = null; //inizializzazione del contatto da modificare
            foreach (var contatto in rubrica)
            {
                foreach (var recapito in contatto.Recapiti)
                {
                    if (recapito.Valore == numero) //se il recapito è uguale al numero da modificare
                    {
                        contattoDaModificare = contatto; //il contatto da modificare è il contatto corrente
                        break;
                    }
                }

                if (contattoDaModificare != null) //se il contatto da modificare è stato trovato
                {
                    break; //esci dal ciclo
                }
            }

            if (contattoDaModificare != null) //se il contatto da modificare è stato trovato e non è nullo
            {
                string scelta; //chiedere all'utente cosa vuole modificare
                do
                {
                    Console.Write(
                        "1. Modifica il nome\n2. Modifica il cognome\n3. Modifica un recapito\n4. Modifica il luogo di nascita\n5. Modifica il luogo di residenza\n6. Modifica il luogo di domicilio\n7. Esci\nScegli un'opzione: ");
                    scelta = Console.ReadLine() ?? "";
                    switch (scelta)
                    {
                        case "1":
                            Console.WriteLine("\nIl nome attuale è: " +
                                              contattoDaModificare.Nome); //visualizza il nome attuale
                            Console.Write(
                                "Inserisci il nuovo nome: "); //chiede all'utente il nuovo nome e lo modifica
                            contattoDaModificare.Nome = Console.ReadLine() ?? "";
                            break;
                        case "2":
                            Console.WriteLine("\nIl cognome attuale è: " +
                                              contattoDaModificare.Cognome); //visualizza il cognome attuale
                            Console.Write(
                                "Inserisci il nuovo cognome: "); //chiede all'utente il nuovo cognome e lo modifica
                            contattoDaModificare.Cognome = Console.ReadLine() ?? "";
                            break;
                        case "3":
                            ModificaRecapito(contattoDaModificare); //link al metodo ModificaRecapito
                            break;
                        case "4":
                            InserimentoLuogo(contattoDaModificare, "nascita"); //link al metodo InserimentoLuogo
                            break;
                        case "5":
                            InserimentoLuogo(contattoDaModificare, "residenza"); //link al metodo InserimentoLuogo
                            break;
                        case "6":
                            InserimentoLuogo(contattoDaModificare, "domicilio"); //link al metodo InserimentoLuogo
                            break;
                        case "7":
                            break;
                        default:
                            Console.WriteLine("Scelta non valida!");
                            break;
                    }
                } while (scelta != "7"); // finché l'utente non decide di uscire

                Console.WriteLine("Contatto modificato con successo!");
            }
            else
            {
                Console.WriteLine(
                    "Contatto non trovato!"); //se il contatto da modificare non è stato trovato visualizza un messaggio di errore
            }
        }

        private static void ModificaRecapito(Contatto contatto) //funzione per modificare un recapito
        {
            Console.WriteLine("\nDi seguito i recapiti del contatto:");
            foreach (var recapito in contatto.Recapiti)
            {
                Console.WriteLine($"{recapito.Tipo}: {recapito.Valore}");
            }

            string tipo;
            do //ciclo per chiedere il tipo del recapito da modificare
            {
                Console.Write(
                    "Inserisci il tipo del recapito da modificare: "); //chiede all'utente il tipo del recapito da modificare
                tipo = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(tipo)) //se il tipo è vuoto visualizza un messaggio di errore
                {
                    Console.WriteLine("Il tipo non può essere vuoto!");
                }
            } while (string.IsNullOrWhiteSpace(tipo)); // finché l'utente non inserisce un tipo valido

            Recapito? recapitoDaModificare = null; //inizializzazione del recapito da modificare
            foreach (var recapito in contatto.Recapiti)
            {
                if (recapito.Tipo == tipo) //se il tipo del recapito è uguale al tipo da modificare
                {
                    recapitoDaModificare = recapito; //il recapito da modificare è il recapito corrente
                    break;
                }
            }

            if (recapitoDaModificare == null)
            {
                Console.WriteLine("Recapito non trovato!");
                return;
            }

            Console.Write("Cosa vuoi modificare?\n1. Tipo\n2. Valore\nScegli un'opzione:");
            var scelta = Console.ReadLine() ?? "";
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nIl tipo attuale è: " + recapitoDaModificare.Tipo);
                    Console.Write("Inserisci il nuovo tipo: ");
                    recapitoDaModificare.Tipo = Console.ReadLine() ?? "";
                    break;
                case "2":
                    Console.WriteLine("\nIl valore attuale è: " + recapitoDaModificare.Valore);
                    Console.Write("Inserisci il nuovo valore: ");
                    recapitoDaModificare.Valore = Console.ReadLine() ?? "";
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

            Console.WriteLine("Recapito modificato con successo!");

            Console.ReadKey();
        }

        private static void InserimentoEta(Contatto contatto) //funzione per inserire l'età di un contatto
        {
            string input;
            int anno;
            int mese;
            int giorno;

            Console.WriteLine("\nInserimento data di nascita:");
            do
            {
                //ciclo per chiedere l'anno di nascita
                Console.Write("Inserisci anno: ");
                input = Console.ReadLine() ?? "";
            } while (!int.TryParse(input, out anno) || anno < 1); // finché l'utente non inserisce un anno valido

            do
            {
                //ciclo per chiedere il mese di nascita
                Console.Write("Inserisci mese: ");
                input = Console.ReadLine() ?? "";
            } while (!int.TryParse(input, out mese) || mese < 1 ||
                     mese > 12); // finché l'utente non inserisce un mese valido

            do
            {
                //ciclo per chiedere il giorno di nascita
                Console.Write("Inserisci giorno: ");
                input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out giorno) || giorno < 1 ||
                    giorno > DateTime.DaysInMonth(anno,
                        mese)) //se il giorno non è valido per il mese specificato visualizza un messaggio di errore
                {
                    Console.WriteLine("Giorno non valido per il mese specificato. Riprova.");
                }
            } while
                (giorno < 1 ||
                 giorno > DateTime.DaysInMonth(anno,
                     mese)); // finché l'utente non inserisce un giorno valido per il mese specificato

            contatto.DataNascita = new DateTime(anno, mese, giorno);
            contatto.Eta = CalcolaEta(contatto.DataNascita);
        }

        private static int CalcolaEta(DateTime dataNascita) //funzione per calcolare l'età di un contatto
        {
            DateTime oggi = DateTime.Today; //data odierna per calcolare l'età
            int eta = oggi.Year - dataNascita.Year; //calcolo dell'età del contatto
            if (oggi < dataNascita
                    .AddYears(eta)) //se l'età calcolata è maggiore di quella effettiva del contatto decrementa l'età
            {
                eta--;
            }

            return eta; //restituisce l'età calcolata
        }

        private static void
            VisualizzazioneMediaEta(
                List<Contatto> rubrica) //funzione per visualizzare la media delle età dei contatti in rubrica
        {
            double sommaEta = 0; //inizializzazione della somma delle età
            foreach (var contatto in rubrica) //ciclo per sommare le età dei contatti
            {
                sommaEta += contatto.Eta; // Utilizza l'età del contatto 
            }

            double mediaEta = sommaEta / rubrica.Count;
            Console.WriteLine(
                $"La media delle età dei contatti in rubrica è: {mediaEta:N1}"); //visualizza la media delle età dei contatti in rubrica con una cifra decimale
            Console.ReadKey();
        }
    }
}