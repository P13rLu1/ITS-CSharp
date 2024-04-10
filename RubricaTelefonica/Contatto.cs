namespace RubricaTelefonica;

internal class Contatto
{
    internal Contatto(string nome = " ", string cognome = " ", string numeroDiTelefono = "")
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.NumeroDiTelefono = numeroDiTelefono;
    }
    internal string Nome { get; set; }
    internal string Cognome { get; set; }
    internal string NumeroDiTelefono { get; set; }
}