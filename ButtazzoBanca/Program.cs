using System; // importa la libreria per l'input/output
using System.Collections.Generic; // importa la libreria per le liste

namespace ButtazzoBanca;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto Nella Banca&Bella Inc. !"); // messaggio di benvenuto
        Selezione(); // link al metodo Selezione
    }

    private static void Selezione()
    {
        List<Conto> contiCorrenti = new List<Conto>(); // crea una lista di contatti vuota
        string scelta; // dichiara la variabile scelta che conterrà la scelta dell'utente
        do
        {
            Console.Write(
                "\n1. Crea un nuovo conto\n2. Accedi al conto corrente\n3. Totale in giacenza conti correnti\n4. Totale Denaro Processato In Una Certa Data\n5. Esci\nScelta: ");
            scelta = Console.ReadLine() ?? "";  // chiede all'utente cosa vuole fare e lo inserisce nella variabile scelta che non può essere vuota

            switch (scelta) // esegue un'azione in base alla scelta dell'utente e se la scelta non è valida chiede di nuovo cosa vuole fare
            {
                case "1":
                    Console.WriteLine("\nCreazione di un nuovo conto corrente"); //messaggio di creazione di un nuovo contatto corrente 
                    CreaConto(contiCorrenti); // link al metodo CreaConto con la lista di contatti
                    break;
                case "2":
                    Console.WriteLine("\nAccesso al conto corrente..."); //messaggio di accesso al contatto corrente 
                    Accedi(contiCorrenti); // link al metodo Accedi con la lista di contatti
                    break;
                case "3":
                    Console.WriteLine("\nTotale in giacenza conti correnti"); //messaggio di visualizzazione del totale in giacenza dei contatti correnti
                    TotaleDenaroInGiacenza(contiCorrenti); // link al metodo TotaleDenaroInGiacenza con la lista di contatti
                    break;
                case "4":
                    Console.WriteLine("\nTotale Denaro Processato In Una Certa Data"); //messaggio di visualizzazione del totale dei movimenti in una certa data
                    TotaleDenaroCertaData(contiCorrenti); // link al metodo TotaleDenaroCertaData con la lista di contatti
                    break;
                case "5":
                    Console.WriteLine("\nGrazie Per Aver Usato La nostra Banca, ADDIO!"); //messaggio di uscita
                    break;
                default:
                    Console.WriteLine("\nScelta non valida!"); //messaggio di scelta non valida
                    Selezione();
                    break;
            }
        } while (scelta != "5"); // esegue il ciclo finché la scelta dell'utente non è 5
    }

    private static void CreaConto(List<Conto> contiCorrenti) // metodo per creare un contatto con la lista di contatti come parametro di input 
    {
        string nome; // dichiara la variabile nome che conterrà il nome del contatto 
        do
        { // chiede il nome e lo inserisce nella variabile nome che non può essere vuota 
            Console.Write("Nome: ");
            nome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Il nome non puó essere vuoto!");
            }
        } while (string.IsNullOrWhiteSpace(nome)); // esegue il ciclo finché il nome è vuoto 

        string cognome; // dichiara la variabile cognome che conterrà il cognome del contatto
        do
        { // chiede il cognome e lo inserisce nella variabile cognome che non può essere vuota 
            Console.Write("Cognome: ");
            cognome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(cognome))
            {
                Console.WriteLine("Il cognome non puó essere vuoto");
            }
        } while (string.IsNullOrWhiteSpace(cognome)); // esegue il ciclo finché il cognome è vuoto

        string codiceFiscale; // dichiara la variabile codiceFiscale che conterrà il codice fiscale del contatto
        do
        { // chiede il codice fiscale e lo inserisce nella variabile codiceFiscale che non può essere vuota e deve essere di 16 caratteri
            Console.Write("Codice Fiscale: ");
            codiceFiscale = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(codiceFiscale)) // se il codice fiscale è vuoto stampa un messaggio di errore
            {
                Console.WriteLine("Il codice fiscale non puó essere vuoto!");
            }
            else if (codiceFiscale.Length != 16) // se il codice fiscale non è di 16 caratteri stampa un messaggio di errore
            {
                Console.WriteLine("Il codice fiscale deve essere di 16 caratteri!");
            }
        } while (string.IsNullOrWhiteSpace(codiceFiscale) || codiceFiscale.Length != 16); // esegue il ciclo finché il codice fiscale è vuoto o non è di 16 caratteri

        string codiceConto = GenerazioneCodici("Conto Corrente"); // genera un codice conto corrente con il metodo GenerazioneCodici e lo inserisce nella variabile codiceConto
        string pin = GenerazioneCodici("Pin"); // genera un pin con il metodo GenerazioneCodici e lo inserisce nella variabile pin

        Conto conto = new Conto(nome, cognome, codiceFiscale, codiceConto, pin); // crea un nuovo contatto con i dati inseriti dall'utente 

        Console.WriteLine("Inserimento di altri dati anagrafici, cosa vuoi fare?"); // messaggio di inserimento di altri dati anagrafici 
        string scelta; // dichiara la variabile scelta che conterrà la scelta dell'utente 
        do
        {
            Console.Write(
                "1. Inserisci un luogo di nascita\n2. Inserisci un luogo di residenza\n3. Inserisci un luogo di domicilio\n4. Nulla\nScegli un'opzione: "); // chiede all'utente cosa vuole fare con il contatto appena creato
            scelta = Console.ReadLine() ?? ""; // inserisce la scelta dell'utente nella variabile scelta che non può essere vuota
            switch (scelta) // esegue un'azione in base alla scelta dell'utente e se la scelta non è valida chiede di nuovo cosa vuole fare
            {
                case "1":
                    InserimentoLuogo(conto, "nascita"); //link al metodo InserimentoLuogo
                    break;
                case "2":
                    InserimentoLuogo(conto, "residenza"); //link al metodo InserimentoLuogo
                    break;
                case "3":
                    InserimentoLuogo(conto, "domicilio"); //link al metodo InserimentoLuogo
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        } while (scelta != "4"); // esegue il ciclo finché la scelta dell'utente non è 4

        contiCorrenti.Add(conto); // aggiunge l'utenza alla lista di conti correnti

        Console.WriteLine($"Il codice del conto corrente é: {codiceConto}, ricordalo!"); // stampa il codice del conto corrente 
        Console.WriteLine($"Il pin del conto corrente é: {pin}, ricordalo!"); // stampa il pin del conto corrente
        
        PremiUnTastoPerContinuare(); // link al metodo PremiUnTastoPerContinuare 

        Console.WriteLine("Conto creato con successo!"); // messaggio di contatto creato con successo
    }

    private static string GenerazioneCodici(string tipo) // metodo per generare codici conto corrente e pin con il tipo come parametro di input
    {
        Random random = new Random(); // crea un oggetto random per generare numeri casuali 
        string codice = ""; // dichiara la variabile codice che conterrà il codice generato 

        if (tipo == "Conto Corrente") // se il tipo è conto corrente genera un codice di 10 cifre 
        {
            for (int i = 0; i < 10; i++) // esegue il ciclo 10 volte per generare un codice di 10 cifre 
            {
                codice += random.Next(0, 9); // aggiunge un numero casuale tra 0 e 9 al codice 
            }
        }
        else if (tipo == "Pin") // se il tipo è pin genera un pin di 5 cifre 
        {
            for (int i = 0; i < 5; i++) // esegue il ciclo 5 volte per generare un pin di 5 cifre
            {
                codice += random.Next(0, 9); // aggiunge un numero casuale tra 0 e 9 al pin 
            }
        }
        else // se il tipo non è valido stampa un messaggio di errore
        {
            Console.WriteLine("Tipo non valido!"); 
        }

        return codice; // ritorna il codice generato 
    }

    private static void InserimentoLuogo(Conto conto, string tipo) // metodo per inserire un luogo con il contatto e il tipo come parametri di input
    {
        Console.Write(
            "Inserisci l'indirizzo (facoltativo): "); // chiede l'indirizzo e lo inserisce nel luogo del contatto
        var indirizzo = Console.ReadLine() ?? ""; // se l'indirizzo è vuoto lo inizializza come stringa vuota

        Console.Write("Inserisci il CAP (facoltativo): "); // chiede il CAP e lo inserisce nel luogo del contatto
        var cap = Console.ReadLine() ?? ""; // se il CAP è vuoto lo inizializza come stringa vuota

        string citta;
        do // chiede la città e la inserisce nel luogo del contatto che non può essere vuota
        {
            Console.Write("Inserisci la città: ");
            citta = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(citta))
            {
                Console.WriteLine("La città non può essere vuota!");
            }
        } while (string.IsNullOrWhiteSpace(citta)); // esegue il ciclo finché la città è vuota 

        string provincia;
        do // chiede la provincia e la inserisce nel luogo del contatto che non può essere vuota
        {
            Console.Write("Inserisci la provincia: ");
            provincia = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(provincia))
            {
                Console.WriteLine("La provincia non può essere vuota!");
            }
        } while (string.IsNullOrWhiteSpace(provincia)); // esegue il ciclo finché la provincia è vuota

        var nuovoLuogo =
            new Luogo(citta, provincia, indirizzo, cap); // crea un nuovo luogo con i dati inseriti dall'utente
        switch (tipo) // inserisce il luogo nel contatto in base al tipo
        {
            case "nascita":
                conto.LuogoNascita = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                break;
            case "residenza":
                conto.LuogoResidenza = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                break;
            case "domicilio":
                conto.LuogoDomicilio = nuovoLuogo; // inserisce il luogo nel contatto in base al tipo
                break;
        }
    }

    private static void Accedi(List<Conto> contiCorrenti) // metodo per accedere a un contatto con la lista di contatti come parametro di input
    {
        string codiceConto; // dichiara la variabile codiceConto che conterrà il codice del contatto
        do 
        { // chiede il codice del contatto e lo inserisce nella variabile codiceConto che non può essere vuota
            Console.Write("Inserisci il codice del conto corrente: ");
            codiceConto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(codiceConto))
            {
                Console.WriteLine("Il codice del conto non puó essere vuoto!");
            }
        } while (string.IsNullOrWhiteSpace(codiceConto)); // esegue il ciclo finché il codice del contatto è vuoto

        string pin; // dichiara la variabile pin che conterrà il pin del contatto
        do
        { // chiede il pin del contatto e lo inserisce nella variabile pin che non può essere vuota e deve essere di 5 cifre
            Console.Write("Inserisci il pin del conto corrente: ");
            pin = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(pin) || pin.Length != 5)
            {
                Console.WriteLine("Il pin non puó essere vuoto! Deve essere di 5 cifre!");
            }
        } while (string.IsNullOrWhiteSpace(pin) || pin.Length != 5); // esegue il ciclo finché il pin del contatto è vuoto o non è di 5 cifre

        Conto? conto = null; // dichiara la variabile conto che conterrà il contatto a cui si vuole accedere
        foreach (var contoCorrente in contiCorrenti) // cerca il contatto con il codice e il pin inseriti dall'utente
        {
            if (contoCorrente.CodiceConto == codiceConto && contoCorrente.Pin == pin) // controllo se il codice e il pin sono corretti
            {
                conto = contoCorrente;  // se il codice e il pin sono corretti assegna il contatto alla variabile conto
                break;
            }
        }
        if (conto == null) // se il contatto non è stato trovato stampa un messaggio di errore
        {
            Console.WriteLine("Conto non trovato!");
            return;
        }

        BenvenutoContatto(conto); // link al metodo BenvenutoContatto con il contatto come parametro di input 

        PremiUnTastoPerContinuare(); // link al metodo PremiUnTastoPerContinuare

        string scelta; // dichiara la variabile scelta che conterrà la scelta dell'utente
        decimal saldo = 0; // dichiara la variabile saldo che conterrà il saldo del contatto
        do
        { // chiede all'utente cosa vuole fare con il contatto e lo inserisce nella variabile scelta che non può essere vuota
            Console.Write(
                "\nCosa Vuoi Fare?\n1. Effettuare un deposito\n2. Effettuare un prelievo\n3. Visualizzare i movimenti\n4. Visualizza il tuo saldo\n5. Esci dal sottomenu\nScegli un'opzione: "); // chiede all'utente cosa vuole fare con il contatto
            scelta = Console.ReadLine() ?? ""; // inserisce la scelta dell'utente nella variabile scelta che non può essere vuota
            switch (scelta)
            {
                case "1":
                    FaiOperazione(conto, ref saldo, '+'); // link al metodo FaiOperazione con il contatto, il saldo e il tipo di operazione come parametri di input
                    break;
                case "2":
                    FaiOperazione(conto, ref saldo, '-'); // link al metodo FaiOperazione con il contatto, il saldo e il tipo di operazione come parametri di input

                    break;
                case "3":
                    Console.WriteLine("Movimenti:");
                    foreach (Movimento movimento in conto.Movimenti) //ciclo che va da un movimento all'altro del contatto nel conto
                    {
                        Console.WriteLine(
                            $"Data: {movimento.Data}, Tipo: {movimento.Tipo}, Importo: {movimento.Importo}"); // visualizza i movimenti del contatto
                    }

                    break;
                case "4":
                    Console.WriteLine($"Il tuo saldo è {saldo} euro"); // visualizza il saldo del contatto
                    break;
                case "5":
                    Console.WriteLine("Ciao Ciao"); // messaggio di uscita dal sottomenu
                    break;
                default:
                    Console.WriteLine("Scelta non valida!"); // messaggio di scelta non valida
                    break;
            }

            PremiUnTastoPerContinuare(); // link al metodo PremiUnTastoPerContinuare
        } while (scelta != "5"); // esegue il ciclo finché la scelta dell'utente non è 5
    }

    private static void BenvenutoContatto(Conto conto) // metodo per dare il benvenuto al contatto con il contatto come parametro di input
    {
        Console.WriteLine(
            $"\nBenvenuto {conto.Nome} {conto.Cognome}!\nCodice Fiscale: {conto.CodiceFiscale}\nCodice Conto: {conto.CodiceConto}");
        if (conto.LuogoNascita != null) // visualizzare il luogo di nascita se presente
        {
            Console.WriteLine(
                $"Luogo di nascita: {conto.LuogoNascita.Indirizzo} {conto.LuogoNascita.Cap} {conto.LuogoNascita.Citta} ({conto.LuogoNascita.Provincia})");
        }

        if (conto.LuogoResidenza != null) // visualizzare il luogo di residenza se presente
        {
            Console.WriteLine(
                $"Luogo di residenza: {conto.LuogoResidenza.Indirizzo} {conto.LuogoResidenza.Cap} {conto.LuogoResidenza.Citta} ({conto.LuogoResidenza.Provincia})");
        }

        if (conto.LuogoDomicilio != null) // visualizzare il luogo di domicilio se presente
        {
            Console.WriteLine(
                $"Luogo di domicilio: {conto.LuogoDomicilio.Indirizzo} {conto.LuogoDomicilio.Cap} {conto.LuogoDomicilio.Citta} ({conto.LuogoDomicilio.Provincia})");
        }
    }

    private static void FaiOperazione(Conto conto, ref decimal saldo, char operazione) // metodo per fare un'operazione con il contatto, il saldo e il tipo di operazione come parametri di input
    {
        if (operazione == '-') // se l'operazione è un prelievo
        {
            decimal importoPrelievo; // dichiara la variabile importoPrelievo che conterrà l'importo del prelievo
            do
            { // chiede l'importo del prelievo e lo inserisce nella variabile importoPrelievo che deve essere maggiore di 0
                do
                { // chiede l'importo del prelievo e lo inserisce nella variabile importoPrelievo che deve essere maggiore di 0
                    Console.Write("Inserisci l'importo del prelievo: ");
                    importoPrelievo = decimal.TryParse(Console.ReadLine(), out decimal result) ? result : 0; // se l'importo del prelievo non è un numero lo inizializza a 0
                    if (importoPrelievo <= 0)
                    {
                        Console.WriteLine("L'importo del prelievo deve essere maggiore di 0!");
                    }
                } while (importoPrelievo <= 0); // esegue il ciclo finché l'importo del prelievo è minore o uguale a 0
                if ((saldo - importoPrelievo) < 0) // se il saldo è minore dell'importo del prelievo stampa un messaggio di errore
                {
                    Console.WriteLine("Non puoi prelevare più di quanto hai sul conto!"); // messaggio di errore
                }
                else if ((saldo - importoPrelievo) >= 0) // se il saldo è maggiore o uguale all'importo del prelievo
                {
                    saldo -= importoPrelievo; // sottrae l'importo del prelievo dal saldo
                    conto.Movimenti.Add(new Movimento(importoPrelievo, "Prelievo")); // aggiunge il movimento al contatto
                    Console.WriteLine(
                        $"Hai prelevato {importoPrelievo} euro con successo! e il tuo saldo è {saldo} euro"); // messaggio di prelievo effettuato con successo
                }
            } while ((saldo - importoPrelievo) < 0); // esegue il ciclo finché il saldo è minore dell'importo del prelievo
        }
        else if (operazione == '+') // se l'operazione è un deposito
        {
            decimal importoDeposito; // dichiara la variabile importoDeposito che conterrà l'importo del deposito
            do 
            { // chiede l'importo del deposito e lo inserisce nella variabile importoDeposito che deve essere maggiore di 0
                do
                { // chiede l'importo del deposito e lo inserisce nella variabile importoDeposito che deve essere maggiore di 0
                    Console.Write("Inserisci l'importo del deposito: ");
                    importoDeposito = decimal.TryParse(Console.ReadLine(), out decimal result) ? result : 0; // se l'importo del deposito non è un numero lo inizializza a 0
                    if (importoDeposito <= 0)
                    {
                        Console.WriteLine("L'importo del deposito deve essere maggiore di 0!"); // messaggio di errore se l'importo del deposito è minore o uguale a 0
                    }
                } while (importoDeposito <= 0); // esegue il ciclo finché l'importo del deposito è minore o uguale a 0
                conto.Movimenti.Add(new Movimento(importoDeposito, "Deposito")); // aggiunge il movimento al contatto
                saldo += importoDeposito; // aggiunge l'importo del deposito al saldo
                Console.WriteLine($"Hai depositato {importoDeposito} euro con successo! e il tuo saldo è {saldo} euro"); // messaggio di deposito effettuato con successo
            } while (importoDeposito <= 0); // esegue il ciclo finché l'importo del deposito è minore o uguale a 0
        }
    }

    private static void TotaleDenaroInGiacenza(List<Conto> contiCorrenti) // metodo per visualizzare il totale in giacenza dei contatti con la lista di contatti come parametro di input
    {
        decimal totale = 0; // dichiara la variabile totale che conterrà il totale in giacenza dei contatti
        foreach (Conto conto in contiCorrenti) // calcola il totale in giacenza dei contatti
        {
            foreach (Movimento movimento in conto.Movimenti) //ciclo per scorrere i movimenti dei contatti
            {
                if (movimento.Tipo == "Deposito") // se il movimento è un deposito aggiunge l'importo al totale
                {
                    totale += movimento.Importo;
                }
                else if (movimento.Tipo == "Prelievo") // se il movimento è un prelievo sottrae l'importo al totale
                {
                    totale -= movimento.Importo;
                }
            }
        }

        Console.WriteLine($"Il totale in giacenza dei conti correnti è {totale} euro"); // visualizza il totale in giacenza dei contatti
        PremiUnTastoPerContinuare(); // link al metodo PremiUnTastoPerContinuare
    }

    private static void TotaleDenaroCertaData(List<Conto> contiCorrenti) // metodo per visualizzare il totale dei movimenti in una certa data con la lista di contatti come parametro di input
    {
        string data; // dichiara la variabile data che conterrà la data
        do 
        { // chiede la data e la inserisce nella variabile data che non può essere vuota
            Console.Write("Inserisci la data (dd/MM/yyyy): "); // chiede la data all'utente in formato gg/MM/aaaa
            data = Console.ReadLine() ?? ""; // se la data è vuota la inizializza come stringa vuota
            if (string.IsNullOrWhiteSpace(data)) // se la data è vuota stampa un messaggio di errore
            {
                Console.WriteLine("La data non può essere vuota!"); 
            }
        } while (string.IsNullOrWhiteSpace(data)); // esegue il ciclo finché la data è vuota

        decimal totale = 0; // dichiara la variabile totale che conterrà il totale dei movimenti in una certa data
        foreach (Conto conto in contiCorrenti) // calcola il totale dei movimenti in una certa data
        {
            foreach (Movimento movimento in conto.Movimenti) //ciclo per scorrere i movimenti dei contatti
            {
                if (movimento.Data.ToString("dd/MM/yyyy") == data) // se la data del movimento è uguale alla data inserita dall'utente calcola il totale
                {
                    if (movimento.Tipo == "Deposito")  // se il movimento è un deposito aggiunge l'importo al totale
                    {
                        totale += movimento.Importo;
                    }
                    else if (movimento.Tipo == "Prelievo") // se il movimento è un prelievo sottrae l'importo al totale
                    {
                        totale -= movimento.Importo;
                    }
                }
            }
        }

        Console.WriteLine($"Il totale dei movimenti in data {data} è {totale} euro"); // visualizza il totale dei movimenti in una certa data
        PremiUnTastoPerContinuare(); // link al metodo PremiUnTastoPerContinuare
    }

    private static void PremiUnTastoPerContinuare() // metodo per chiedere all'utente di premere un tasto per continuare
    {
        Console.WriteLine("Premi un tasto per continuare..."); // messaggio per chiedere all'utente di premere un tasto per continuare
        Console.ReadKey(); // aspetta che l'utente prema un tasto per continuare
    }
}