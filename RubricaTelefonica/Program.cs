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
                "Seleziona l'operazione desiderata:\nA/a. Aggiungi\nR/r. Rimuovi\nV/v. Visualizza\nM/m. Modifica\nE/e. Esci\nScelta: "); // Menu di selezione

            continua = SceltaOperazione(Console.ReadLine()?.ToUpper() ?? "", rubrica);
        }
    }

    private static bool SceltaOperazione(string operazione, List<Contatto> rubrica)
    {
        switch (operazione)
        {
            case "A":
                Console.WriteLine("\nSei nell'aggiungi");
                AggiungiContatto(rubrica);
                break;
            case "R":
                Console.WriteLine("\nSei nel rimuovi");
                RimuoviContatto(rubrica);
                break;
            case "V":
                Console.WriteLine("\nSei nel visualizza");
                VisualizzaContatto(rubrica);
                break;
            case "M":
                Console.WriteLine("\nSei nel modifica");
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
        Console.Write("Inserisci il nome: ");
        var nome = Console.ReadLine() ?? "";
        Console.Write("Inserisci il cognome: ");
        var cognome = Console.ReadLine() ?? "";
        Console.Write("Inserisci il numero di telefono: ");
        var numeroDiTelefono = Console.ReadLine() ?? "";

        Contatto nuovoContatto = new Contatto(nome, cognome, numeroDiTelefono);
        rubrica.Add(nuovoContatto);

        Console.WriteLine("\nContatto aggiunto con successo!");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void RimuoviContatto(List<Contatto> rubrica)
    {
        var continua = true;
        do
        {
            Console.Write("Inserisci il numero di telefono del contatto da rimuovere: ");
            var numeroDiTelefono = Console.ReadLine();

            var contattoDaRimuovere = rubrica.FirstOrDefault(c => c.NumeroDiTelefono == numeroDiTelefono);
            if (contattoDaRimuovere == null)
            {
                Console.WriteLine("Contatto non trovato.");
                return;
            }

            Console.Write(
                $"\nHo Trovato =\nNome: {contattoDaRimuovere.Nome} \nCognome: {contattoDaRimuovere.Cognome} \nNumero di telefono: {contattoDaRimuovere.NumeroDiTelefono}\nStai per eliminare questo contatto. Sei sicuro? (S-s/N-n)");
            var conferma = Console.ReadLine()?.ToUpper() ?? "";

            if (conferma != "S")
            {
                Console.WriteLine("Operazione annullata.");
                return;
            }

            rubrica.Remove(contattoDaRimuovere);

            Console.Write("Vuoi rimuovere un altro contatto? (S-s/N-n): ");
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
        foreach (var contatto in rubrica)
        {
            Console.WriteLine(
                $"Nome: {contatto.Nome} \nCognome: {contatto.Cognome} \nNumero di telefono: {contatto.NumeroDiTelefono} \n -----------------");
        }

        Console.WriteLine("\nPremi un tasto per continuare...");
        Console.ReadKey();
    }

    private static void ModificaContatto(List<Contatto> rubrica)
    {
        Console.Write("Inserisci il numero di telefono del contatto da modificare: ");
        var numeroDiTelefono = Console.ReadLine();

        var contattoDaModificare = rubrica.FirstOrDefault(c => c.NumeroDiTelefono == numeroDiTelefono);

        if (contattoDaModificare == null)
        {
            Console.WriteLine("Contatto non trovato.");
            return;
        }

        Console.Write("Inserisci il nuovo nome: ");
        contattoDaModificare.Nome = Console.ReadLine() ?? "";
        Console.Write("Inserisci il nuovo cognome: ");
        contattoDaModificare.Cognome = Console.ReadLine() ?? "";
        Console.Write("Inserisci il nuovo numero di telefono: ");
        contattoDaModificare.NumeroDiTelefono = Console.ReadLine() ?? "";

        Console.WriteLine("\nContatto modificato con successo!");
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}