using System;

class Program
{
    static void Main(string[] args)
    {
        // Skapa en instans av PersonalNumberValidator
        PersonalNumberValidator validator = new PersonalNumberValidator();

        // Testa CleanPersonalNumber-metoden
        Console.Write("Skriv ett personnummer: ");
        string input = Console.ReadLine();

        string cleanedPnr = validator.CleanPersonalNumber(input);

        Console.WriteLine($"Rensat personnummer: {cleanedPnr}");
    }
}
