namespace demo;

public class Program
{
    public static void Main(string[] args)
    {
        // int numero = 10;
        // decimal nDecimale = 10.5M;
        // string parola = "Ciao";
        // bool vero = true;

        Console.WriteLine("Inserisci una parola");
        var digitato = Console.ReadLine() ?? "Sconosciuto"; // null coalescing operator
        /* if (String.IsNullOrEmpty(digitato))
        {
            Console.WriteLine("Non hai inserito nulla");
        }
        else
        {
            Console.WriteLine("Hai inserito: " + digitato);
        } */
        // Console.Write("Ehi, ");
        // Console.WriteLine("hai inserito: " + digitato);
        Console.WriteLine($"Hai inserito: {digitato}"); // interpolazione di stringhe
        var nomeMaiuscolo = digitato.ToUpper(); // inferenza di tipo, funziona solo se ha un valore
        Console.WriteLine(nomeMaiuscolo);
        string[] nomi =
        {
            "Mario",
            "Luigi",
            "Peach",
            "Toad"
        }; // array di stringhe, la lunghezza è fissa

        if (nomi.Contains("Mario")) Console.WriteLine("C'è");

        foreach (var nome in nomi)
        {
            Console.WriteLine(nome);
            foreach (var lettera in nome) Console.WriteLine(lettera);
        }

        var num = 34.536M;
        Console.WriteLine(num.ToString("N2")); // customizzare formato valore numerico
        Console.WriteLine(5 / 10);
    }
}