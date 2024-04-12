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
    internal class Program
    {
        static void Main()
        {
            // tutta la logica è in un metodo separato dal Main
            Esempio();
        }

        static void Esempio()
        {
            // far scegliere all'utente l'azione da compiere
            Console.WriteLine("blabla...");

            List<Contatto> rubrica = new List<Contatto>();

            // chiedere all'utente il nome, il cognome e il numero da inserire gestendo eventuali errori

            Contatto nuovoContatto = new Contatto("3312645678", "Silvio", "Albi");
            Recapito recapitoProva = new Recapito("0832645678", "Casa");
            nuovoContatto.Recapiti.Add(recapitoProva);
            //nuovoContatto.Nome = "Silvio";
            //nuovoContatto.Cognome = "Albi";
            //nuovoContatto.Numero = "3312645678";

            Luogo luogoNuovoContatto = new Luogo();
            luogoNuovoContatto.Indirizzo = "Corso Roma 1";
            luogoNuovoContatto.Cap = "73100";
            luogoNuovoContatto.Citta = "Lecce";
            luogoNuovoContatto.Provincia = "Lecce";
            nuovoContatto.LuogoNascita = luogoNuovoContatto;

            nuovoContatto.LuogoNascita = new Luogo()
            {
                Indirizzo = "Corso Roma 1",
                Cap = "73100",
                Citta = "Lecce",
                Provincia = "Lecce"
            };

            nuovoContatto.LuogoResidenza = new Luogo()
            {
                Indirizzo = "Corso Roma 1",
                Cap = "73100",
                Citta = "Lecce",
                Provincia = "Lecce"
            };

            rubrica.Add(nuovoContatto);

            Contatto nuovoContattoDue = new Contatto("3482654267", "Salvatore", "Saracino");
            //nuovoContattoDue.Nome = "Salvatore";
            //nuovoContattoDue.Cognome = "Saracino";
            //nuovoContattoDue.Numero = "3482654267";

            rubrica.Add(nuovoContattoDue);

            Contatto nuovoContattoTre = new Contatto("3331123456");

            rubrica.Add(nuovoContattoTre);

            // visualizzare i contatti in rubrica
            foreach (Contatto contatto in rubrica)
            {
                Console.WriteLine($"Nome: {contatto.Nome}");
                Console.WriteLine($"Cognome: {contatto.Cognome}");
                foreach (Recapito recapito in contatto.Recapiti)
                {
                    Console.WriteLine($"{recapito.Tipo}: {recapito.Valore}");
                }
                if (contatto.LuogoNascita != null)
                {
                    Console.WriteLine($"Luogo di nascita: {contatto.LuogoNascita.Indirizzo} {contatto.LuogoNascita.Cap} {contatto.LuogoNascita.Citta} ({contatto.LuogoNascita.Provincia})");
                }
                Console.WriteLine("-----------------------------");
            }
        }
    }
}