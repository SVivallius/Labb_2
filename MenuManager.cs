namespace Labb2;

internal static class MenuManager
{
    public static void BuildMenu()
    {
        // Krav: Huvudmeny med följande val
        Console.Clear();
        Console.Write("Kontrollprogram, Köksutrustning.\n" +
            "Vänlig välj nedan.\n\n" +
            "[1] Aktivera.\n" +
            "[2] Registrera ny.\n" +
            "[3] Lista.\n" +
            "[4] Ta bort.\n" +
            "[5] Avsluta applikation.\n" +
            "[6] Spara lista.\n\n" +
            "Välj: ");
    }

    public static void BuildActivateMenu(List<Appliance> appliances)
    {
        Console.Clear();
        foreach(Appliance appliance in appliances)
        {
            Console.WriteLine(appliance.ToString());
        }
    }

    public static void AwaitConfirm()
    {
        Console.WriteLine("Tryck på valfri tangent för att återgå.");
        Console.ReadKey();
    }

    public static void LogErrorHandling(Exception error)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        using (FileStream stream = new FileStream("Error.txt", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sr = new StreamWriter(stream))
            {
                sr.WriteLine(error.ToString());
                sr.WriteLine(DateTime.Now.ToString());
            }
        }
    }

    public static bool InterpretTrueFalse(string input)
    {
        bool resolved = false;
        bool interpreted = false;

        while (!resolved)
        {
            switch (input.ToLower())
            {
                case "true":
                    interpreted = true;
                    resolved = true;
                    break;

                case "false":
                    interpreted = false;
                    resolved = true;
                    break;

                case "y":
                    interpreted = true;
                    resolved = true;
                    break;

                case "n":
                    interpreted = false;
                    resolved = true;
                    break;

                default:
                    Console.Write("Ogiltigt svar. Försök igen: ");
                    resolved = false;
                    input = Console.ReadLine();
                    break;
            }
        }
        return interpreted;
    }

    public static int Selection(int maxLength)
    {
        bool validOption = false;
        int output = 0;

        while (!validOption)
        {
            string input = Console.ReadLine();

            // Krav: Try-Catch
            try
            {
                output = Convert.ToInt32(input);
                if (output <= maxLength && output > 0)
                {
                    validOption = true;
                    break;
                }
                else
                {
                    validOption = false;
                    Console.Write("Ogiltigt val! Försök igen: ");
                }
            }
            catch
            {
                validOption = false;
                Console.Write("Ogiltigt val! Försök igen: ");
            }
        }

        return output;
    }
}
