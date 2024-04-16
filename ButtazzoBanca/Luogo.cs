namespace ButtazzoBanca
{
    internal class Luogo
    {
        internal Luogo(string citta, string provincia, string indirizzo = "Non Presente", string cap = "Non Presente") // Costruttore di default con parametri inizializzati a "Non Presente"
        {
            this.Indirizzo = indirizzo; // Assegnazione dell'indirizzo passato come parametro al costruttore
            this.Cap = cap; // Assegnazione del cap passato come parametro al costruttore
            this.Citta = citta; // Assegnazione della città passata come parametro al costruttore
            this.Provincia = provincia; // Assegnazione della provincia passata come parametro al costruttore
        }

        internal string Indirizzo { get; set; } // Proprietà Indirizzo della classe Luogo
        internal string Cap { get; set; } // Proprietà Cap della classe Luogo
        internal string Citta { get; set; } // Proprietà Citta della classe Luogo
        internal string Provincia { get; set; } // Proprietà Provincia della classe Luogo
    }
}