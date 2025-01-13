class Program
{
    static void Main(string[] args)
    {
        // Skapa en instans av PersonalNumberValidator
        PersonalNumberValidator validator = new PersonalNumberValidator();

        while (true)
        {
            Console.Clear();

            Console.Write("Skriv ett personnummer (eller tryck \"x\" för att avsluta): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "x")
            {
                Console.WriteLine("Programmet avslutas. Tack för att du använde personnummervalideraren!");
                break;
            }
            // Validera personnumret med en enda metod
            if (validator.ValidatePersonalNumber(input))
            {
                Console.WriteLine("Personnumret är giltigt!");
            }
            else
            {
                Console.WriteLine("Ogiltigt personnummer!");
            }
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
