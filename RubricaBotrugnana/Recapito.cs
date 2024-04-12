namespace RubricaBotrugnana
{
    internal class Recapito
    {
        internal Recapito(string valore, string tipo = "Cellulare")
        { 
            this.Valore = valore;
            this.Tipo = tipo;
        }

        internal string Tipo { get; set; }

        internal string Valore { get; set; } 
    }
}
