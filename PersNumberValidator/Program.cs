class Program
{
    static void Main(string[] args)
    {
        // Skapa en instans av PersonalNumberValidator
        PersonalNumberValidator validator = new PersonalNumberValidator();

        Console.Write("Skriv ett personnummer: ");
        string input = Console.ReadLine();

        // Validera personnumret med en enda metod
        if (validator.ValidatePersonalNumber(input))
        {
            Console.WriteLine("Personnumret är giltigt!");
        }
        else
        {
            Console.WriteLine("Ogiltigt personnummer!");
        }
    }
}
