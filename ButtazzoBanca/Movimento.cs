using System;

namespace ButtazzoBanca;

internal class 
    Movimento
{
    internal Movimento(decimal importo, string tipo)
    {
        this.Importo = importo;
        this.Tipo = tipo;
        this.Data = DateTime.Now;
    }

    internal string Tipo { get; set; }
    internal decimal Importo { get; set; }
    internal DateTime Data { get; set; }
}