namespace RubricaBotrugnana
{
    internal class Contatto
    {
        internal Contatto(string numero, string nome = "", string cognome = "")
        {
            //List<Recapito> recapitiIniziali = new List<Recapito>();
            //Recapito recapitoIniziale = new Recapito(numero);
            //recapitiIniziali.Add(recapitoIniziale);
            //this.Recapiti = recapitiIniziali;

            this.Recapiti = new List<Recapito>()
            {
                new Recapito(numero),
            }; 

            this.Nome = nome;
            this.Cognome = cognome;
        }

        internal string Nome { get; set; }

        internal string Cognome { get; set; }

        internal Luogo? LuogoNascita { get; set; } = null;
        internal Luogo? LuogoResidenza { get; set; } = null;
        internal Luogo? LuogoDomicilio { get; set; } = null;

        internal List<Recapito> Recapiti { get; set; }
    }
}
