namespace RubricaTelefonica;

public static class Program
{
    public static void Main(string[] args)
    {
        //far scegliere all'utente se vuole aggiungere un contatto o visualizzare la rubrica
        Console.WriteLine("Benvenuto nella tua rubrica telefonica!");
        
        List<Contatto> rubrica = new List<Contatto>();
        
        //chiedere all'utente il nome, cognome e numero di telefono del contatto
        Contatto nuovoContatto = new Contatto("Silvio", "Albi", "1234567890");
        // nuovoContatto.Nome = "Silvio";
        // nuovoContatto.Cognome = "Albi";
        // nuovoContatto.NumeroDiTelefono = "1234567890";
        
        rubrica.Add(nuovoContatto);
        
        Contatto nuovoContattoDue = new Contatto("Salvatore", "De Luca", "0987654321");
        // nuovoContattoDue.Nome = "Salvatore";
        // nuovoContattoDue.Cognome = "De Luca";
        // nuovoContattoDue.NumeroDiTelefono = "0987654321";
        
        rubrica.Add(nuovoContattoDue);
        
        Contatto nuovoContattoTre = new Contatto("Giovanni");
        
        rubrica.Add(nuovoContattoTre);
        
        foreach (Contatto contatto in rubrica)
        {
            Console.WriteLine($"Nome: {contatto.Nome} \nCognome: {contatto.Cognome} \nNumero di telefono: {contatto.NumeroDiTelefono} \n -----------------");
        }
    }
}