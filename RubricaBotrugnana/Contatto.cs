namespace RubricaBotrugnana
{
    internal class Contatto
    {
        internal Contatto(string numero, string nome = "", string cognome = "")
        {
            this.Recapiti = new List<Recapito>()
            {
                new Recapito(numero),
            };

            this.Nome = nome;
            this.Cognome = cognome;
        }

        internal string Nome { get; set; }

        internal string Cognome { get; set; }

        internal Luogo? LuogoNascita { get; set; }
        internal Luogo? LuogoResidenza { get; set; }
        internal Luogo? LuogoDomicilio { get; set; }

        internal DateTime DataNascita { get; set; }
        internal int Eta { get; set; }

        internal List<Recapito> Recapiti { get; set; }
    }
}