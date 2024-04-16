using System.Collections.Generic;

namespace ButtazzoBanca;

internal class Conto
{
    internal Conto(string nome = "", string cognome = "", string codiceFiscale = "", string codiceConto = "",
        string pin = "")
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.CodiceFiscale = codiceFiscale;

        this.Movimenti = new List<Movimento>();

        this.CodiceConto = codiceConto;
        this.Pin = pin;
    }

    internal string Nome { get; set; }
    internal string Cognome { get; set; }
    internal string CodiceFiscale { get; set; }

    internal string CodiceConto { get; set; }
    internal string Pin { get; }

    internal Luogo? LuogoNascita { get; set; }
    internal Luogo? LuogoResidenza { get; set; }
    internal Luogo? LuogoDomicilio { get; set; }

    internal List<Movimento> Movimenti { get; set; }
}