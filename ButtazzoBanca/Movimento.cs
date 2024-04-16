using System;

namespace ButtazzoBanca;

internal class 
    Movimento 
{
    internal Movimento(decimal importo, string tipo) // Costruttore della classe Movimento
    {
        this.Importo = importo; // Inizializzazione del campo Importo 
        this.Tipo = tipo; // Inizializzazione del campo Tipo 
        this.Data = DateTime.Now; // Inizializzazione del campo Data con la data e l'ora attuali
    }

    internal string Tipo { get; set; } // Proprietà Tipo della classe Movimento 
    internal decimal Importo { get; set; } // Proprietà Importo della classe Movimento
    internal DateTime Data { get; set; } // Proprietà Data della classe Movimento 
}