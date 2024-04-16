using System;
using System.Collections.Generic;

namespace ButtazzoBanca;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto Nella Banca&Bella Inc. !");
        Selezione();
    }

    private static void Selezione()
    {
        List<Conto> contiCorrenti = new List<Conto>();
        string scelta;
        do
        {
            Console.Write(
                "\n1. Crea un nuovo conto\n2. Accedi al conto corrente\n3. Totale in giacenza conti correnti\n4. Totale Denaro Processato In Una Certa Data\n5. Esci\nScelta: ");
            scelta = Console.ReadLine() ?? "";

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nCreazione di un nuovo conto corrente");
                    CreaConto(contiCorrenti);
                    break;
                case "2":
                    Console.WriteLine("\nAccesso al conto corrente...");
                    Accedi(contiCorrenti);
                    break;
                case "3":
                    Console.WriteLine("\nTotale in giacenza conti correnti");
                    TotaleDenaroInGiacenza(contiCorrenti);
                    break;
                case "4":
                    Console.WriteLine("\nTotale Denaro Processato In Una Certa Data");
                    TotaleDenaroCertaData(contiCorrenti);
                    break;
                case "5":
                    Console.WriteLine("\nGrazie Per Aver Usato La nostra Banca, ADDIO!");
                    break;
                default:
                    Console.WriteLine("\nScelta non valida!");
                    Selezione();
                    break;
            }
        } while (scelta != "5");
    }

    private static void CreaConto(List<Conto> contiCorrenti)
    {
        string nome;
        do
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Il nome non puó essere vuoto!");
            }
        } while (string.IsNullOrWhiteSpace(nome));

        string cognome;
        do
        {
            Console.Write("Cognome: ");
            cognome = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(cognome))
            {
                Console.WriteLine("Il cognome non puó essere vuoto");
            }
        } while (string.IsNullOrWhiteSpace(cognome));

        string codiceFiscale;
        do
        {
            Console.Write("Codice Fiscale: ");
            codiceFiscale = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(codiceFiscale) || codiceFiscale.Length != 16)
            {
                Console.WriteLine("Il codice fiscale non puó essere vuoto! Deve essere di 16 caratteri!");
            }
        } while (string.IsNullOrWhiteSpace(codiceFiscale) || codiceFiscale.Length != 16);

        string codiceConto = GenerazioneCodici("Conto Corrente");
        string pin = GenerazioneCodici("Pin");

        Conto conto = new Conto(nome, cognome, codiceFiscale, codiceConto, pin);

        Console.WriteLine("Inserimento di altri dati anagrafici, cosa vuoi fare?");
        string scelta;
        do
        {
            Console.Write(
                "1. Inserisci un luogo di nascita\n2. Inserisci un luogo di residenza\n3. Inserisci un luogo di domicilio\n4. Nulla\nScegli un'opzione: "); // chiede all'utente cosa vuole fare con il contatto appena creato
            scelta = Console.ReadLine() ?? "";
            switch (scelta)
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
        } while (scelta != "4");

        contiCorrenti.Add(conto);

        Console.WriteLine($"Il codice del conto corrente é: {codiceConto}, ricordalo!");
        Console.WriteLine($"Il pin del conto corrente é: {pin}, ricordalo!");

        PremiUnTastoPerContinuare();

        Console.WriteLine("Conto creato con successo!");
    }

    private static string GenerazioneCodici(string tipo)
    {
        Random random = new Random();
        string codice = "";

        if (tipo == "Conto Corrente")
        {
            for (int i = 0; i < 10; i++)
            {
                codice += random.Next(0, 9);
            }
        }
        else if (tipo == "Pin")
        {
            for (int i = 0; i < 5; i++)
            {
                codice += random.Next(0, 9);
            }
        }
        else
        {
            Console.WriteLine("Tipo non valido!");
        }

        return codice;
    }

    private static void InserimentoLuogo(Conto conto, string tipo)
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

    private static void Accedi(List<Conto> contiCorrenti)
    {
        string codiceConto;
        do
        {
            Console.Write("Inserisci il codice del conto corrente: ");
            codiceConto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(codiceConto))
            {
                Console.WriteLine("Il codice del conto non puó essere vuoto!");
            }
        } while (string.IsNullOrWhiteSpace(codiceConto));

        string pin;
        do
        {
            Console.Write("Inserisci il pin del conto corrente: ");
            pin = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(pin) || pin.Length != 5)
            {
                Console.WriteLine("Il pin non puó essere vuoto! Deve essere di 5 cifre!");
            }
        } while (string.IsNullOrWhiteSpace(pin) || pin.Length != 5);

        Conto? conto = contiCorrenti.Find(c => c.CodiceConto == codiceConto && c.Pin == pin);
        if (conto == null)
        {
            Console.WriteLine("Conto non trovato!");
            return;
        }

        BenvenutoContatto(conto);

        PremiUnTastoPerContinuare();

        string scelta;
        decimal saldo = 0;
        do
        {
            Console.Write(
                "\nCosa Vuoi Fare?\n1. Effettuare un deposito\n2. Effettuare un prelievo\n3. Visualizzare i movimenti\n4. Visualizza il tuo saldo\n5. Esci dal sottomenu\nScegli un'opzione: ");
            scelta = Console.ReadLine() ?? "";
            switch (scelta)
            {
                case "1":
                    FaiOperazione(conto, ref saldo, '+');
                    break;
                case "2":
                    FaiOperazione(conto, ref saldo, '-');

                    break;
                case "3":
                    Console.WriteLine("Movimenti:");
                    foreach (Movimento movimento in conto.Movimenti)
                    {
                        Console.WriteLine(
                            $"Data: {movimento.Data}, Tipo: {movimento.Tipo}, Importo: {movimento.Importo}");
                    }

                    break;
                case "4":
                    Console.WriteLine($"Il tuo saldo è {saldo} euro");
                    break;
                case "5":
                    Console.WriteLine("Ciao Ciao");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

            PremiUnTastoPerContinuare();
        } while (scelta != "5");
    }

    private static void BenvenutoContatto(Conto conto)
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

    private static void FaiOperazione(Conto conto, ref decimal saldo, char operazione)
    {
        if (operazione == '-')
        {
            decimal importoPrelievo;
            do
            {
                Console.Write("Inserisci l'importo del prelievo: ");
                importoPrelievo = decimal.Parse(Console.ReadLine() ?? "");
                if ((saldo - importoPrelievo) < 0)
                {
                    Console.WriteLine("Non puoi prelevare più di quanto hai sul conto!");
                }
                else if ((saldo - importoPrelievo) >= 0)
                {
                    saldo -= importoPrelievo;
                    conto.Movimenti.Add(new Movimento(importoPrelievo, "Prelievo"));
                    Console.WriteLine(
                        $"Hai prelevato {importoPrelievo} euro con successo! e il tuo saldo è {saldo} euro");
                }
            } while ((saldo - importoPrelievo) < 0);
        }
        else if (operazione == '+')
        {
            decimal importoDeposito;
            do
            {
                Console.Write("Inserisci l'importo del deposito: ");
                importoDeposito = decimal.Parse(Console.ReadLine() ?? "");
                conto.Movimenti.Add(new Movimento(importoDeposito, "Deposito"));
                saldo += importoDeposito;
                Console.WriteLine($"Hai depositato {importoDeposito} euro con successo! e il tuo saldo è {saldo} euro");
            } while (importoDeposito <= 0);
        }
    }

    private static void TotaleDenaroInGiacenza(List<Conto> contiCorrenti)
    {
        decimal totale = 0;
        foreach (Conto conto in contiCorrenti)
        {
            foreach (Movimento movimento in conto.Movimenti)
            {
                if (movimento.Tipo == "Deposito")
                {
                    totale += movimento.Importo;
                }
                else if (movimento.Tipo == "Prelievo")
                {
                    totale -= movimento.Importo;
                }
            }
        }

        Console.WriteLine($"Il totale in giacenza dei conti correnti è {totale} euro");
        PremiUnTastoPerContinuare();
    }

    private static void TotaleDenaroCertaData(List<Conto> contiCorrenti)
    {
        string data;
        do
        {
            Console.Write("Inserisci la data (dd/MM/yyyy): ");
            data = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("La data non può essere vuota!");
            }
        } while (string.IsNullOrWhiteSpace(data));

        decimal totale = 0;
        foreach (Conto conto in contiCorrenti)
        {
            foreach (Movimento movimento in conto.Movimenti)
            {
                if (movimento.Data.ToString("dd/MM/yyyy") == data)
                {
                    if (movimento.Tipo == "Deposito")
                    {
                        totale += movimento.Importo;
                    }
                    else if (movimento.Tipo == "Prelievo")
                    {
                        totale -= movimento.Importo;
                    }
                }
            }
        }

        Console.WriteLine($"Il totale dei movimenti in data {data} è {totale} euro");
        PremiUnTastoPerContinuare();
    }

    private static void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}