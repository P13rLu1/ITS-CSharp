using System.Collections.Generic;

namespace ButtazzoBanca;

internal class Conto
{
    internal Conto(string nome = "", string cognome = "", string codiceFiscale = "", string codiceConto = "",
        string pin = "") // Costruttore di default con parametri inizializzati a stringa vuota
    {
        this.Nome = nome; // this.Nome si riferisce alla proprietà Nome della classe Conto
        this.Cognome = cognome; // this.Cognome si riferisce alla proprietà Cognome della classe Conto
        this.CodiceFiscale = codiceFiscale; // this.CodiceFiscale si riferisce alla proprietà CodiceFiscale della classe Conto

        this.Movimenti = new List<Movimento>(); // Inizializzazione della lista di movimenti del conto

        this.CodiceConto = codiceConto; // Assegnazione del codice conto passato come parametro al costruttore
        this.Pin = pin; // Assegnazione del pin passato come parametro al costruttore
    } 

    internal string Nome { get; set; } // Proprietà Nome della classe Conto
    internal string Cognome { get; set; } // Proprietà Cognome della classe Conto
    internal string CodiceFiscale { get; set; } // Proprietà CodiceFiscale della classe Conto

    internal string CodiceConto { get; set; } // Proprietà CodiceConto della classe Conto
    internal string Pin { get; } // Proprietà Pin della classe Conto

    internal Luogo? LuogoNascita { get; set; } // Proprietà LuogoNascita della classe Conto 
    internal Luogo? LuogoResidenza { get; set; } // Proprietà LuogoResidenza della classe Conto 
    internal Luogo? LuogoDomicilio { get; set; } // Proprietà LuogoDomicilio della classe Conto 

    internal List<Movimento> Movimenti { get; set; } // Proprietà Movimenti della classe Conto 
}