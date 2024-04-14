namespace RubricaBotrugnana
{
    internal class Luogo
    {
        internal Luogo(string citta, string provincia, string indirizzo = "Non Presente", string cap = "Non Presente")
        {
            this.Indirizzo = indirizzo;
            this.Cap = cap;
            this.Citta = citta;
            this.Provincia = provincia;
        }

        internal string Indirizzo { get; set; }
        internal string Cap { get; set; }
        internal string Citta { get; set; }
        internal string Provincia { get; set; }
    }
}